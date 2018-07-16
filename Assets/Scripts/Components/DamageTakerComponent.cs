using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTakerComponent : BaseComponent {

    private bool _canTakeDamage;
    public bool CanTakeDamage {
        get {
            return _canTakeDamage;
        }
        set {
            _canTakeDamage = value;
        }
    }

    private UnitComponent _unitComponent;
    public UnitComponent UnitComponent {
        get {
            return _unitComponent;
        }
    }

    public void TakeDamage(float damage) {
        if (!CanTakeDamage) return;
        _unitComponent.Health -= damage;
        if (_unitComponent.Health <= 0) {
            _unitComponent.Death();
        }
        else {
            _unitComponent.TakeDamage();
        }
    }

    protected override void Init() {
        _unitComponent = GetComponent<UnitComponent>();
    }
}
