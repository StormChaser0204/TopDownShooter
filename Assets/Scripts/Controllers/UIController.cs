using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject loseWindow;
    public Text killCounterText;
    public Button toMenu;
    public Button shoot;
    public Transform healthParent;
    public GameObject healthPrefab;

    [SerializeField]
    private List<GameObject> healthList;
    private int killCounter = 0;

    public void Awake()
    {
        MainController.instance.playerController.player.onTakeDamage += UpdateHP;
        toMenu.onClick.AddListener(() => MainController.instance.BackToMenu());
        shoot.onClick.AddListener(() => MainController.instance.playerController.player.Shoot());
        shoot.onClick.AddListener(StartCD);
    }

    public void Start()
    {
        healthList = new List<GameObject>();
        for (int i = 0; i < PlayerController.instance.player.lifeCounter; i++)
        {
            healthList.Add(Instantiate(healthPrefab, healthParent));
        }
    }

    public void StartCD()
    {
        shoot.interactable = false;
        StartCoroutine(CD());
    }

    public void UpdateHP()
    {
        Destroy(healthList[healthList.Count - 1].gameObject);
        healthList.Remove(healthList[healthList.Count - 1]);
    }

    public void IncriminateKill()
    {
        killCounter++;
        killCounterText.text = string.Format("KILLS:{0}", killCounter);
    }

    public void Lose()
    {
        loseWindow.SetActive(true);
    }

    IEnumerator CD()
    {
        yield return new WaitForSeconds(0.5f);
        shoot.interactable = true;
    }

}
