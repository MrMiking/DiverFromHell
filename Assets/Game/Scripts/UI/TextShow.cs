using TMPro;
using UnityEngine;
public class TextShow : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator _animator;

    [Header("RSE")]
    [SerializeField] private RSE_OnWaveCompleted onWaveCompleted;

    private void OnEnable()
    {
        onWaveCompleted.action += ShowText;
    }

    private void OnDisable()
    {
        onWaveCompleted.action -= ShowText;
    }

    private void ShowText()
    {
        _animator.SetTrigger("ShowText");
    }
}