using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public float knockbackTime = 0.2f;
    public float hitDirectionForce = 10f;
    public float constForce = 5f;
    public float inputForce = 7.5f;

    public bool IsBeingKnockedBack = false;

    public IEnumerator Knockback(Vector2 hitDirection, Vector2 constantForeceDirection, float inputDirection)
    {
        IsBeingKnockedBack = true;

        Vector2 _hitForce;
        Vector2 _constantForce;
        Vector2 _knockbackForce;
        Vector2 _combinedForce;

        _hitForce = hitDirection * hitDirectionForce;
        _constantForce = constantForeceDirection * constForce;

        float _elapsedTime = 0f;
        while (_elapsedTime < knockbackTime)
        {
            //iterate timer
            _elapsedTime += Time.fixedDeltaTime;

            //combine _hitForce and _constantForece
            _knockbackForce = _hitForce + _constantForce;

            yield return new WaitForFixedUpdate();

        }

        IsBeingKnockedBack = false;
    }

}
