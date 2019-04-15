using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyBasic;

    private IEnumerator wave;

    // Use this for initialization
    void Start ()
    {
        // test phase
        wave = WaveBasic(50, 0);
        StartCoroutine(wave);
	}
	
	// Update is called once per frame
	void Update ()
    {
        
    }

    private IEnumerator WaveBasic(int waveSize, int position)
    {
        // TODO: Position argument
        //       Spawn from entire side of play area
        int i = 0;
        while (i < waveSize)
        {
            yield return new WaitForSeconds(0.5f);
            Instantiate(EnemyBasic, new Vector3(6, 0, 0), Quaternion.identity);
            i++;
        }
    }
}
