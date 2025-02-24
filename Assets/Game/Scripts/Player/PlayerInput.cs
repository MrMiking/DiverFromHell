using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private RSO_InputShoot inputShoot;

    private void Update()
    {
        inputShoot.Value = Input.GetKey(KeyCode.Mouse0);
    }

    public bool GetShootInput => Input.GetKey(KeyCode.Mouse0);
    public Vector3 GetMovementInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        return new Vector3(horizontal, 0, vertical).normalized;
    }
}
