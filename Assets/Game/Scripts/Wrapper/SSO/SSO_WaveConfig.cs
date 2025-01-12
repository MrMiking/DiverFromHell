using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SSO_WaveConfig", menuName = "ScriptableObject/SSO_WaveConfig")]
public class SSO_WaveConfig : ScriptableObject
{
    public float totalEnemies;
    public float spawnInterval;
}