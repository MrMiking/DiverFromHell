using UnityEngine;

[CreateAssetMenu(fileName = "SSO_Achievement", menuName = "ScriptableObject/SSO_Achievement")]
public class SSO_Achievement : ScriptableObject
{
    public string title;
    public string description;
    public bool isUnlocked;
    public float value;
    public Sprite icon;
}