using UnityEngine;
using TMPro;
public class TimeManager : MonoBehaviour
{
   

    public static float oldTime = 0;
    public static bool ifTimeIs(float wantedTime, ref bool taskDone)
    {
        float currentTime = Time.timeSinceLevelLoad;
        float futureTime = currentTime + Time.fixedDeltaTime;
        bool ifReachedTime = currentTime < wantedTime && wantedTime <= futureTime;
        if (ifReachedTime && !taskDone)
        {
            // We check if our task is done so we only call this once.
            taskDone = true;
            return true;
        }
        return false;
    }
}
