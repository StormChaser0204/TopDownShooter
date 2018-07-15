using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Engine.Singleton;
using System;

public class DamageManager : SceneSingleton<DamageManager> {

    public void DealDamage(DamageDealerComponent damageDealer, DamageTakerComponent damageTaker) {
        damageTaker.TakeDamage(damageDealer.Damage);
    }

    protected override void Init() {
    }
}
