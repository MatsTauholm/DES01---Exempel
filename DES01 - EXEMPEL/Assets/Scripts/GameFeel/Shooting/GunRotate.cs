using UnityEngine;

public class GunRotate : MonoBehaviour
{
    void Update()
    {
        RotateGunToMouse();
    }

    void RotateGunToMouse()
    {
        // Get mouse position in world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate direction from gun to mouse
        Vector2 direction = (mousePosition - transform.position).normalized;

        // Calculate angle in degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Apply rotation to the gun
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}

