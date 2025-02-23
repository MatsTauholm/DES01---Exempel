using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Sawblade : MonoBehaviour
{
    [SerializeField] Transform bigSawblade;
    [SerializeField] Transform smallSawblade;
    [SerializeField] float moveTime = 2;
    [SerializeField] float bigRotateTime = 2;
    [SerializeField] float smallRotateTime = 2;
    [SerializeField] DG.Tweening.Ease linearEase;
    [SerializeField] DG.Tweening.Ease angularEase;

    void Start()
    {
        bigSawblade.transform.DOMove(new Vector3(10,0,0),moveTime).SetEase(linearEase).SetLoops(-1, LoopType.Yoyo);
        bigSawblade.transform.DORotate(new Vector3(0,0,360),bigRotateTime,RotateMode.FastBeyond360).SetEase(angularEase).SetLoops(-1, LoopType.Restart);

        smallSawblade.transform.DOMove(new Vector3(10, 0, 0), moveTime).SetEase(linearEase).SetLoops(-1, LoopType.Yoyo);
        smallSawblade.transform.DORotate(new Vector3(0, 0, 360), smallRotateTime, RotateMode.FastBeyond360).SetEase(angularEase).SetLoops(-1, LoopType.Restart);
    }

}
