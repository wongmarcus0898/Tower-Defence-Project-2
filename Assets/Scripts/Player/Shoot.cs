using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float speed;
    public float pushBackPower;
    public int damage;

    private Rigidbody2D rb;
    private Vector2 screenBounds;
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.velocity = transform.up * speed;

        if (transform.position.y > screenBounds.y * 1.1 || transform.position.y < -screenBounds.y * 1.1 || transform.position.x > screenBounds.x * 1.1 || transform.position.x < -screenBounds.x * 1.1)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Platform" || other.gameObject.tag == "Enemy")
        {
            OnHit enemy = other.GetComponent<OnHit>();
            PushBack pb = other.GetComponent<PushBack>();

            if (other.gameObject.tag == "Enemy")
            {
                enemy.damageTaken(damage);
                pb.pushBack(pushBackPower);
            }

            Destroy(gameObject);
        }
    }
}
