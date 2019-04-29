using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMesh ScoreMesh;
    public TextMesh BestMesh;

    GameManager gameManager;
    int score;
    int highScore;

	// Use this for initialization
	void Start ()
    {
        highScore = 0;
        gameManager = FindObjectOfType<GameManager>();
	}

    private void Update()
    {
        if (gameManager.State == GameState.StartMenu)
            ScoreMesh.gameObject.SetActive(false);
        else
            ScoreMesh.gameObject.SetActive(true);
    }

    public void IncreaseScore(int value)
    {
        if (gameManager.State == GameState.InGame)
        {
            score = score + value;
            ScoreMesh.text = "Score: " + score.ToString();
        }
    }

    public void OnLoss()
    {
        if (score > highScore)
        {
            highScore = score;
            BestMesh.text = "Best: " + highScore.ToString();
            Blink(5, 0.3f, 0.3f, BestMesh);
        }
        score = 0;
        ScoreMesh.text = "Score: " + score.ToString();
    }

    public void OnWin()
    {
        score = 0;
        ScoreMesh.text = "Score: " + score.ToString();
        BestMesh.text = "Best: YOU WON";
        Blink(10, 0.2f, 0.2f, BestMesh);
    }

    IEnumerator Blink(int blinks, float timeOn, float timeOff, TextMesh gameObject)
    {
        while (blinks > 0)
        {
            gameObject.GetComponent<Renderer>().enabled = true;
            yield return new WaitForSeconds(timeOn);
            gameObject.GetComponent<Renderer>().enabled = false;
            yield return new WaitForSeconds(timeOff);
            blinks--;
        }
    }
}
