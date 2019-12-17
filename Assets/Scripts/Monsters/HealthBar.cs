using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Transform bar;
    private float healthPercentage = 1f;
    void Start()
    {
        bar = transform.Find("Bar");
    }
    public void SetSize(float health)
    {
        healthPercentage -= (1 / health);
        bar.localScale = new Vector2(healthPercentage, 1f);
    }
}
