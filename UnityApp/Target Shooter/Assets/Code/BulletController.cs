using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

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
}
