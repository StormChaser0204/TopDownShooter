using UnityEngine;

public abstract class BaseComponent : MonoBehaviour {

    protected void Awake() {
        Init();
    }

    protected abstract void Init();
}
