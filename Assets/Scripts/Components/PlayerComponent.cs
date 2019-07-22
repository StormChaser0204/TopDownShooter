using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComponent : UnitComponent {

    private Quaternion _rotation;
    private RunnerComponent _runnerComponent;

    private float _horizontal;
    private float _vertical;

    private void Start() {
    }

    protected override void Init() {
        _runnerComponent = GetComponent<RunnerComponent>();
        base.Init();
    }

    private void Update() {
        var moveVelocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        var rotation = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotation_y = Mathf.Atan2(rotation.x, rotation.z) * Mathf.Rad2Deg;
        _runnerComponent.SetDirection(moveVelocity, rotation_y);
    }

    public override void Death() {
        UIController.Instance.Lose();
        base.Death();
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}