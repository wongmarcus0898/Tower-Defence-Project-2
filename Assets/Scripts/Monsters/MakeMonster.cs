using UnityEngine;

public class MakeMonster : MonoBehaviour
{
    public GlobalCoolDown cd;

    public GameObject prefab;
    public Transform spawner;
    public Vector2 monsterScale;
    private void Start()
    {
        cd.GetComponent<GlobalCoolDown>();
    }
    public void spawn()
    {
        if (cd.onCoolDown == false)
        {
            StartCoroutine(cd.spawnTimer());
            GameObject a = Instantiate(prefab, spawner.position, spawner.rotation) as GameObject;
            a.transform.localScale = monsterScale;
        }

    }
}