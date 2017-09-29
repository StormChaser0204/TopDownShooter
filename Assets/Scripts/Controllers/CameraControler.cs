using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    public Transform player;

    private Vector3 heightFix;
    private Vector3 playerPos;
    private Vector3 cameraPos;

    public void Start()
    {
        heightFix = new Vector3(0, 3f, 0);
    }

    public void Update()
    {
        playerPos = player.transform.position;
        cameraPos = transform.position;

        if (playerPos.x >= -7.6f && playerPos.x <= 7.6f && playerPos.z >= -13 && playerPos.z <= 13)
        {
            transform.position = player.transform.position + heightFix;
        }
        else if (playerPos.x < -7.6)
        {
            if (playerPos.z >= -13 && playerPos.z <= 13)
                transform.position = new Vector3(-7.6f, 0, playerPos.z) + heightFix;
        }
        if (playerPos.x > 7.6)
        {
            if (playerPos.z >= -13 && playerPos.z <= 13)
                transform.position = new Vector3(7.6f, 0, playerPos.z) + heightFix;
        }
        if (playerPos.z < -13)
        {
            if (playerPos.x >= -7.6 && playerPos.x <= 7.6)
                transform.position = new Vector3(playerPos.x, 0, -13) + heightFix;
        }
        if (playerPos.z > 13)
        {
            if (playerPos.x >= -7.6 && playerPos.x <= 7.6)
                transform.position = new Vector3(playerPos.x, 0, 13) + heightFix;
        }
    }
}
