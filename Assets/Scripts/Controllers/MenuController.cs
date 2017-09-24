using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public Button game;
    // Use this for initialization
    void Start()
    {
        game.onClick.AddListener(ToGame);
    }

    public void ToGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }

}
