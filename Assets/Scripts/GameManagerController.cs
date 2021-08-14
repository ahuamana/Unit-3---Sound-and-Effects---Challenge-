using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerController : MonoBehaviour
{
    public int score;
    private PlayerController playerControllerScript;

    private void Awake()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Start()
    {
        score = 0;
        

        InvokeRepeating("ChangeScore", 0f, 1f);
    }

    void ChangeScore()
    {
        if (Time.timeScale == 1)
        {
            score += 1;
        }
        else
        {
            score += 2;
        }

        if (!playerControllerScript.gameOver)
        {
            Debug.Log("Score: " + score);
        }
    }

}
