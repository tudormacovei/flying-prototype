using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuActivator : MonoBehaviour
{
    public GameObject TextToActivate;
    public GameState ToGameState;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void LoadObject()
    {
        Debug.Log("Loading: " + TextToActivate.name);
        gameManager.OnStateChange -= LoadObject;
        TextToActivate.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.StartsWith("Player"))
        {
            gameManager.OnStateChange += LoadObject;
            gameManager.SetGameState(ToGameState);
        }
    }
}
