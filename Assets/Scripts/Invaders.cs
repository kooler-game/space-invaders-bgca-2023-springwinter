using UnityEngine;

public class Invaders : MonoBehaviour
{
    public int rows = 4;
    public int cols = 4;
    private float step = 2f;
    public Invader[] prefabs;

    private Vector3 _direction = Vector3.left;

    public int killCount = 0;
    private int totalInvadersCount => this.rows * this.cols;
    private float killedPercentage => (float)killCount / (float)totalInvadersCount;

    // public float speed = 1f;
    public AnimationCurve speed;

    private void Awake()
    {
        spawn();
    }

    private void Update()
    {
        this.transform.position += _direction * speed.Evaluate(killedPercentage) * Time.deltaTime;

        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        foreach (Transform invader in this.transform)
        {
            if (_direction == Vector3.right && invader.position.x >= rightEdge.x - 1f)
            {
                AdvanceRow();
            }
            else if (_direction == Vector3.left && invader.position.x <= leftEdge.x + 1f)
            {
                AdvanceRow();
            }
        }
    }

    private void AdvanceRow()
    {
        _direction.x *= -1;
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - 1);
    }

    public void spawn()
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
                invader.onKilled += this.onInvaderGetKilled;
                invader.transform.localPosition = position;
            }
        }

        float offsetX = cols * 1.5f / 2;
        this.transform.position = new Vector3(-offsetX + step / 2, this.transform.position.y);
    }

    public bool isEmpty() {
        foreach(Transform invader in this.transform) {
            if(invader.gameObject.activeSelf) {
                return false;
            }
        }

        return true;
    }

    private void onInvaderGetKilled() {
        this.killCount++;
    }
}
