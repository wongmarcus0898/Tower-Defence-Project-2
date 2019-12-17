using UnityEngine;

public class ChooseWeapon : MonoBehaviour
{
    public int currentWeapon = 0;
    private void Start()
    {
        SelectWeapon();
    }
    void Update()
    {
        int previousWeapon = currentWeapon;

        if (Input.GetKeyDown(KeyCode.Alpha1)) currentWeapon = 0;
        if (Input.GetKeyDown(KeyCode.Alpha2)) currentWeapon = 1;

        if (previousWeapon != currentWeapon) SelectWeapon();
    }

    void SelectWeapon()
    {
        int i = 0;

        foreach (Transform weapon in transform)
        {
            if (i == currentWeapon)
            {
                weapon.gameObject.SetActive(true);
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
