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
            Invoke("OnPlayerDestroyDelayed", 0.5f);
            Invoke ("DestroyPlayer", 2f);
        }
    }

    private void DestroyPlayer()
    {
        Destroy(this.gameObject);
        gameManager.OnStateChange += gameManager.OnLoss;
        gameManager.SetGameState(GameState.Loss);
    }

    private void OnPlayerDestroyDelayed()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }
}
