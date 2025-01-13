using UnityEngine;
using UnityEngine.UI;
public class PlayerHealthUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Slider healthSlider;

    [Header("RSO")]
    [SerializeField] private RSO_PlayerHealth rsoPlayerHealth;

    [Header("SSO")]
    [SerializeField] private SSO_EntityData ssoPlayerData;

    private void OnEnable() { rsoPlayerHealth.OnChanged += UpdatePlayerHealthUI; }

    private void OnDisable() => rsoPlayerHealth.OnChanged -= UpdatePlayerHealthUI;

    public void UpdatePlayerHealthUI()
    {
        Debug.Log("qshjdqs");
        healthSlider.value = (float)rsoPlayerHealth.Value / (float)ssoPlayerData.health;
    }
}