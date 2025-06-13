using UnityEngine;

public class GunKickback : MonoBehaviour
{
    private Animator ani;

    private void Start()
    {
        ani = GetComponent<Animator>();
    }

    public void PlayKickback()
    {
        if (ani != null)
        {
            ani.SetTrigger("Kickback");
        }
    }
}
