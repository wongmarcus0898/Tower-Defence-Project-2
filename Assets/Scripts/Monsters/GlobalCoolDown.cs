using System.Collections;
using UnityEngine;

public class GlobalCoolDown : MonoBehaviour
{
    public float coolDownTimer = 1f;

    public bool onCoolDown = false;

    public IEnumerator spawnTimer()
    {
        if (onCoolDown == false)
        {
            onCoolDown = true;
            yield return new WaitForSeconds(coolDownTimer);
            onCoolDown = false;
        }
    }
}