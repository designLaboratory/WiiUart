using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class StartGameController : MonoBehaviour {

    [SerializeField] WeaponController weaponController;
    [SerializeField] TimeLeftController timeLeftController;

    void Start()
    {
        InfoLabelController.ShowStartGameInfo();
    }

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            StartGame();
	}

    void StartGame()
    {
        InfoLabelController.Hide();
        TimeLeftController.gameStarted = true;
        weaponController.enabled = true;
        TargetCounterController.ClearCounter();
        AmmoCounterController.ClearCounter();
        if (timeLeftController.GetCurrentTime() == "0:00")
            DestroyOldTargets();
        timeLeftController.SetStartTime();
    }

    void DestroyOldTargets()
    {
        List<GameObject> targets = GameObject.FindGameObjectsWithTag("Target").ToList();
        foreach(GameObject t in targets) Destroy(t);
        for (int i = 0; i < 4; i++)
            TargetSpawner.RespawnTarget();
    }
}
