using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MouseFollower : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private RectTransform uiElement;
    [SerializeField] private Canvas canvas;
    [SerializeField] private Animator animator;
    [SerializeField] private RSO_InputShoot inputShoot;
    [SerializeField] private RSE_OnEnemyKilled onEnemyKilled;

    [Header("References")]
    [SerializeField] private CanvasGroup hitCursor; 

    private void OnEnable()
    {
        inputShoot.OnChanged += ShootCursor;
        onEnemyKilled.action += KillCursor;

        Cursor.lockState = CursorLockMode.Confined;
    }

    private void OnDisable()
    {
        inputShoot.OnChanged -= ShootCursor;
        onEnemyKilled.action -= KillCursor;
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

    private void KillCursor()
    {
        StopAllCoroutines();
        StartCoroutine(KillCursorCoroutine());
    }

    IEnumerator KillCursorCoroutine()
    {
        hitCursor.alpha = 1;
        yield return new WaitForSeconds(0.2f);
        hitCursor.alpha = 0;
    }

    private void OnDestroy()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
