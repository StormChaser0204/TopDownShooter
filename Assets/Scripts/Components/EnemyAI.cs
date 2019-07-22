using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : UnitComponent {

    private RunnerComponent _runnerComponent;

    private Quaternion _rotation;
    private Transform _playerTransform;

    public void SetDirection(Quaternion rotation) {
        _rotation = rotation;
    }

    protected override void Init() {
        _runnerComponent = GetComponent<RunnerComponent>();
        base.Init();
    }

    private void Update() {
    
    }

    private void OnCollisionEnter(Collision col) {
        var unitComponent = col.gameObject.GetComponent<UnitComponent>();
        if (unitComponent == null) return;
        if (unitComponent.UnitType == Type.Enemy) {
            ChangeDirection();
        }
    }

    private void OnTriggerEnter(Collider col) {
        var unitComponent = col.GetComponent<UnitComponent>();
        if (unitComponent == null) return;
        if (unitComponent.UnitType == Type.Player) {
            _playerTransform = col.transform;
        }
    }

    private void ChangeDirection() {
        _rotation = _rotation * Quaternion.Euler(0, Random.Range(-45, 45), 0);
    }
}
