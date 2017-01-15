using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TargetCounterController : MonoBehaviour {

    [SerializeField] Text hitCounterLabel;
    static TargetCounterController instance;
    const string LABEL = "TARGETS HIT: ";

    public static void UpdateCounter(int value)
    {
        int currentValue = int.Parse(instance.hitCounterLabel.text.Substring(13, instance.hitCounterLabel.text.Length - 13)) + value;
        instance.hitCounterLabel.text = LABEL + currentValue.ToString();
    }

    public static int GetCounterValue()
    {
        return int.Parse(instance.hitCounterLabel.text.Substring(13, instance.hitCounterLabel.text.Length - 13));
    }

    public static void ClearCounter() { instance.hitCounterLabel.text = LABEL + "0"; }

    void Awake()
    {
        instance = this;
    }
}