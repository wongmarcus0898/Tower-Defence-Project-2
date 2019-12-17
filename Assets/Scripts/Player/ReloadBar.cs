using UnityEngine;

public class ReloadBar : MonoBehaviour
{
    private Transform bar;
    private float ammoPercentage = 1;
    void Start()
    {
        bar = transform.Find("Bar");
    }
    public void SetSize(float ammo)
    {
        ammoPercentage -= 1 / ammo;
        bar.localScale = new Vector2(ammoPercentage, 1f);
    }

    public void reloading()
    {
        ammoPercentage = 1;
        bar.localScale = new Vector2(ammoPercentage, 1f);
    }
}