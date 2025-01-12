using UnityEngine;

public class RotateTowardsMouse : MonoBehaviour
{
    void Update()
    {
        MouseRotation();
    }

    public void MouseRotation()
    {
        Vector3 mousePosition = GetMousePosition();

        Vector3 worldMousePosition = ConvertMouseToWorldSpace(mousePosition);

        Vector3 direction = CalculateDirection(worldMousePosition);

        Quaternion targetRotation = CalculateTargetRotation(direction);

        ApplyRotation(targetRotation);
    }

    private Vector3 GetMousePosition()
    {
        return Input.mousePosition;
    }

    private Vector3 ConvertMouseToWorldSpace(Vector3 mousePosition)
    {
        float distanceToObject = Vector3.Distance(Camera.main.transform.position, transform.position);

        mousePosition.z = distanceToObject;

        return Camera.main.ScreenToWorldPoint(mousePosition);
    }

    private Vector3 CalculateDirection(Vector3 worldMousePosition)
    {
        return new Vector3(worldMousePosition.x, transform.position.y, worldMousePosition.z) - transform.position;
    }

    private Quaternion CalculateTargetRotation(Vector3 direction)
    {
        return Quaternion.LookRotation(direction);
    }

    private void ApplyRotation(Quaternion targetRotation)
    {
        transform.rotation = targetRotation;
    }
}
