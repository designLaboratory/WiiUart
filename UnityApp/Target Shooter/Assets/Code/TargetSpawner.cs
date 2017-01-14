using UnityEngine;
using System.Collections;

public class TargetSpawner : MonoBehaviour {

    [SerializeField] GameObject target;
    static TargetSpawner instance;

    public static void RespawnTarget()
    {
        GameObject newTarget = Instantiate(instance.target);
        newTarget.transform.position = GetRandomPosition(newTarget.transform.position.y);
    }

    static Vector3 GetRandomPosition(float y)
    {
        System.Random rand = new System.Random(10);
        float x = 50 * rand.Next(); float z = 500 - 50 * rand.Next();
        return new Vector3(x, y, 100 + z);
    }

    void Awake()
    {
        instance = this;
    }
}
