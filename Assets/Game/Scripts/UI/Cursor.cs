using UnityEngine;
using UnityEngine.UI;

public class MouseFollower : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private RectTransform uiElement;
    [SerializeField] private Canvas canvas;
    [SerializeField] private Animator animator;
    [SerializeField] private RSO_InputShoot inputShoot;

    private void OnEnable()
    {
        inputShoot.OnChanged += ShootCursor;

        Cursor.lockState = CursorLockMode.Confined;
    }

    private void OnDisable()
    {
        inputShoot.OnChanged -= ShootCursor;
    }

    private void Update()
    {
        Cursor.visible = false;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvas.transform as RectTransform,
            Input.mousePosition,
            canvas.worldCamera,
            out Vector2 localPoint
        );

        uiElement.anchoredPosition = localPoint;
    }

    private void ShootCursor()
    {
        if (inputShoot.Value) animator.Play("Shoot");
        else animator.Play("Idle");
    }

    private void OnDestroy()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
