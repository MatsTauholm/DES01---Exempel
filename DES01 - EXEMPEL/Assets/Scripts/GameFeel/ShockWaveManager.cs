using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShockWaveManager : MonoBehaviour
{
    [SerializeField] private float shockWaveTime = 0.75f;
    private Coroutine shockWaveCoroutine;
    private Material material;
    private static int _waveDistanceFromCenter = Shader.PropertyToID("_WaveDistanceFromCenter");

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    private void Update()
    {
        if(Keyboard.current.eKey.wasPressedThisFrame)
        {
            CallShockWave();
        }
    }

    public void CallShockWave()
    {
        shockWaveCoroutine = StartCoroutine(ShockWave(-0.1f, 1f));
    }

    private IEnumerator ShockWave(float startPos, float endPos)
    {
        material.SetFloat(_waveDistanceFromCenter, startPos);
        float lerpedAmount = 0f;

        float elapsedTime = 0f;

        while (elapsedTime < shockWaveTime)
        {
            elapsedTime += Time.deltaTime;
            lerpedAmount = Mathf.Lerp(startPos, endPos, (elapsedTime / shockWaveTime));
            material.SetFloat(_waveDistanceFromCenter, lerpedAmount);

            yield return null;

        }
    }
}
