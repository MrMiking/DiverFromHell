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
        spawner.ResetData();
        spawner.SetState(new SpawningState(spawner));
    }

    public void Update() { }

    public void Exit() { }
}