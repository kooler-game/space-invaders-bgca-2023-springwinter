using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 1f;
    public Laser laser;
    private bool isCooldown = false;
    public float firerate = 2.0f;

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
        if (Input.GetKey(KeyCode.Space))
        {
            shoot();
        }
    }

    private void shoot()
    {
        if (isCooldown)
        {
            return;
        }
        Invoke(nameof(setCooldown), firerate);

        Laser laser = Instantiate(this.laser, this.transform.position, Quaternion.identity);
        this.isCooldown = true;
    }

    private void setCooldown()
    {
        this.isCooldown = false;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Missile") || other.gameObject.layer == LayerMask.NameToLayer("Invader"))
        {
            // TODO: Reduce HP
            GameManager.Instance.GameOver();
            Destroy(this.gameObject);

            return;
        }
    }
}
