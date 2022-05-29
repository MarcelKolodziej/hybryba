using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenagerScript : MonoBehaviour
{
    public PlayerController player;

    public Text scoreText;

    public GameObject playButton;

    public GameObject gameOver; 

    private int score;

    private void Awake()
    {
        Application.targetFrameRate = 60;

        Pause();
        player.enabled = false;
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }
    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    public void GameOver()
    {
        Debug.Log("Game over");
        gameOver.SetActive(true);
        playButton.SetActive(true);

        Pause();
    }

    public void IncreseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
