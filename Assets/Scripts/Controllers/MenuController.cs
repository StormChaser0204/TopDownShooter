using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public void ToGame() {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }
}
