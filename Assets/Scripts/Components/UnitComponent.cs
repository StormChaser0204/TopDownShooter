using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitComponent : BaseComponent {

    [SerializeField]
    private Type _unitType;
    [SerializeField]
    protected float _health;

    private Animator _animator;

    protected DamageTakerComponent _damageTaker;
    protected DamageDealerComponent _damageDealer;
    protected RunnerComponent _runnerComponent;
    protected ShootingComponent _shootingComponent;

    public DamageTakerComponent DamageTaker { get { return _damageTaker; } }
    public DamageDealerComponent DamageDealer { get { return _damageDealer; } }
    public RunnerComponent RunnerComponent { get { return _runnerComponent; } }
    public ShootingComponent ShootingComponent { get { return _shootingComponent; } }
    public Type UnitType { get { return _unitType; } }
    public Animator Animator { get { return _animator; } }

    public float Health {
        get {
            return _health;
        }
        set {
            _health = value;
        }
    }

    public virtual void TakeDamage() {
    }

    public virtual void Death() {
    }

    protected override void Init() {

        var damageTaker = GetComponent<DamageTakerComponent>();
        var damageDealer = GetComponent<DamageDealerComponent>();
        var runnerComponent = GetComponent<RunnerComponent>();
        var shootingComponent = GetComponent<ShootingComponent>();

        if (damageTaker != null) _damageTaker = damageTaker;
        if (damageDealer != null) _damageDealer = damageDealer;
        if (runnerComponent != null) _runnerComponent = runnerComponent;
        if (shootingComponent != null) _shootingComponent = shootingComponent;

        Active = true;
        _damageTaker.CanTakeDamage = true;

        _animator = GetComponent<Animator>();
        _animator.SetBool("Active", Active);
    }

    public enum Type {
        Enemy = 0,
        Player = 1
    }
}
