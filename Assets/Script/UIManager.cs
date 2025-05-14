using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _scoreUI;
    [SerializeField]
    private GameObject _startMenuUI;
    [SerializeField]
    private GameObject _gameOverUI;
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameManager.instance;
        _gameManager.onGameOver.AddListener(ActivateGameOverUI);
    }

    public void PlayButtonHandler()
    {
        _gameManager.StartGame();
    }

    public void ActivateGameOverUI()
    {
        _gameOverUI.SetActive(true);
    }

    private void OnGUI()
    {
        _scoreUI.text = _gameManager.PrettyScore();
    }
}
