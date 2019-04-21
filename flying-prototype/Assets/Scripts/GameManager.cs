using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
    private int wave = 0;                                  //Current level number, expressed in game as "Day 1".
    private EnemySpawner EnemySpawner;

    // Awake is always called before any Start functions
    void Awake()
    {
        // Check if instance already exists
        if (instance == null)
        {
            //if not, set instance to this
            instance = this;
        }
        // If instance already exists and it's not this:
        else if (instance != this)
        {
            // Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        }

        // Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        // Call the InitGame function to initialize the first level 
        InitGame();
    }

    // Initializes the game for each level.
    void InitGame()
    {
        EnemySpawner = GetComponent<EnemySpawner>();
        // Setup UI
    }

    // Update is called every frame.
    void Update()
    {

    }
}