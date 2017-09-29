using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{
    [HideInInspector]
    public PlayerController playerController;
    [HideInInspector]
    public UIController uiController;
    [HideInInspector]
    public BotController botController;

    private static MainController Instance;
    public static MainController instance { get { return Instance; } }

    public MainController()
    {
        Instance = this;
    }

    public void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
        uiController = FindObjectOfType<UIController>();
        botController = FindObjectOfType<BotController>();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
