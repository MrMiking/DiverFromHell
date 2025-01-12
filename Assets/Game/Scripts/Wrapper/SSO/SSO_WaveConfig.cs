using UnityEngine;

[CreateAssetMenu(fileName = "SSO_WaveConfig", menuName = "ScriptableObject/SSO_WaveConfig")]
public class SSO_WaveConfig : ScriptableObject
{
    public int totalEnemies;
    public float spawnInterval;
    public GameObject enemy;
}