using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "SSO_EntityData", menuName = "ScriptableObject/SSO_EntityData")]
public class SSO_EntityData : ScriptableObject
{
    [Header("Stats")]
    public int health;
    public float speed;

    public AttackAnimator attackAnimation;

    public int damage;
    public float cooldown;
}