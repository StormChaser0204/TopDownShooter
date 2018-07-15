using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealerComponent : BaseComponent {

    [SerializeField]
    private float _damage;
    [SerializeField]
    private List<UnitComponent.Type> _targetTypes;

    public float Damage {
        get {
            return _damage;
        }
    }
    public void DealDamage(UnitComponent targetUnit) {
        targetUnit.DamageTaker.TakeDamage(_damage);
    }

    private void OnCollisionEnter(Collision col) {
        var unitComponent = col.gameObject.GetComponent<UnitComponent>();
        if (unitComponent == null) return;
        if (!_targetTypes.Contains(unitComponent.UnitType)) return;
        DamageManager.Instance.DealDamage(this, unitComponent.DamageTaker);
    }

    //TODO: Перенести сюда OnCollisionEnter и в нем делать проверку, добавить DamageManager и его вызов
    protected override void Init() {
    }
}
