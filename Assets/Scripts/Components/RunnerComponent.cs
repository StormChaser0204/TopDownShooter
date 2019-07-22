using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerComponent : BaseComponent {
    [SerializeField]
    private float _speed;

    private Transform _transform;
    private Vector3 _direction;
    private Quaternion _rotation;
    private float _currentSpeed;

    private void Update() {
        _transform.rotation = _rotation;
        _transform.position += _direction * _currentSpeed * Time.deltaTime;
    }

    public void SetDirection(Vector3 direction, float rotation) {
        _direction = direction;
        _rotation = Quaternion.Euler(new Vector3(0f, rotation, 0)); ;
    }

    protected override void Init() {
        _transform = GetComponent<Transform>();
        _currentSpeed = _speed;
    }
}
