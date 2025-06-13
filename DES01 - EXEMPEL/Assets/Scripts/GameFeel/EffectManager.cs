using UnityEngine;
using System.Collections.Generic;

public class EffectManager : MonoBehaviour
{
    public static EffectManager Instance { get; private set; }

    [System.Serializable]
    public class EffectEntry
    {
        public string effectName;
        public GameObject effectObject; // Any GameObject: post-processing, VFX, etc.
    }

    [Header("Effect References")]
    public List<EffectEntry> effects = new List<EffectEntry>();

    private Dictionary<string, GameObject> effectMap;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        effectMap = new Dictionary<string, GameObject>();
        foreach (var entry in effects)
        {
            if (!effectMap.ContainsKey(entry.effectName) && entry.effectObject != null)
            {
                effectMap.Add(entry.effectName, entry.effectObject);
            }
        }
    }

    public void SetEffectActive(string effectName, bool isActive)
    {
        if (effectMap.TryGetValue(effectName, out GameObject obj))
        {
            obj.SetActive(isActive);
        }
    }

    public bool IsEffectActive(string effectName)
    {
        return effectMap.TryGetValue(effectName, out GameObject obj) && obj.activeSelf;
    }

    public void ToggleEffect(string effectName)
    {
        if (effectMap.TryGetValue(effectName, out GameObject obj))
        {
            obj.SetActive(!obj.activeSelf);
        }
    }

    public List<string> GetAllEffectNames()
    {
        return new List<string>(effectMap.Keys);
    }
}
