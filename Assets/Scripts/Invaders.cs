using UnityEngine;

public class Invaders : MonoBehaviour
{
    public int rows = 4;
    public int cols = 4;
    private float step = 2f;
    public Invader[] prefabs;

    private void Awake()
    {
        for (int row = 0; row < rows; row++)
        {
            float positionY = row * step;
            for (int col = 0; col < cols; col++)
            {
                float positionX = col * step;
                Vector3 position = new Vector3(positionX, positionY);

                // int prefabsType = (int)(Random.value * prefabs.Length);
                // Invader invader = Instantiate(prefabs[prefabsType], this.transform);
                Invader invader = Instantiate(prefabs[row], this.transform);
                invader.transform.localPosition = position;
            }
        }

        float offsetX = cols * 1.5f / 2;
        this.transform.position = new Vector3(- offsetX + step / 2, this.transform.position.y);
    }
}
