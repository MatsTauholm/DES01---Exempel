using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Unity.VisualScripting;

public class EvilHead : MonoBehaviour
{
    [SerializeField] Transform[] ninjaStars;
    [SerializeField] Vector2 aimPosition;
    [SerializeField] float minMoveTime, maxMoveTime;

    void Start()
    {
        ShootStars();
    }

    void ShootStars()
    {
        var sequence = DOTween.Sequence();

        foreach (var ninjaStar in ninjaStars)
        {
            sequence.Append(ninjaStar.DOMove(aimPosition, Random.Range(minMoveTime, maxMoveTime)));
            aimPosition.y += 3;
        }

        sequence.OnComplete(Fade);
    }

    void Fade()
    {
        foreach (var ninjaStar in ninjaStars)
        {
            ninjaStar.DOShakeScale(0.5f, 10, 10, 90, true);
            ninjaStar.DOScale(Vector3.zero, 0.5f).SetDelay(1f).SetEase(Ease.InFlash);
        }
    }
}

