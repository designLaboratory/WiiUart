using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AmmoCounterController : MonoBehaviour {

    [SerializeField] Text ammoCounterLabel;
    const string LABEL = "AMMO LEFT: ";
    static AmmoCounterController instance;

    public static void SetAmount(int value)
    {
        int currentValue = int.Parse(instance.ammoCounterLabel.text.Substring(11, instance.ammoCounterLabel.text.Length - 11)) - value;
        instance.ammoCounterLabel.text = LABEL + currentValue.ToString();
        if (currentValue == 0) InfoLabelController.ShowReloadInfo();
    }

    public static int GetCounterValue()
    {
        return int.Parse(instance.ammoCounterLabel.text.Substring(11, instance.ammoCounterLabel.text.Length - 11));
    }

    public static void ClearCounter() 
    {
        instance.ammoCounterLabel.text = LABEL + "10";
        InfoLabelController.Hide();
    }

    void Awake()
    {
        instance = this;
    }
}
