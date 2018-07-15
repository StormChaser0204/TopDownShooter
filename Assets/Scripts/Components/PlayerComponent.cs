using CnControls;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComponent : UnitComponent {

    private Quaternion _rotation;
    private Coroutine _takeDamage;
    private void Start() {
        _health = 3;
        ShootingComponent.SetShell(DataManager.Instance.ShellInformation.GetShellInfo(ShellInfo.Type.defaultShell));
        _runnerComponent.StartMoving();
    }

    private void Update() {
        var moveVelocity = new Vector3(CnInputManager.GetAxis("Horizontal"), 0, CnInputManager.GetAxis("Vertical"));
        if (CnInputManager.GetAxis("HorizontalRotation") != 0 || CnInputManager.GetAxis("VerticalRotation") != 0) {
            _rotation = Quaternion.Euler(0, Mathf.Atan2(CnInputManager.GetAxis("HorizontalRotation"), CnInputManager.GetAxis("VerticalRotation")) * Mathf.Rad2Deg, 0);
        }
        _runnerComponent.SetDirection(moveVelocity, _rotation);

        if (CnInputManager.GetAxis("HorizontalRotation") != 0 || CnInputManager.GetAxis("VerticalRotation") != 0) {
            ShootingComponent.MakeShoot(RunnerComponent.Trans);
        }
    }

    public override void TakeDamage() {
        _takeDamage = StartCoroutine(WaitForRevive());
        UIController.Instance.UpdateHP();
        base.TakeDamage();
    }

    private IEnumerator WaitForRevive() {
        DamageTaker.CanTakeDamage = false;
        yield return new WaitForSeconds(2);
        DamageTaker.CanTakeDamage = true;
        StopCoroutine(_takeDamage);
    }

    public override void Death() {
        UIController.Instance.Lose();
        base.Death();
    }
}