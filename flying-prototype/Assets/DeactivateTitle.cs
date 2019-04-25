using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
