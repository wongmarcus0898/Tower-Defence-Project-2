using UnityEngine;
using EZCameraShake;
public class ZombieMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private PushBack pb;

    private bool isGround = false;

    public float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pb = GetComponent<PushBack>();
    }

    private void FixedUpdate()
    {
        if (isGround && !pb.isPushedBack) movement();
    }
    void movement()
    {
        rb.velocity = new Vector2(speed, 0);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform") isGround = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform") isGround = true;

        if (collision.gameObject.tag == "Player")
        {
            CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 1f);
            Destroy(gameObject);
        }
    }
}
