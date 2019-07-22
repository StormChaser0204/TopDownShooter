using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTakerComponent : BaseComponent {

    [SerializeField]
    private List<UnitComponent.Type> _ignoredTypes;
    private HealthComponent _healthComponent;

    public void TakeDamage(DamageDealerComponent damageDealer) {
        _healthComponent.ChangeHealth(damageDealer.Damage);
    }

    private void OnCollisionEnter(Collision col) {
        var unitComponent = col.gameObject.GetComponent<UnitComponent>();
        if (unitComponent == null) return;
        if (_ignoredTypes.Contains(unitComponent.UnitType)) return;
        var damageDealerComponent = unitComponent.GetComponent<DamageDealerComponent>();
        if (damageDealerComponent == null) return;
        TakeDamage(damageDealerComponent);
    }

    protected override void Init() {
        _healthComponent = GetComponent<HealthComponent>();
    }
}
