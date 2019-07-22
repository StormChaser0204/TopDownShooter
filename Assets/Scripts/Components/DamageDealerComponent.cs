using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealerComponent : BaseComponent {

    [SerializeField]
    private float _damage;
    public float Damage {
        get {
            return _damage;
        }
    }

    protected override void Init() {
    }
}
