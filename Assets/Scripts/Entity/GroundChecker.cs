using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public bool onFloor = false;

    public void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Floor")
        {
            onFloor = true;
        }
    }

    public void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Floor")
        {
            if (onFloor)
            {
                GetComponentInParent<EnemyBehaviour>().Respawn();
            }
        }
        if (col == null)
        {
            onFloor = false;
        }
    }
}