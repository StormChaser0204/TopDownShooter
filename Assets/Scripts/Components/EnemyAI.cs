using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : UnitComponent {

    private Quaternion _rotation;
    private Transform _playerTransform;
    private Coroutine cr_Death;

    public void SetDirection(Quaternion rotation) {
        _rotation = rotation;
    }

    private void Update() {
        if (!Active)
            _runnerComponent.StopMoving();
        if (_playerTransform == null)
            _runnerComponent.SetDirection(transform.forward, _rotation);
        else
            _runnerComponent.SetDirection(_playerTransform.position - transform.position, _rotation);
    }

    private void OnCollisionEnter(Collision col) {
        var unitComponent = col.gameObject.GetComponent<UnitComponent>();
        if (unitComponent == null) return;
        if (unitComponent.UnitType == Type.Enemy) {
            ChangeDirection();
        }
    }

    private void OnTriggerEnter(Collider col) {
        if (!Active) return;
        var unitComponent = col.GetComponent<UnitComponent>();
        if (unitComponent == null) return;
        if (unitComponent.UnitType == Type.Player) {
            _playerTransform = col.transform;
        }
    }

    private void ChangeDirection() {
        _rotation = _rotation * Quaternion.Euler(0, Random.Range(-45, 45), 0);
    }

    public override void TakeDamage() {
        base.TakeDamage();
    }

    public override void Death() {
        Animator.SetTrigger("Death");
        Animator.SetBool("Active", false);
        cr_Death = StartCoroutine(Cr_Death());
        base.Death();
    }

    private IEnumerator Cr_Death() {
        _playerTransform = null;
        Active = false;
        UIController.Instance.KillCounter++;
        yield return new WaitForSeconds(1);
        BotController.Instance.RespawnEnemy(this);
        StopCoroutine(cr_Death);
    }
}
