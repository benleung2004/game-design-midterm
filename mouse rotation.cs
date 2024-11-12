using UnityEngine;

public class CannonRotation : MonoBehaviour
{
    public Transform tankTransform;  // Reference to the tank's transform
    public Camera mainCamera;        // Reference to the main camera

    void Update()
    {
        RotateCannonTowardsMouseWithOriginCenter();
    }

    void RotateCannonTowardsMouseWithOriginCenter()
    {
        // Get the mouse position in screen space
        Vector3 mouseScreenPosition = Input.mousePosition;

        // Convert mouse screen position to world space with (0, 0, 0) as the center reference
        // To achieve this, set the distance from the camera to zero position relative to the center
        mouseScreenPosition.z = Vector3.Distance(mainCamera.transform.position, Vector3.zero);
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mouseScreenPosition);

        // Calculate the direction from the cannon to the mouse position, considering (0, 0, 0) as the origin center
        Vector3 direction = mouseWorldPosition - tankTransform.position;
        direction.y = 0; // Optional: Keep the cannon rotation on the horizontal plane

        // Rotate the cannon to face the direction based on the mouse position in relation to the origin center
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = targetRotation;
        }
    }
}
