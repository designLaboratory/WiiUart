using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;

public class TimeLeftController : MonoBehaviour {

    [SerializeField] Text timeLeftLabel;
    const string LABEL = "TIME LEFT: ";
    public static bool isDone;
    float delay;
    
    void Update()
    {
        if (delay >= 1f && !isDone)
            timeLeftLabel.text = LABEL + GetUpdatedTime();
        else
            delay += Time.deltaTime;
    }

    string GetUpdatedTime()
    {
        List<int> time = timeLeftLabel.text.Substring(11, 4).Split(new string[] { ":" }, System.StringSplitOptions.RemoveEmptyEntries).Select(s => int.Parse(s)).ToList();
        if (time[0] == 1 && time[1] == 0) { time[0]--; time[1] = 59; }
        else time[1]--; delay = 0;
        if (time[0] == 0 && time[1] == 0) { isDone = true; InfoLabelController.ShowInfo(); }
        return time[0] + ":" + GetFixedSeconds(time[1]);
    }

    string GetFixedSeconds(int seconds)
    {
        return seconds > 9 ? seconds.ToString() : "0" + seconds.ToString();
    }
}
