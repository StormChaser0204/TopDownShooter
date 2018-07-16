using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour {

    private RaycastHit _hit;
    private Coroutine cr_raycast;
    private EnemyAI _enemyAI;

    private void Start() {
        cr_raycast = StartCoroutine(Cr_Raycast());
        _enemyAI = GetComponent<EnemyAI>();
    }

    private void OnDestroy() {
        StopCoroutine(cr_raycast);
    }

    private IEnumerator Cr_Raycast() {
        while (true) {
            yield return new WaitForSeconds(2);
            Physics.Raycast(transform.position, Vector3.down, out _hit, 10f);
            if (_hit.collider == null) {
                BotController.Instance.RespawnEnemy(_enemyAI);
            }
        }
    }
}
