using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerComponent : BaseComponent {
    [SerializeField]
    private float _startSpeed;

    private Transform _transform;
    private Vector3 _direction;
    private Quaternion _rotation;
    private float _currentSpeed;

    public Transform Trans {
        get {
            return _transform;
        }
    }

    private void Update() {
        _transform.rotation = _rotation;
        _transform.position += _direction * _currentSpeed * Time.deltaTime;
    }

    public void SetDirection(Vector3 direction, Quaternion rotation) {
        _direction = direction;
        _rotation = rotation;
    }

    public void StopMoving() {
        _currentSpeed = 0;
    }

    public void StartMoving() {
        _currentSpeed = _startSpeed;
    }

    protected override void Init() {
        _transform = GetComponent<Transform>();
        _currentSpeed = _startSpeed;
    }
}
