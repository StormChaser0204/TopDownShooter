using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShellInfo {

    [SerializeField]
    private Type _shellType;
    [SerializeField]
    private GameObject _shellPrefab;
    [SerializeField]
    private float _shellSpeed;
    [SerializeField]
    private float _cooldownTime;
   


    public GameObject ShellPrefab {
        get {
            return _shellPrefab;
        }
    }

    public float ShellSpeed {
        get {
            return _shellSpeed;
        }
    }

    public float CooldownTime {
        get {
            return _cooldownTime;
        }
    }

    public Type ShellType {
        get {
            return _shellType;
        }
    }

    public enum Type {
        defaultShell = 0
    }

}
