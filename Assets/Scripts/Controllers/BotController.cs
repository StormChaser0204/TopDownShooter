using Engine.Singleton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotController : SceneSingleton<BotController> {
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private Transform _enemyParent;
    [SerializeField]
    private List<Transform> _spawnPoints;


    private float spawnTime = 6;
    private Coroutine cr_Spawning;

    protected override void OnDestroy() {
        StopCoroutine(cr_Spawning);
        base.OnDestroy();
    }

    private Transform GetSpawnPosition() {
        return _spawnPoints[Random.Range(0, _spawnPoints.Count)];
    }

    public void RespawnEnemy(EnemyAI enemy) {
        enemy.gameObject.SetActive(true);
        SpawnBot(enemy);
    }

    private void SpawnBot(EnemyAI enemyAI = null) {
        if (enemyAI == null) {
            GameObject spawnedEnemy;
            spawnedEnemy = Instantiate(_enemyPrefab, _enemyParent);
            enemyAI = spawnedEnemy.GetComponent<EnemyAI>();
            if (enemyAI == null) return;
        }
        var enemyTransform = enemyAI.RunnerComponent.Trans;
        var spawnTransform = GetSpawnPosition();
        enemyAI.Active = true;
        enemyAI.Animator.SetBool("Active", true);
        enemyAI.RunnerComponent.StartMoving();
        enemyTransform.position = spawnTransform.position;
        enemyAI.SetDirection(spawnTransform.rotation * Quaternion.Euler(0, Random.Range(-45, 45), 0));
    }

    private IEnumerator Cr_Spawning() {
        while (true) {
            SpawnBot();
            yield return new WaitForSeconds(spawnTime);
        }
    }

    protected override void Init() {
        cr_Spawning = StartCoroutine(Cr_Spawning());
    }
}
