using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Invaders grid;
    public TextMeshProUGUI killCountText;

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
}
