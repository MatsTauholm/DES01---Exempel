using UnityEngine;
using System.Collections.Generic;

public class EffectManager : MonoBehaviour
{
    public bool LevelTween = false;
    public static EffectManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
}
