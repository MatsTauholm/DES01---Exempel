using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Sawblade : MonoBehaviour
{
    [SerializeField] Transform sawblade;
    [SerializeField] float moveTime = 2;
    [SerializeField] float rotateTime = 2;
    [SerializeField] DG.Tweening.Ease linearEase;
    [SerializeField] DG.Tweening.Ease angularEase;
    void Start()
    {
        sawblade.transform.DOLocalMove(new Vector3(5,0,0),moveTime)
            .SetEase(linearEase)
            .SetLoops(-1, LoopType.Yoyo);
        sawblade.transform.DOLocalRotate(new Vector3(0,0,360),rotateTime,RotateMode.FastBeyond360)
            .SetEase(angularEase)
            .SetLoops(-1, LoopType.Restart);    
    }

}
