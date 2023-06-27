using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Waiters
{
    static Dictionary<(float, int), WaitForSeconds> timeInterval = new Dictionary<(float, int), WaitForSeconds>(500);
    static Dictionary<(float, int), WaitForSecondsRealtime> timeIntervalRealtime = new Dictionary<(float, int), WaitForSecondsRealtime>(500);
    static WaitForFixedUpdate fixedUpdate = new WaitForFixedUpdate();
    static WaitForEndOfFrame endOfFrame = new WaitForEndOfFrame();

    public static WaitForEndOfFrame EndOfFrame
    {
        get { return endOfFrame; }
    }
  
    public static WaitForFixedUpdate FixedUpdate
    {
        get { return fixedUpdate; }
    }
        
    public static WaitForSeconds Wait(float seconds, int instanceID)
    {
        var key = (seconds, instanceID);

        if (timeInterval.ContainsKey(key) == false)
            timeInterval.Add(key, new WaitForSeconds(seconds));

        return timeInterval[key];
    }

    public static WaitForSecondsRealtime WaitRealTime(float seconds, int instanceID)
    {
        var key = (seconds, instanceID);

        if (timeIntervalRealtime.ContainsKey(key) == false)
            timeIntervalRealtime.Add(key, new WaitForSecondsRealtime(seconds));

        return timeIntervalRealtime[key];
    }

    public static WaitForSeconds WaitRandom(float min, float max)
    {
        return new WaitForSeconds(Random.Range(min, max));
    }
}