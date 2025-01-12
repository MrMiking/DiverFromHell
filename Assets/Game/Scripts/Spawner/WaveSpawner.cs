using UnityEngine;
public class WaveSpawner : MonoBehaviour
{
    [Header("Settings")]

    [Header("References")]
    [SerializeField] public EnemySpawner enemySpawner;
    [Space(10)]
    [SerializeField] public SSO_WaveConfig currentWaveConfig;
    
    [Header("Input")] 
    [SerializeField] private RSE_OnEnemyKilled rseOnEnemyKilled;

    [Header("Output")]
    [SerializeField] public RSO_WaveData rsoWaveData;

    private ISpawnerState currentState;

    private void OnEnable()
    {
        rseOnEnemyKilled.action += OnEnemyKilled;
    }

    private void OnDisable()
    {
        rseOnEnemyKilled.action -= OnEnemyKilled;
    }

    private void Start()
    {
        rsoWaveData.Value.waveNumber = 0;

        SetState(new InitState(this));
    }

    private void Update()
    {
        currentState?.Update();
    }

    public void SetState(ISpawnerState newState)
    {
        currentState = newState;
        currentState?.Enter();
    }

    private void OnEnemyKilled()
    {
        rsoWaveData.Value.enemiesKilled += 1;

        if(rsoWaveData.Value.enemiesKilled >= currentWaveConfig.totalEnemies)
        {
            Debug.Log("Wave completed!");
            SetState(new InitState(this));
        }
    }
}