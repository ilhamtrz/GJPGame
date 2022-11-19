using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarateGameManager : MonoBehaviour
{
    public int scoreP1;
    public int scoreP2;
    public int winner;

    public GhostScroller GS1;
    public GhostScroller GS2;

    public GameObject border;
    public GameObject howToPlayPanel;

    public AudioSource bgm;

    public bool startPlaying;

    public static KarateGameManager instance;
    // Start is called before the first frame update
    void Start()
    {
        scoreP1 = 0;
        scoreP2 = 0;

        startPlaying = false;

        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreP1 > scoreP2)
        {
            winner = 1;
        }
        else if(scoreP1 == scoreP2)
        {
            winner = 0;
        }
        else
        {
            winner = 2;
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
    }

    public void GhostHit()
    {
        Debug.Log("Ghost hit");
    }

    public void GhostMissed()
    {
        Debug.Log("Ghost missed");
    }
}
