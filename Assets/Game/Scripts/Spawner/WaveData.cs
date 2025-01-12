[System.Serializable]
public class WaveData
{
    public int waveNumber;
    public int enemiesSpawned;
    public int enemiesKilled;

    public void ResetValues() { enemiesSpawned = 0;  enemiesKilled = 0; } 
}