using UnityEngine;
using System.Collections.Generic;

public static class Waiters
{
    private const float DefaultRandomWaitPrecision = 0.1f;

    private static readonly Dictionary<float, WaitForSeconds> _timeIntervals = new Dictionary<float, WaitForSeconds>();
    private static readonly Dictionary<float, WaitForSecondsRealtime> _timeIntervalsRealtime = new Dictionary<float, WaitForSecondsRealtime>();
    private static readonly WaitForFixedUpdate _fixedUpdate = new WaitForFixedUpdate();
    private static readonly WaitForEndOfFrame _endOfFrame = new WaitForEndOfFrame();
    private static readonly System.Random _random = new System.Random();

    public static WaitForEndOfFrame EndOfFrame => _endOfFrame;
    public static WaitForFixedUpdate FixedUpdate => _fixedUpdate;

    // Clears only the cached timed waits. Frame-based waiters are reused safely.
    public static void ClearCache()
    {
        _timeIntervals.Clear();
        _timeIntervalsRealtime.Clear();
    }

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
        return WaitRandom(min, max, DefaultRandomWaitPrecision);
    }

    public static WaitForSeconds WaitRandom(float min, float max, float precision)
    {
        // A non-positive precision opts out of caching for exact random durations.
        if (precision <= 0f)
        {
            float uncachedSeconds = Mathf.Lerp(min, max, (float)_random.NextDouble());
            return new WaitForSeconds(uncachedSeconds);
        }

        // Quantize random waits into a limited number of buckets so the cache can be reused.
        float range = Mathf.Abs(max - min);
        int steps = Mathf.Max(1, Mathf.RoundToInt(range / precision));
        float randomSeconds = Mathf.Lerp(min, max, _random.Next(steps + 1) / (float)steps);
        return Wait(randomSeconds);
    }
}
