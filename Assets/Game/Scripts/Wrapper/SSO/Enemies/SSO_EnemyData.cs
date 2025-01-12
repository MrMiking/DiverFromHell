using UnityEngine;

[CreateAssetMenu(fileName = "SSO_EnemyData", menuName = "ScriptableObject/SSO_EnemyData")]
public class SSO_EnemyData : ScriptableObject
{
    public string enemyName;
    public GameObject visual;

    [Header("Stats")]
    public float health;
    public float damage;
    public float moveSpeed;
    public float attackSpeed;

    [Header("Wave Spawn")]
    public float minimumWave;
    public float maximumWave;
}