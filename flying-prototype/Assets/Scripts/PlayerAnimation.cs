using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator Animator;

	// Use this for initialization
	void Start ()
    {
        Animator.SetBool("Thrust", false);
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
        Debug.Log(this.gameObject.name + " collision trigger");
        if (collision.gameObject.name.StartsWith("EnemyBasic"))
        {
            Animator.SetBool("Death", true);
            Invoke("DestroyPlayer", 0.7f);
        }
    }
    
    private void DestroyPlayer()
    {
        Destroy(this.gameObject);
    }
}
