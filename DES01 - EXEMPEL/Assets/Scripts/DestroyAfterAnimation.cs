using UnityEngine;

public class DestroyAfterAnimation : MonoBehaviour
{
    public void DestroyOnAnimationEnd()
    {
        Destroy(gameObject);
    }
}