using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Player player;

    private static PlayerController Instance;
    public static PlayerController instance { get { return Instance; } }

    public PlayerController()
    {
        Instance = this;
    }
}
