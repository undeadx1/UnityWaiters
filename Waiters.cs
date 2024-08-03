using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public static class Waiters
{
    private static readonly Dictionary<float, WaitForSeconds> _timeIntervals = new Dictionary<float, WaitForSeconds>();
    private static readonly Dictionary<float, WaitForSecondsRealtime> _timeIntervalsRealtime = new Dictionary<float, WaitForSecondsRealtime>();
    private static readonly WaitForFixedUpdate _fixedUpdate = new WaitForFixedUpdate();
    private static readonly WaitForEndOfFrame _endOfFrame = new WaitForEndOfFrame();
    private static readonly Random _random = new Random();

    public static WaitForEndOfFrame EndOfFrame => _endOfFrame;
    public static WaitForFixedUpdate FixedUpdate => _fixedUpdate;

    public static WaitForSeconds Wait(float seconds)
    {
        if (!_timeIntervals.TryGetValue(seconds, out var wait))
        {
            wait = new WaitForSeconds(seconds);
            _timeIntervals[seconds] = wait;
        }
        return wait;
    }

    public static WaitForSecondsRealtime WaitRealtime(float seconds)
    {
        if (!_timeIntervalsRealtime.TryGetValue(seconds, out var wait))
        {
            wait = new WaitForSecondsRealtime(seconds);
            _timeIntervalsRealtime[seconds] = wait;
        }
        return wait;
    }

    public static WaitForSeconds WaitRandom(float min, float max)
    {
        float randomSeconds = Mathf.Lerp(min, max, (float)_random.NextDouble());
        return Wait(randomSeconds);
    }
}
