using System.Collections;
using UnityEngine;

public class PushBack : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool isPushedBack = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    public void pushBack(float power)
    {
        Debug.Log(power);
        rb.velocity = new Vector2(power, 1f);
        StartCoroutine(duration(.1f));
    }

    IEnumerator duration(float time)
    {
        isPushedBack = true;
        yield return new WaitForSeconds(time);
        isPushedBack = false;
    }
}