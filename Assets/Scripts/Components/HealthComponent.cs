using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : BaseComponent {

    private float _health;
    public float Health {
        get {
            return _health;
        }
        set {
            _health = value;
        }
    }

    public void ChangeHealth(float value) {
        _health -= value;
    }

    protected override void Init() {
    }
}
