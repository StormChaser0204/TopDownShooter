using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseComponent : MonoBehaviour {

    private bool _active;

    public bool Active {
        get {
            return _active;
        }
        set {
            _active = value;
        }
    }

    protected void Awake() {
        Init();
    }

    protected abstract void Init();
}
