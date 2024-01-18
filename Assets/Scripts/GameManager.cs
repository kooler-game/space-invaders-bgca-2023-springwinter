using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Invaders grid;

    public void Update()
    {
        if (grid.isEmpty())
        {
            grid.reset();
            grid.spawn();
        }
    }
}
