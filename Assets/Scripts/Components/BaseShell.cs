using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseShell : BaseComponent {

    protected UnitComponent.Type _targetType;
    protected DamageDealerComponent _damageDealer;

    public void SetInformation(UnitComponent.Type shooterType) {

        switch (shooterType) {
            case UnitComponent.Type.Enemy:
                _targetType = UnitComponent.Type.Player;
                break;
            case UnitComponent.Type.Player:
                _targetType = UnitComponent.Type.Enemy;
                break;
        }
    }

    protected override void Init() {
        _damageDealer = GetComponent<DamageDealerComponent>();
    }
}
