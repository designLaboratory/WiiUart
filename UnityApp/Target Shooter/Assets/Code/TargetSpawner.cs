using UnityEngine;
using System.Collections.Generic;

public class TargetSpawner : MonoBehaviour {

    [SerializeField] GameObject target;
    static System.Random rand = new System.Random();
    static TargetSpawner instance;

    public static void RespawnTarget()
    {
        GameObject newTarget = Instantiate(instance.target);
        newTarget.transform.position = GetRandomPosition(newTarget.transform.position.y);
    }

    static Vector3 GetRandomPosition(float y)
    {
        float x = 50 * rand.Next(0, 10); float z = 50 * rand.Next(3, 10);
        return new Vector3(x, y, z);
    }

    void Awake()
    {
        instance = this;
    }
}
