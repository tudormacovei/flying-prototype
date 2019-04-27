using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyBasic;
    public List<GameObject> WaveTitle;

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
        if (waveNumber <= 4 && gameManager.State == GameState.InGame)
        {
            for (int i = 0; i < waveNumber; i++)
            {
                SpawnWave(waveNumber);
            }
            WaveTitle[waveNumber - 1].SetActive(true);
            yield return new WaitForSeconds(2f);
            WaveTitle[waveNumber - 1].SetActive(false);
            StartCoroutine(StartWave(waveNumber + 1));
        }
        else if (gameManager.State == GameState.InGame)
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
        randOffset = rand.Next(1, 5);
        // Increase dificulty using this variable
        enemyCount = (randOffset / 2 + 5) * waveNumber;
        enemyFrequency = waveNumber / 4f;
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
            randOffset = rand.Next(-5, 6);
            if (gameManager.State != GameState.InGame)
            {
                yield break;
            }
            yield return new WaitForSeconds(timeFreq);
            switch (position)
            {
                case 1:
                    Instantiate(EnemyBasic, new Vector3(randOffset, 6, 0), Quaternion.identity);
                    break;

                case 2:
                    Instantiate(EnemyBasic, new Vector3(randOffset, -6, 0), Quaternion.identity);
                    break;

                case 3:
                    Instantiate(EnemyBasic, new Vector3(6, randOffset, 0), Quaternion.identity);
                    break;

                case 4:
                    Instantiate(EnemyBasic, new Vector3(-6, randOffset, 0), Quaternion.identity);
                    break;
            }
            i++;
        }
    }
}
