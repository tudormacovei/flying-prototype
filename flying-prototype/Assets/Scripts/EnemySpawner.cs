using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyBasic;

    private IEnumerator waveStart;
    private enum WavePosition {North = 0, South, East, West};

    // Use this for initialization
    void Start ()
    {
        // test phase
        // SpawnWave(1);
	}
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    public void StartWaves()
    {
        // SpawnWave, wait for all enemies to die, spawn next wave until 5th wave is reached
    }

    // To be called from GameManager
    void SpawnWave(int waveNumber)
    {
        // Randomize waves based on a randndom variabile and waveNumber
        waveStart = SpawnBasicWave(20, (int)WavePosition.East, 1f);
        StartCoroutine(waveStart);
    }

    IEnumerator SpawnBasicWave(int waveSize, int position, float timeFreq)
    {
        int i = 0;
        int randOffset;
        System.Random rand = new System.Random();

        while (i < waveSize)
        {
            randOffset = rand.Next(-5, 5);
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
