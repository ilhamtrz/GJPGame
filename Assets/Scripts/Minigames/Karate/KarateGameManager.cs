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
    public ScoreOverallSO overallSO;

    public GhostScroller GS1;
    public GhostScroller GS2;

    public GameObject border;
    public GameObject howToPlayPanel;
    public GameObject endGamePanel;
    public GameObject drawPanel;

    public GameObject P1WinIcon;
    public GameObject P2WinIcon;

    public AudioSource bgm;

    public bool startPlaying;

    public static KarateGameManager instance;

    public float totalGhost;
    public float ghostMissed;
    public float ghostHitted;

    public bool endGameReached;

    public List<AudioSource> punchSfxList = new List<AudioSource>();

    // Start is called before the first frame update
    void Start()
    {
        scoreP1 = 0;
        scoreP2 = 0;

        startPlaying = false;

        endGameReached = false;

        instance = this;
        totalGhost = FindObjectsOfType<GhostObject>().Length;
        Debug.Log(totalGhost);
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreP1 > scoreP2)
        {
            if (endGameReached)
            {
                winner = 1;
                P1WinIcon.SetActive(true);
                overallSO.p1Score++;
                
            }
            
        }
        else if(scoreP1 == scoreP2)
        {
            if (endGameReached)
            {
                winner = 0;
                overallSO.p1Score++;
                overallSO.p2Score++;
                endGamePanel.SetActive(false);
                drawPanel.SetActive(true);
            }
                
        }
        else
        {
            if (endGameReached)
            {
                winner = 2;
                P2WinIcon.SetActive(true);
                overallSO.p2Score++;
            }
                
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
    public void timeSlace()
    {
        Time.timeScale = 1;
    }
    public void PreviousCall()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Rizzik");
        PlayerPrefs.SetString("LastExitName", "test1");
        
    }

    public void GhostHit()
    {
        int random = Random.Range(0, 3);
        ghostHitted++;
        Debug.Log("Ghost hit:" + ghostHitted);
        punchSfxList[random].Play();

    }

    public void GhostMissed()
    {
        ghostMissed++;
        Debug.Log("Ghost missed"+ ghostMissed);
        
    }

    public void endGame()
    {
        endGameReached = true;
        bgm.Stop();
        endGamePanel.SetActive(true);
        Time.timeScale = 0;
    }
}
