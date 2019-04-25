using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public enum GameState { StartMenu, Options, Credits, InGame, Win, Loss };

public delegate void OnStateChangeHandler();

public class GameManager : MonoBehaviour
{
    public event OnStateChangeHandler OnStateChange;
    public GameState State { get; private set; }

    private EnemySpawner enemySpawner;
    private enum SceneIndex { Preload = 0, GameLevel };
    
    // Init GameState to 'StartMenu'
    // We only have one scene, the player is spawned from the start
    // Handle Changes in GameState, losing and winning
    private void Awake()
    {
        enemySpawner = GetComponent<EnemySpawner>();
        State = GameState.StartMenu;
        SceneManager.LoadScene((int)SceneIndex.GameLevel);
    }
    
    public void SetGameState(GameState state)
    {
        Debug.Log("GameState changing to: " + state);
        this.State = state;
        OnStateChange();
    }

    public void StartSpawner()
    {
        Debug.Log("Spawner starting");
        StartCoroutine(enemySpawner.StartWave(1));
    }

}