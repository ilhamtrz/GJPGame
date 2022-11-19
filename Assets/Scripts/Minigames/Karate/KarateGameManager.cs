using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class KarateGameManager : MonoBehaviour
{
    public int scoreP1;
    public int scoreP2;
    public int winner;

    public GhostScroller GS1;
    public GhostScroller GS2;

    public GameObject border;
    public GameObject howToPlayPanel;
    public GameObject endGamePanel;
    public TextMeshProUGUI winnerText;

    public AudioSource bgm;

    public bool startPlaying;

    public static KarateGameManager instance;

    public float totalGhost;
    public float ghostMissed;
    public float ghostHitted;

    // Start is called before the first frame update
    void Start()
    {
        scoreP1 = 0;
        scoreP2 = 0;

        startPlaying = false;

        instance = this;
        totalGhost = FindObjectsOfType<GhostObject>().Length;
        Debug.Log(totalGhost);
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreP1 > scoreP2)
        {
            winner = 1;
            winnerText.text = "Player 1 Wins!";
        }
        else if(scoreP1 == scoreP2)
        {
            winner = 0;
            winnerText.text = "Draw!";
        }
        else
        {
            winner = 2;
            winnerText.text = "Player 2 Wins!";
        }

        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                GS1.hasStarted = true;
                GS2.hasStarted = true;

                howToPlayPanel.SetActive(false);
                border.SetActive(true);

                bgm.Play();
            }
        }
        if (ghostHitted + ghostMissed == totalGhost)
        {
            endGame();
            if (Input.anyKeyDown)
            {
                
            }
        }
    }
    public void PreviousCall()
    {
        SceneManager.LoadScene("Rizzik");
        PlayerPrefs.SetString("LastExitName", "test1");
        Time.timeScale = 1;
    }

    public void GhostHit()
    {
        ghostHitted++;
        Debug.Log("Ghost hit:" + ghostHitted);
        
    }

    public void GhostMissed()
    {
        ghostMissed++;
        Debug.Log("Ghost missed"+ ghostMissed);
        
    }

    public void endGame()
    {
        bgm.Stop();
        endGamePanel.SetActive(true);
        Time.timeScale = 0;
    }
}
