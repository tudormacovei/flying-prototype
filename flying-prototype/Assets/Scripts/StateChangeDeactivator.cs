using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateChangeDeactivator : MonoBehaviour
{
    GameManager gameManager;

    void OnEnable()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameManager.OnStateChange += DeloadObject;
    }

    void DeloadObject()
    {
        Debug.Log("Deactivating: " + gameObject.name);
        gameManager.OnStateChange -= DeloadObject;
        gameObject.SetActive(false);
    }
}
