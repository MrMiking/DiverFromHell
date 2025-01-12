using UnityEngine;
public class WaitingState : ISpawnerState
{
    private WaveSpawner spawner;

    public WaitingState(WaveSpawner spawner)
    {
        this.spawner = spawner;
    }

    public void Enter()
    {
        Debug.Log("Waiting for all enemies to be destroyed...");
    }

    public void Update() { }

    public void Exit() { }
}