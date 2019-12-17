using UnityEngine;

public class MouseRotate : MonoBehaviour
{
    public float rotateSpeed = 20.0f;

    private Rigidbody2D rb;
    private float rotate_amount;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        direction.Normalize();

        if (direction.x < 0)
        {
            rotate_amount = Vector3.Cross(direction, transform.up).z;  
        }
        else rotate_amount = 0;

        rb.angularVelocity = -rotate_amount * rotateSpeed;


        float xdistance;
        xdistance = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;

        float ydistance;
        ydistance = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;

        float throwAngle;
        throwAngle = Mathf.Atan((ydistance + 4.905f) / xdistance);

        //Debug.Log(throwAngle * 180 / Mathf.PI);
    }
}