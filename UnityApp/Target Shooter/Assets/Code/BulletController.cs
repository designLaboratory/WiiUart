using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Target")
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}
