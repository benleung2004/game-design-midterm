using UnityEngine;

public class CannonRotation : MonoBehaviour
{
    public Transform tankTransform;
    public Camera mainCamera;

    void Update()
    {
        RotateCannonTowardsMouseWithOriginCenter();
    }

    void RotateCannonTowardsMouseWithOriginCenter()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = Vector3.Distance(mainCamera.transform.position, Vector3.zero);
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mouseScreenPosition);
        Vector3 direction = mouseWorldPosition - tankTransform.position;
        direction.y = 0;
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = targetRotation;
        }
    }
}
