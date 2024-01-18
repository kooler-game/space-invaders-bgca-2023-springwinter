using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Invaders grid;
    public TextMeshProUGUI killCountText;
    
    public GameObject gameOverPanel;
    public TextMeshProUGUI gameOverPanelKillCountText;

    public static GameManager instance;
    
    public void Awake()
    {
        instance = this;
    }

    public void Update()
    {
        if (grid.isEmpty())
        {
            grid.reset();
            grid.spawn();
        }
    }

    public void UpdateKillCount(int killCount) {
        killCountText.text = killCount.ToString().PadLeft(5, '0');
    }

    public void GameOver() {
        gameOverPanelKillCountText.text = "Kill Count: " + killCountText.text;
        gameOverPanel.gameObject.SetActive(true);
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
