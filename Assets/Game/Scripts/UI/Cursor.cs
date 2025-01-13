using UnityEngine;
using UnityEngine.UI;

public class MouseFollower : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private RectTransform uiElement; // The UI element to follow the mouse
    [SerializeField] private Canvas canvas;          // The canvas containing the UI element
    [SerializeField] private Vector2 offset;         // Optional offset from the mouse cursor

    private void Start()
    {
        // Hide the system cursor
        Cursor.lockState = CursorLockMode.Confined; // Keep the cursor within the game window
    }

    private void Update()
    {
        Cursor.visible = false;

        if (uiElement == null || canvas == null) return;

        // Convert mouse position to canvas space
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            Input.mousePosition,
            canvas.worldCamera,
            out Vector2 localPoint
        );

        // Apply the position and offset
        uiElement.anchoredPosition = localPoint + offset;
    }

    private void OnDestroy()
    {
        // Restore the system cursor when the script is destroyed
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
