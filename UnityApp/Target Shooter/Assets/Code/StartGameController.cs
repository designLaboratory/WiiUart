using UnityEngine;
using System.Collections;

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
        timeLeftController.SetStartTime();
        Application.LoadLevel(0);
    }
}
