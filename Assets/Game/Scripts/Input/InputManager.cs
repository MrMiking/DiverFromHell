using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    [Header("Events")]
    public UnityEvent<Vector3> onPlayerInput; // Event to send player input direction

    private void Update()
    {
        // Get player input (assuming WASD or arrow keys for simplicity)
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Compute direction
        Vector3 direction = new Vector3(horizontal, 0f, vertical);

        // Normalize direction and invoke event
        if (direction.magnitude > 0.1f)
        {
            onPlayerInput?.Invoke(direction.normalized);
        }
        else
        {
            onPlayerInput?.Invoke(Vector3.zero); // Stop the tank when no input
        }
    }
}
