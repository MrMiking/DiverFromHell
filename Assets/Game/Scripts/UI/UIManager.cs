using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
public class UIManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private TextMeshProUGUI achievementText;
    [SerializeField] private Animator newAchievementAnimator;

    public void ShowAchievement(SSO_Achievement achievement)
    {
        achievementText.text = achievement.title;
        newAchievementAnimator.Play("FadeIn");
    }
}