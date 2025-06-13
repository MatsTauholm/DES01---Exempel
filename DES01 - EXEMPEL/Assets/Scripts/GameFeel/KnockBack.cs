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
    public AnimationCurve knockbackForceCurve;

    private Rigidbody2D rb;

    private Coroutine knockbackCoroutine;

    public bool isBeingKnockedBack = false;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public IEnumerator Knockback(Vector2 hitDirection, Vector2 constantForeceDirection, float inputDirection)
    {
        isBeingKnockedBack = true;

        Vector2 _hitForce;
        Vector2 _constantForce;
        Vector2 _knockbackForce;
        Vector2 _combinedForce;
        float _time = 0f;

        
        _constantForce = constantForeceDirection * constForce;

        float _elapsedTime = 0f;
        while (_elapsedTime < knockbackTime)
        {
            //Iterate timers
            _elapsedTime += Time.fixedDeltaTime;
            _time += Time.fixedDeltaTime;

            //Update hitForce
            _hitForce = hitDirection * hitDirectionForce * knockbackForceCurve.Evaluate(_time);

            //Combine _hitForce and _constantForece
            _knockbackForce = _hitForce + _constantForce;

            //Combine knockbackForce with inputdirection
            if(inputDirection != 0)
            {
                _combinedForce = _knockbackForce + new Vector2(inputDirection, 0f);
            }
            else
            {
                _combinedForce = _knockbackForce;
            }

            //Apply knockback
            rb.linearVelocity = _combinedForce;

            yield return new WaitForFixedUpdate();

        }

        isBeingKnockedBack = false;
    }

    public void CallKnockBack(Vector2 hitDirection, Vector2 constantForeceDirection, float inputDirection)
    {
        knockbackCoroutine = StartCoroutine(Knockback(hitDirection, constantForeceDirection, inputDirection));
    }

}
