using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Pool;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    public TMP_Text scoreText;
    public GameObject gameOvertext;

    private int score = 0;
    public bool gameOver = false;
    public float scrollspeed = -1.5f;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject); 
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver && Input.GetMouseButton(0)) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void BatScored()
    {
        //The bird can't score if the game is over.
        if (gameOver)
            return;
        //If the game is not over, increase the score...
        score++;
        //...and adjust the score text.
        scoreText.text = "Score: " + score.ToString();
    }
    public void BatDied()
    {
        //Activate the game over text.
        gameOvertext.SetActive(true);
        //Set the game to be over.
        gameOver = true;
    }
}
