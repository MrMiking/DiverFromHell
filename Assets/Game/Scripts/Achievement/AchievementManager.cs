using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class AchievementManager : MonoBehaviour
{
    [Header("SpinToWin")]
    public RSO_SpinToWinCondition spinToWinCondition;
    public SSO_Achievement spinToWinAchievement;

    private void OnEnable()
    {
        spinToWinCondition.OnChanged += CheckSpinToWinAchievement;
    }

    private void OnDisable()
    {
        spinToWinCondition.OnChanged -= CheckSpinToWinAchievement;
    }

    private void Update()
    {
        spinToWinCondition.EvaluateCondition();
    }

    private void CheckSpinToWinAchievement()
    {
        if (spinToWinCondition.Value && !spinToWinAchievement.isUnlocked)
        {
            UnlockAchievement(spinToWinAchievement);
        }
    }

    private void UnlockAchievement(SSO_Achievement achievement)
    {
        Debug.Log("unlocked");
        achievement.isUnlocked = true;
    }
}