using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Slider progressBar;
    public TextMeshProUGUI victoryText;
    public AudioClip victoryClip;
    public TextMeshProUGUI gameOverText;
    public AudioClip gameOverClip;
    public Button restartButton;

    private int _numberOfPlayers = 2;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        progressBar.onValueChanged.AddListener(CheckVictory);
        restartButton.onClick.AddListener(RestartGame);
    }

    private void CheckVictory(float value)
    {
        if ((int)progressBar.maxValue != (int)value)
        {
            return;
        }

        victoryText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);

        AudioSource.PlayClipAtPoint(victoryClip, Vector2.zero);
    }

    private void CheckGameOver()
    {
        if (_numberOfPlayers > 0)
        {
            return;
        }

        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);

        AudioSource.PlayClipAtPoint(gameOverClip, Vector2.zero);
    }

    private void OnEnemyDestroy()
    {
        progressBar.value++;
    }

    private void OnPlayerDestroy()
    {
        _numberOfPlayers--;

        CheckGameOver();
    }

    private static void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
