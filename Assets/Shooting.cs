using CnControls;
using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour {

    [SerializeField]
    private GameObject _bullet;
    private Transform _shooterTransform;

    private float _cooldownTime;
    private bool _shooting;
    private Coroutine cr_Shooting;

    private void Start() {
        _shooterTransform = FindObjectOfType<PlayerComponent>().RunnerComponent.Trans;
        _cooldownTime = 0.5f;
    }

    private void FixedUpdate() {

        if (CnInputManager.GetAxis("HorizontalRotation") != 0 || CnInputManager.GetAxis("VerticalRotation") != 0) {
            if (!_shooting) {
                _shooting = true;
                cr_Shooting = StartCoroutine(Cr_Shooting());
            }
        }
        else {
            _shooting = false;
            if (cr_Shooting != null)
                StopCoroutine(cr_Shooting);
        }
    }

    private IEnumerator Cr_Shooting() {
        while (_shooting) {
            Shoot();
            yield return new WaitForSeconds(_cooldownTime);
        }
    }

    private void Shoot() {
        Instantiate(_bullet, _shooterTransform.position, _shooterTransform.rotation);
    }
}
