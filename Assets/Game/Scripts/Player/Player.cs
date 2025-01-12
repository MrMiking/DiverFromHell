using UnityEngine;
public class Player : MonoBehaviour
{
    //[Header("Settings")]

    [Header("References")]

    //[Space(10)]
    [SerializeField] private RSO_PlayerPosition rsoPlayerPosition;
    // RSF
    // RSP

    //[Header("Input")]
    //[Header("Output")]

    private void Update()
    {
        rsoPlayerPosition.Value = this.transform.position;
    }
}