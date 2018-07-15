using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultShell : BaseShell {

    private void OnCollisionEnter(Collision col) {
        Destroy(this.gameObject);
    }
}
