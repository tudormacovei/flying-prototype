using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public enum GameState { StartMenu, InGame, Win, Loss };

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
    private void Start()
    {
        enemySpawner = GetComponent<EnemySpawner>();
        SceneManager.LoadScene((int)SceneIndex.GameLevel);
        State = GameState.StartMenu;
    }
    
    public void SetGameState(GameState state)
    {
        this.State = state;
        OnStateChange();
    }

    public void StartSpawner()
    {
        enemySpawner.StartWaves();
    }

}