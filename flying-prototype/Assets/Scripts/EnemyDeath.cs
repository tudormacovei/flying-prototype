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
        if (collision.gameObject.name == "BulletSmall(Clone)")
        {
            Debug.Log("Enemy Hit");
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
