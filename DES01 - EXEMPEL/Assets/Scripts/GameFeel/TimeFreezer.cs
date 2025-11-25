using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeFreezer : MonoBehaviour
{
    private  bool _isFrozen = false;
    private  TimeFreezer _instance;

    
    public void Freeze(float duration)
    {
        if (!_isFrozen)
        {
            StartCoroutine(DoFreeze(duration));
        }

    }

    IEnumerator DoFreeze(float duration)
    {
        _isFrozen = true;
        var orgTimeScale = Time.timeScale;
        Time.timeScale = 0;

        yield return new WaitForSecondsRealtime(duration);

        Time.timeScale = orgTimeScale;
        _isFrozen = false;
    }
}
