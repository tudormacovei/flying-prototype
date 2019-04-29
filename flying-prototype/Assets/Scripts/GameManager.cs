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
    public List<GameObject> LossTitle;
    public GameObject LossMenu;
    public GameObject WinMenu;
    public GameObject Player;

    private ScoreManager scoreManager;
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
        scoreManager = FindObjectOfType<ScoreManager>();
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

    public void OnLoss()
    {
        System.Random rand = new System.Random();
        int titleIndex;

        StartCoroutine(PlayerSpawnDelay());
        titleIndex = rand.Next(0, 4);
        LossTitle[titleIndex].SetActive(true);
        scoreManager.OnLoss();
        OnStateChange -= OnLoss;
    }
    
    private IEnumerator PlayerSpawnDelay()
    {
        yield return new WaitForSeconds(1.5f);
        LossMenu.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Player Spawned");
        Instantiate(Player, new Vector3(0, 5.2f), Quaternion.identity);
    }

    public void OnWin()
    {
        WinMenu.SetActive(true);
        scoreManager.OnWin();
        OnStateChange -= OnWin;
    }
}