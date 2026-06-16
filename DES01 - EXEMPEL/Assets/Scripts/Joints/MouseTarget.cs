using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseTarget : MonoBehaviour
{
	[SerializeField] bool ClickToMove = false;
	TargetJoint2D targetJoint;

	void Start()
	{
		targetJoint = GetComponent<TargetJoint2D> ();
	} 

    private void Update()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            MoveToMousePosition();
        } 
    }

	public void MoveToMousePosition()
    {
            // Finish if no joint detected.
            if (targetJoint == null)
                return;

            // Calculate the world position for the mouse.
            var worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Set the joint target.
            targetJoint.target = worldPos;

    }

	void FixedUpdate ()
	{
        if (ClickToMove == false)
        {
            // Finish if no joint detected.
            if (targetJoint == null)
                return;

            // Calculate the world position for the mouse.
            var worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Set the joint target.
            targetJoint.target = worldPos;
        }
	}
}
