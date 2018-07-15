using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Engine.Singleton;
using System;

public class DataManager : SceneSingleton<DataManager> {

    [SerializeField]
    private ShellInformation _shellInformation;

    public ShellInformation ShellInformation {
        get {
            return _shellInformation;
        }
    }

    protected override void Init() {
    }
}
