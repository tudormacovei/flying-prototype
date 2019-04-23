using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    GameManager gameManager;

    // Use this for initialization
    void Start ()
    {
        gameManager = FindObjectOfType<GameManager>();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "BulletSmall(Clone)")
        {
            gameManager.OnStateChange += gameManager.StartSpawner;
            gameManager.SetGameState(GameState.InGame);
            gameManager.OnStateChange -= gameManager.StartSpawner;
        }
    }
}
