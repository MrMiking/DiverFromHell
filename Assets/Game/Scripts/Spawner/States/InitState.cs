using UnityEngine;
public class InitState : ISpawnerState
{
    private WaveSpawner spawner;

    public InitState(WaveSpawner spawner)
    {
        this.spawner = spawner;
    }

    public void Enter()
    {
        Debug.Log("Initializing Wave...");
        spawner.rsoWaveData.Value.ResetValues();
        spawner.rsoWaveData.UpdateValue(data => data.waveNumber += 1);
        spawner.SetState(new SpawningState(spawner));
    }

    public void Update() { }

    public void Exit() { }
}