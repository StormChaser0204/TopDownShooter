using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingComponent : BaseComponent {

    private UnitComponent _unitComponent;

    private GameObject _shellPrefab;
    private float _cooldownTime;
    private float _shellSpeed;

    private bool _canMakeShoot;
    private float _currentTime;

    private Coroutine cr_Cooldown;

    public void SetShell(ShellInfo shellInfo) {
        _shellPrefab = shellInfo.ShellPrefab;
        _cooldownTime = shellInfo.CooldownTime;
        _shellSpeed = shellInfo.ShellSpeed;
    }

    public void MakeShoot(Transform transform) {
        if (!_canMakeShoot) return;
        var instantiatedShell = Instantiate(_shellPrefab, transform.position, transform.rotation);
        var runnerComponent = instantiatedShell.GetComponent<RunnerComponent>();
        var shell = instantiatedShell.GetComponent<BaseShell>();
        shell.SetInformation(_unitComponent.UnitType);
        runnerComponent.SetDirection(transform.forward, transform.rotation);
        cr_Cooldown = StartCoroutine(Cr_Cooldown());
    }

    private IEnumerator Cr_Cooldown() {
        _canMakeShoot = false;
        yield return new WaitForSeconds(_cooldownTime);
        _canMakeShoot = true;
        StopCoroutine(cr_Cooldown);
    }

    protected override void Init() {
        _unitComponent = GetComponent<UnitComponent>();
        _canMakeShoot = true;
    }
}
