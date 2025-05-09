using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeFreezer : MonoBehaviour
{
    [SerializeField] float duration = 0.7f;
    bool _isFrozen = false;
    
    public void Freeze()
    {
        if (!_isFrozen)
        {
            StartCoroutine(DoFreeze());
        }

    }
    IEnumerator DoFreeze()
    {
        _isFrozen = true;
        var orgTimeScale = Time.timeScale;
        Time.timeScale = 0;

        yield return new WaitForSecondsRealtime(duration);

        Time.timeScale = orgTimeScale;
        _isFrozen = false;
    }
}
