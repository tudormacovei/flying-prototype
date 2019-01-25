using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public Animator EnemyAnimator;

	// Use this for initialization
	void Start ()
    {
        EnemyAnimator.SetBool("isDestroyed", false);
    }
	
	// Update is called once per frame
	void Update ()
    {

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collison detected");
        EnemyAnimator.SetBool("isDestroyed", true);
        Invoke("DestroyEnemy", 0.2f);
    }

    void DestroyEnemy()
    {
        Destroy(this.gameObject);
    }
}
