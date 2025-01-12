using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "SSO_EntityData", menuName = "ScriptableObject/SSO_EntityData")]
public class SSO_EntityData : ScriptableObject
{
    [Header("Stats")]
    public string entityName;
    public float health;
    public float speed;

    public EntityAttackData attackData;
}