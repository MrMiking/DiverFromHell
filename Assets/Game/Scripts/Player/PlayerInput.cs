using UnityEngine;
public class PlayerInput : MonoBehaviour
{
    public bool GetShootInput => Input.GetKeyDown(KeyCode.Mouse0);

    public Vector3 GetMovementInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        return new Vector3(horizontal, 0, vertical).normalized;
    }
}