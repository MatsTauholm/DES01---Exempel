using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EvilHead : MonoBehaviour
{
    [SerializeField] Transform[] ninjaStars;
    [SerializeField] Vector2 aimPosition;
    void Start()
    {
        var sequence = DOTween.Sequence();

        foreach (var ninjaStar in ninjaStars)
        {
            sequence.Append(ninjaStar.DOMove(aimPosition, Random.Range(1f, 2f)));
            aimPosition.y += 3;
        }

        sequence.OnComplete(() =>
        {
            foreach (var ninjaStar in ninjaStars)
            {
                ninjaStar.DOScale(Vector3.zero, 0.5f).SetDelay(1f).SetEase(Ease.InFlash);
            }
        });




        //ninjaStars[0].DOMove(new Vector2(5, 0), Random.Range(1f, 2f)).OnComplete(() =>
        //{
        //    ninjaStars[1].DOMove(new Vector2(5, 3), Random.Range(1f, 2f)).OnComplete(() =>
        //    {
        //        ninjaStars[2].DOMove(new Vector2(5, -3), Random.Range(1f, 2f)).OnComplete(() =>
        //        {
        //            foreach (var ninjaStar in ninjaStars)
        //            {
        //                ninjaStar.DOScale(Vector3.zero, 0.5f).SetDelay(1f).SetEase(Ease.InFlash);   
        //            }
        //        });

        //    });
        //});
    }





}
