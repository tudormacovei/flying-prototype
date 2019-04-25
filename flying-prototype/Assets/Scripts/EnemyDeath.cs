using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public Animator EnemyAnimator;

    private GameManager gameManager;

	// Use this for initialization
	void Start ()
    {
        EnemyAnimator.SetBool("isDestroyed", false);
        gameManager = FindObjectOfType<GameManager>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (gameManager.State != GameState.InGame)
        {
            EnemyAnimator.SetBool("isDestroyed", true);
            GetComponent<Collider2D>().enabled = false;
            Invoke("DestroyEnemy", 0.2f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "BulletSmall(Clone)")
        {
            EnemyAnimator.SetBool("isDestroyed", true);
            GetComponent<Collider2D>().enabled = false;
            Invoke("DestroyEnemy", 0.2f);
        }
    }

    void DestroyEnemy()
    {
        Destroy(this.gameObject);
    }
}
