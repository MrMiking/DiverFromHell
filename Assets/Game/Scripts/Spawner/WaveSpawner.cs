using UnityEngine;
public class WaveSpawner : MonoBehaviour
{
    [Header("Settings")]

    [Header("References")]
    [SerializeField] public EnemySpawner enemySpawner;
    [Space(10)]
    [SerializeField] public SSO_WaveConfig currentWaveConfig;
    
    [Header("RSE")] 
    [SerializeField] private RSE_OnEnemyKilled rseOnEnemyKilled;
    [SerializeField] private RSE_OnWaveCompleted onWaveCompleted;

    private int enemyKilled;
    private ISpawnerState currentState;

    public void ResetData() => enemyKilled = 0;

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
        enemyKilled += 1;

        if(enemyKilled >= currentWaveConfig.totalEnemies)
        {
            onWaveCompleted.Call();
            SetState(new InitState(this));
        }
    }
}