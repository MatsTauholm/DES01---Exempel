using System.Collections.Generic;
using UnityEngine;

public class MechanicManager : MonoBehaviour
{
    [System.Serializable]
    public class MechanicToggle
    {
        public string name;
        public MonoBehaviour mechanicScript; // Must implement IMechanic
        public bool enabled = true;
    }

    public List<MechanicToggle> mechanics = new List<MechanicToggle>();

    void Start()
    {
        foreach (var toggle in mechanics)
        {
            if (toggle.mechanicScript is IMechanic mechanic)
            {
                if (toggle.enabled)
                    mechanic.Enable();
                else
                    mechanic.Disable();
            }
            else
            {
                Debug.LogWarning($"{toggle.name} does not implement IMechanic!");
            }
        }
    }
}
