using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public float timeBetweenWaves = 10f;
    public Text waveCountdownText;
    private float countdown = 3f;
    private int waveIndex = 0;

    void Update()
    {
        if(countdown<=0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;
        PlayerStats.Rounds++;
        for(int i=0; i<waveIndex ;i++)
        {
            SpawnEnemey();
            yield return new WaitForSeconds(0.5f);
        }
    }

    void SpawnEnemey()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
