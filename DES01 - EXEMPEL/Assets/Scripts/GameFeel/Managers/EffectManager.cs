using UnityEngine;
using System.Collections.Generic;

public class EffectManager : MonoBehaviour
{
    public bool LevelTween = false;
    public bool multiShot = false;
    public bool bulletSpread = false;

    public static EffectManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
    public void Test()
    {

    }
}
