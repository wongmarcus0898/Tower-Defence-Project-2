using System.Collections;
using UnityEngine;

public class MakeBullet : MonoBehaviour
{
    [SerializeField] private ReloadBar reloadbar;

    public GameObject prefab;
    public Transform firePoint;

    public float reloadSpeed = 1f;
    public int maxAmmo = 3;
    public Vector2 scale;

    private int ammunition;
    private bool isReloading = false;

    private void Start()
    {
        ammunition = maxAmmo;
    }
    private void OnEnable()
    {
        isReloading = false;
    }
    void Update()
    {
        if (isReloading) return;

        if (ammunition <= 0 && Input.GetMouseButtonDown(0) || (Input.GetKeyDown(KeyCode.R) && ammunition < maxAmmo))
        {
            StartCoroutine(reload());
            return;
        }

        if (Input.GetMouseButtonDown(0) && ammunition != 0 && Input.mousePosition.y >= 100f)
        {
            spawn();
            ammoCount();
        }
    }

    void spawn()
    {
        GameObject a = Instantiate(prefab, firePoint.position, firePoint.rotation);
        a.transform.localScale = scale;
    }
    
    void ammoCount()
    {
        reloadbar.SetSize(maxAmmo);
        ammunition--;
    }

    IEnumerator reload()
    {
        Debug.Log("RELOADING...");
        isReloading = true;
        yield return new WaitForSeconds(reloadSpeed);
        reloadbar.reloading();
        ammunition = maxAmmo;
        isReloading = false;
        Debug.Log("RELOAD COMPLETE");
    }
}
