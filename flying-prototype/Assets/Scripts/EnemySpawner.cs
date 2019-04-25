using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyBasic;

    private GameManager gameManager;
    private IEnumerator waveStart;
    private System.Random rand = new System.Random(); // Declaring the rand here gives us better variety in our values
    private enum WavePosition {North = 0, South, East, West};

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Called from GameManager
    public IEnumerator StartWave(int waveNumber)
    {
        Debug.Log("Waiting for wave: " + waveNumber);
        if (gameManager.State != GameState.InGame)
        {
            yield break;
        }
        while (GameObject.FindGameObjectsWithTag("Enemy").Length != 0)
        {
            yield return new WaitForSeconds(0.2f);
        }
        yield return new WaitForSeconds(0.5f);
        if (waveNumber <= 4)
        {
            for (int i = 0; i < waveNumber; i++)
            {
                SpawnWave(waveNumber);
            }
            yield return new WaitForSeconds(2f);
            StartCoroutine(StartWave(waveNumber + 1));
        }
        else
        {
            gameManager.OnStateChange += gameManager.OnWin;
            gameManager.SetGameState(GameState.Win);
        }
    }

    void SpawnWave(int waveNumber)
    {
        int enemyCount;
        int randOffset;
        float enemyFrequency;

        // Randomize waves based on a random variabile and waveNumber
        randOffset = rand.Next(0, 3);
        enemyCount = (1 + randOffset * 3) * waveNumber;
        enemyFrequency = 1f / waveNumber;
        waveStart = SpawnBasicWave(enemyCount, randOffset, enemyFrequency);
        StartCoroutine(waveStart);
        Debug.Log("Wave " + waveNumber + " Spawning");
    }

    IEnumerator SpawnBasicWave(int waveSize, int position, float timeFreq)
    {
        int i = 0;
        int randOffset;

        while (i < waveSize)
        {
            randOffset = rand.Next(-5, 5);
            if (gameManager.State != GameState.InGame)
            {
                yield break;
            }
            yield return new WaitForSeconds(timeFreq);
            switch (position)
            {
                case 0:
                    Instantiate(EnemyBasic, new Vector3(randOffset, 6, 0), Quaternion.identity);
                    break;

                case 1:
                    Instantiate(EnemyBasic, new Vector3(randOffset, -6, 0), Quaternion.identity);
                    break;

                case 2:
                    Instantiate(EnemyBasic, new Vector3(6, randOffset, 0), Quaternion.identity);
                    break;

                case 3:
                    Instantiate(EnemyBasic, new Vector3(-6, randOffset, 0), Quaternion.identity);
                    break;
            }
            i++;
        }
    }
}
