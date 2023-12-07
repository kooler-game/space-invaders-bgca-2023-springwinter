using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 1f;
    public Laser laser;

    private void Update()
    {
        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        if (Input.GetKey(KeyCode.LeftArrow) && this.transform.position.x > leftEdge.x + 1f)
        {
            this.transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow) && this.transform.position.x < rightEdge.x - 1f)
        {
            this.transform.position += Vector3.right * speed * Time.deltaTime;
        }

        // Laser Shooting
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shoot();
        }
    }

    private void shoot()
    {
        Laser laser = Instantiate(this.laser, this.transform);
    }
}
