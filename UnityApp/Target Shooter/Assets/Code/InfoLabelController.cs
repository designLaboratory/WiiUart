using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InfoLabelController : MonoBehaviour {

    [SerializeField] Text infoLabel;
    [SerializeField] WeaponController weaponController;
    static InfoLabelController instance;
    const string LABEL = "Time is up. Your result: {0} targets hit.";
    const string START_GAME = "Press 'Space' to start...";

    public static void ShowInfo()
    {
        instance.infoLabel.text = string.Format(LABEL, TargetCounterController.GetCounterValue());
        instance.infoLabel.gameObject.SetActive(true);
        instance.weaponController.enabled = false;
        instance.Invoke("ShowNewGameInfo", 3f);
    }

    public static void ShowStartGameInfo()
    {
        instance.infoLabel.text = START_GAME;
        instance.infoLabel.gameObject.SetActive(true);
    }

    public static void Hide()
    {
        instance.infoLabel.gameObject.SetActive(false);
    }

    void ShowNewGameInfo()
    {
        ShowStartGameInfo();
    }

    void Awake()
    {
        instance = this;
    }
}
