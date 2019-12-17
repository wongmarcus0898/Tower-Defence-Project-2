using System.Collections;
using UnityEngine;
using EZCameraShake;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float waitTime = 1;

    private float jumpVelocity;
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(jump());
    }
    IEnumerator jump()
    {
        while(true)
        {
            jumpVelocity = Random.Range(3, 6);
            yield return new WaitForSeconds(waitTime);
            rb.velocity = new Vector2(moveSpeed, jumpVelocity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 1f);
            Destroy(gameObject);
        }
    }
}
