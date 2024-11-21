using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;

public class TweenSceneStart : MonoBehaviour
{
    // A dictionary to store the objects and their start positions
    Vector2 startPositions;

    // Assign this in the inspector or find objects dynamically
    

    void Start()
    { 
        startPositions = transform.position;
        transform.position = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
        // Reset positions using DoTween
        ResetToStartPositions();
    }

    void ResetToStartPositions()
    {
        // Animate movement to the start position over 1 second
        transform.DOMove(startPositions, 1f).SetEase(Ease.InOutQuad);
   
    }
}
