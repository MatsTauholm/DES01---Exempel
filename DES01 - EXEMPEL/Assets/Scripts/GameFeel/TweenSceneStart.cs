using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;

public class TweenSceneStart : MonoBehaviour
{
    [SerializeField] float xMinRange, xMaxRange, yMinRange, yMaxRange, tweenTime;
    //Vector2 startPositions;
    string objectTag = "Resetable";
    // A dictionary to store the objects and their start positions
    private Dictionary<GameObject, Vector3> startPositions = new Dictionary<GameObject, Vector3>();

    private void Awake()
    {
        EffectManager effectManager = FindFirstObjectByType<EffectManager>();
        if (effectManager.LevelTween == false)
        {
            this.enabled = false;
        }
        else
        {
            this.enabled = true;
        }
    }


    void Start()
    {
        GameObject[] objectsToReset = GameObject.FindGameObjectsWithTag(objectTag);
        foreach (var obj in objectsToReset)
        {
            startPositions[obj] = obj.transform.position;
        }
        foreach (var obj in objectsToReset)
        {
            obj.transform.position = new Vector2(Random.Range(xMinRange, xMaxRange), Random.Range(yMinRange, yMaxRange));
        }
        //transform.position = new Vector2(Random.Range(xMinRange, xMaxRange), Random.Range(yMinRange, yMaxRange));
        // Reset positions using DoTween
        //ResetToStartPositions();
        ResetToStartPositionsSequentially();
    }

    void ResetToStartPositions()
    {
        // Animate movement to the start position over time
        foreach (var kvp in startPositions)
        {
            GameObject obj = kvp.Key;
            Vector2 startPosition = kvp.Value;
            obj.transform.DOMove(startPositions[obj], tweenTime).SetEase(Ease.InOutQuad);
        }
   
    }
    void ResetToStartPositionsSequentially()
    {
        // Create a sequence
        Sequence sequence = DOTween.Sequence();

        foreach (var kvp in startPositions)
        {
            GameObject obj = kvp.Key;
            Vector2 startPosition = kvp.Value;
            if (startPositions.ContainsKey(obj))
            {
                // Add a tween to the sequence for each object
                sequence.Append(obj.transform.DOMove(startPositions[obj], 0.3f).SetEase(Ease.InOutQuad));
            }
        }

        // Optionally, add a callback when all animations are done
        sequence.OnComplete(() => Debug.Log("All objects moved to start positions!"));
    }
}
