using TMPro;
using UnityEngine;
public class UIManager : MonoBehaviour
{
    [Header("Settings")]

    [Header("References")]
    [SerializeField] private TextMeshProUGUI waveNumberText;
    [Space(10)]
    [SerializeField] private RSO_WaveData waveData;

    // RSO
    // RSF
    // RSP

    //[Header("Input")]
    //[Header("Output")]

    private void OnEnable()
    {
        waveData.OnChanged += UpdateUI;
    }

    private void OnDisable()
    {
        waveData.OnChanged -= UpdateUI;
    }

    private void UpdateUI()
    {
        Debug.Log("Change");
        waveNumberText.text = waveData.Value.waveNumber.ToString();
    }
}