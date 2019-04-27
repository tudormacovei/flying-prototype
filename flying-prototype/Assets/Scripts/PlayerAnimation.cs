using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator Animator;

    private GameManager gameManager;

	// Use this for initialization
	void Start ()
    {
        Animator.SetBool("Thrust", false);
        gameManager = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Animator.SetBool("Thrust", false);
        if (Input.GetKey(KeyCode.UpArrow))
            Animator.SetBool("Thrust", true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.StartsWith("EnemyBasic"))
        {
            PlayerMovement playerMovement = GetComponent<PlayerMovement>();
            playerMovement.KillMovement();
            Animator.SetBool("Death", true);
            Invoke("DestroyPlayer", 0.4f);
        }
    }
    
    private void DestroyPlayer()
    {
        gameManager.OnStateChange += OnPlayerDestroy;
        gameManager.OnStateChange += gameManager.OnLoss;
        gameManager.SetGameState(GameState.Loss);
    }

    private void OnPlayerDestroy()
    {
        Destroy(this.gameObject);
        gameManager.OnStateChange -= OnPlayerDestroy;
    }
}
