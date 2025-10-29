using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class CameraShakeManager : MonoBehaviour
{
    public static CameraShakeManager instance;
    [SerializeField] private float globalShakeForce = 1f;
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

   public void CameraShake(CinemachineImpulseSource impulseSource)
    {
        impulseSource.GenerateImpulseWithForce(globalShakeForce);
    }
  
}
