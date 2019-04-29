using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeButton : MonoBehaviour
{
    GameManager gameManager;
    AudioSource audioSrc;

    // Use this for initialization
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        audioSrc = gameManager.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        audioSrc.volume += 0.05f;
        if (audioSrc.volume > 0.61f)
            audioSrc.volume = 0;
        GetComponent<TextMesh>().text = "Volume: " + (int)((audioSrc.volume / 0.6f) * 100) + "%";
    }
}
