using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int EnemiesLeft = 0;
    
    public SpawningWaves[] waves;


    public Transform spawnPoint;

    public float timeBetweenWaves = 10f; // time between the waves
    private float countDown = 5f; //timer that desplays coundown till first wave

    public Text waveCountDownText;

    public Manager man;

    private int waveIndex = 0;

    void Update() // when countdown reaches 0 wave spawns
    {
        if (EnemiesLeft > 0)
        {
            
            return;
        }

        // disables the wave spawner when the maximum amount of waves is reached.
        if (waveIndex == waves.Length)
        {
            this.enabled = false;
        }

        if (countDown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;
            return;
        }

        countDown -= Time.deltaTime; // reduce countdown by 1 second every socond

        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);

        waveCountDownText.text = string.Format("{0:00.00}", countDown); // Rounds the number without decimal

    }

    IEnumerator SpawnWave()  //IEnumerator allows the piec of code to be paused so enemies spawns behind eachother not inside eachother
    {
        
        Rounds.wavesCompleted++;

        SpawningWaves wave = waves[waveIndex];

        EnemiesLeft = wave.amount + wave.amount2 + wave.amount3;
        

        for (int i = 0; i < wave.amount; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f /wave.rate); // spawns enemy after 1 secound devided by spawn rate in SpawnWave script
        }

        for (int i = 0; i < wave.amount2; i++)
        {
            SpawnEnemy(wave.enemy2);
            yield return new WaitForSeconds(1f / wave.rate2); // spawns enemy after 1 secound devided by spawn rate in SpawnWave script
        }

        for (int i = 0; i < wave.amount3; i++)
        {
            SpawnEnemy(wave.enemy3);
            yield return new WaitForSeconds(1f / wave.rate3); // spawns enemy after 1 secound devided by spawn rate in SpawnWave script
        }

        waveIndex++;

        if (waveIndex == waves.Length)
        {
            man.WinLevel();
            this.enabled = false;
        }
    }


    void SpawnEnemy(GameObject enemy)
    {

        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation); // spawns the car/enemy at the spawnPoint location
      
    }
}
