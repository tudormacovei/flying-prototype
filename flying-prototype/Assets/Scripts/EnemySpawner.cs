using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyBasic;

    private IEnumerator waveStart;
    private enum WavePosition {north = 0, south, east, west};

    // Use this for initialization
    void Start ()
    {
        // test phase
        SpawnWave_1();
	}
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    private void SpawnWave_1()
    {
        waveStart = SpawnWave(20, (int)WavePosition.east, 1f);
        StartCoroutine(waveStart);
    }

    private IEnumerator SpawnWave(int waveSize, int position, float timeFreq)
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
