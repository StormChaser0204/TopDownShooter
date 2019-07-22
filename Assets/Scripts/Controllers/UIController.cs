using Engine.Singleton;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : SceneSingleton<UIController> {
    [SerializeField]
    private GameObject _loseWindow;
    [SerializeField]
    private Text _killCounterText;
    [SerializeField]
    private Button _toMenu;
    [SerializeField]
    private Transform _healthParent;
    [SerializeField]
    private GameObject _healthPrefab;
    [SerializeField]
    private List<GameObject> _healthList;


    private PlayerComponent _player;
    private int _killCounter;
    private int _healthCounter;

    public int KillCounter {
        get {
            return _killCounter;
        }
        set {
            _killCounter++;
            UpdateKillCounter();
        }
    }

    protected override void Init() {
        _toMenu.onClick.AddListener(BackToMenu);
        _killCounter = 0;
        _player = FindObjectOfType<PlayerComponent>();
        UpdateHP();
    }

    public void UpdateHP() {
        var currentHealthCount = _healthList.Count;

        if (_healthCounter > currentHealthCount) {
            for (int i = 0; i < _healthCounter - currentHealthCount; i++) {
                var healthObject = Instantiate(_healthPrefab, _healthParent);
                _healthList.Add(healthObject);
            }
        }
        else {
            for (int i = 0; i < currentHealthCount - _healthCounter; i++) {
                Destroy(_healthList[i]);
                _healthList.Remove(_healthList[i]);
            }
        }
    }

    private void UpdateKillCounter() {
        _killCounterText.text = string.Format("KILLS:{0}", _killCounter);
    }

    public void Lose() {
        Time.timeScale = 0;
        _loseWindow.SetActive(true);
    }

    private void BackToMenu() {
        SceneManager.LoadScene("Menu");
    }
}
