using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed = 5f;
    public Vector3 _direction = Vector3.up;

    void Update()
    {
        this.transform.position += this.speed * Time.deltaTime * this._direction;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(this.gameObject);
    }
}
