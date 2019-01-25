using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    float _deathTimer;
    bool _blink;

	// Use this for initialization
	void Start ()
    {
        _deathTimer = 1f;
        _blink = false;
        StartCoroutine(Blink(2, 0.25f, 0.05f));
    }
	
	// Update is called once per frame
	void Update ()
    {
        _deathTimer -= Time.deltaTime;
        if (_deathTimer < 0.2f && !_blink)
        {
            _blink = true;
            // this.gameObject.GetComponent<Renderer>().material.color.a = 0.5f;
            StartCoroutine(Blink(3, 0.05f, 0.08f));
        }
        if (_deathTimer < 0)
        {   
            Destroy(this.gameObject);
        }
	}

    IEnumerator Blink(int blinks, float timeOn, float timeOff)
    {
        while (blinks > 0)
        {
            this.GetComponent<Renderer>().enabled = true;
            yield return new WaitForSeconds(timeOn);
            this.GetComponent<Renderer>().enabled = false;
            yield return new WaitForSeconds(timeOff);
            blinks--;
        }
    }
}