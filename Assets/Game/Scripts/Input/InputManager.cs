using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    [Header("Events")]
    public UnityEvent<Vector3> onPlayerInput; 

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical);

        if (direction.magnitude > 0.1f)
        {
            onPlayerInput?.Invoke(direction.normalized);
        }
        else
        {
            onPlayerInput?.Invoke(Vector3.zero); 
        }
    }
}
