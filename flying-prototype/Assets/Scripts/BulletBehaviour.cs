using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    float _deathTimer;

	// Use this for initialization
	void Start ()
    {
        _deathTimer = 1.1f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        _deathTimer -= Time.deltaTime;
        if (_deathTimer < 0)
        {
            Destroy(this.gameObject);
        }
        Debug.Log(_deathTimer);
	}
}
