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
}
