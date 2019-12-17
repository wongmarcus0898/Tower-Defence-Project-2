using UnityEngine;

public class ShootCannon : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 screenBounds;

    public float velocity = 10f;
    public float pushBackPower;
    public int damage;

    private void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        Throw();
    }

    private void FixedUpdate()
    {
        if (transform.position.y > screenBounds.y * 1.5 || transform.position.y < -screenBounds.y * 1.1 || transform.position.x > screenBounds.x * 1.1 || transform.position.x < -screenBounds.x * 1.1)
        {
            Destroy(gameObject);
        }
    }

    void Throw()
    {
        float xPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
        float yPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;

        float radian = Mathf.Atan(yPosition / xPosition);

        float xVelo, yVelo;
        xVelo = velocity * Mathf.Cos(radian);
        yVelo = velocity * Mathf.Sin(radian);

        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-xVelo, -yVelo);
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
