using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InfoLabelController : MonoBehaviour {

    [SerializeField] Text infoLabel;
    static InfoLabelController instance;
    const string LABEL = "Time is up. Your result: {0} targets hit.";

    public static void ShowInfo()
    {
        instance.infoLabel.text = string.Format(LABEL, TargetCounterController.GetCounterValue());
        instance.infoLabel.gameObject.SetActive(true);
    }

    void Awake()
    {
        instance = this;
        gameObject.SetActive(false);
    }
}
