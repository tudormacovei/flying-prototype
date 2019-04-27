using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is used to make sure that we don't get multiple titles loaded at once
public class DeactivateTitle : MonoBehaviour
{
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnEnable()
    {
        gameManager.OnStateChange += Deactivate;
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
        gameManager.OnStateChange -= Deactivate;
    }
}
