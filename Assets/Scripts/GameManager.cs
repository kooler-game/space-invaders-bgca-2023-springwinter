using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Invaders grid;

    // UI
    public TextMeshProUGUI killCountText;
    public GameObject gameOverPanel;
    public TextMeshProUGUI gameOverKillCountText;

    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance is null)
                Debug.LogError("GameManager is null");
            return _instance;
        }
        set
        {
            _instance = value;
        }
    }

    public void Awake()
    {
        Instance = this;
    }

    public void Update()
    {
        if (grid.isEmpty())
        {
            grid.reset();
            grid.spawn();
        }
    }

    public void UpdateKillCount(int count)
    {
        killCountText.text = count.ToString().PadLeft(5, '0');
        gameOverKillCountText.text = "KILL COUNT : " + count.ToString();
    }

    public void GameOver()
    {
        // Show game over screen
        gameOverPanel.gameObject.SetActive(true);
    }
}
