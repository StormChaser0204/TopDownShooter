using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitComponent : BaseComponent {

    [SerializeField]
    private Type _unitType;

    public Type UnitType {
        get {
            return _unitType;
        }
    }

    public virtual void TakeDamage() {
    }

    public virtual void Death() {
    }

    protected override void Init() {
    }

    public enum Type {
        Enemy = 0,
        Player = 1
    }
}
