using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour
{

    float delay = 0;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Target")
            DestroyObjects(col);
    }

    void DestroyObjects(Collision col)
    {
        Destroy(col.transform.parent.gameObject);
        Destroy(gameObject);
        TargetCounterController.UpdateCounter(1);
        TargetSpawner.RespawnTarget();
    }

    void Update()
    {
        if (delay > 3f) { Destroy(gameObject); delay = 0; }
        else delay += Time.deltaTime;
    }
}
