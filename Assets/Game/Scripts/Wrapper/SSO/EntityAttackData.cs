using UnityEditor;
using UnityEngine;

[System.Serializable]
public class EntityAttackData
{
    public AttackType attackType;
    public GameObject bulletPrefab;

    public float damage;
    public float cooldown;
    public float timeToExecute;
    public float range;
}

public enum AttackType
{
    Melee,
    Range
}