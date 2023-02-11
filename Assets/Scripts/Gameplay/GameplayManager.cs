using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using FMODUnity;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager Instance { get; private set; }


    public TextMeshProUGUI p1ScoreText;
    public TextMeshProUGUI p2ScoreText;


    public FMOD.Studio.EventInstance bgm;

    public GameObject p1WinsPanel;
    public GameObject p2WinsPanel;

    public ScoreOverallSO overallSO;

    public GameObject dialogue;
    public GameObject PausePanel;


    public bool isPaused;
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        bgm = RuntimeManager.CreateInstance("event:/BGM_Fairgrounds");
        bgm.start();
        dialogue.SetActive(true);
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        p1ScoreText.text = overallSO.p1Score.ToString();
        p2ScoreText.text = overallSO.p2Score.ToString();

        if(overallSO.p1Score+overallSO.p2Score > 0)
        {
            dialogue.SetActive(false);
        }
        if(overallSO.p1Score + overallSO.p2Score == 5)
        {
            if(overallSO.p1Score > overallSO.p2Score)
            {
                p1WinsPanel.SetActive(true);
            }
            else if(overallSO.p2Score > overallSO.p1Score)
            {
                p2WinsPanel.SetActive(true);
            }
            
            BackToMenu();
            bgm.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!dialogue.active)
            {
                if (!isPaused)
                {
                    PausePanel.SetActive(true);
                    Pause();
                }
                else
                {
                    Resume();
                }
            }
        }
        
    }
    private void OnApplicationQuit()
    {
        overallSO.p1Score = 0;
        overallSO.p2Score = 0;
        overallSO.switchedOn = false;
        overallSO.playCount = 0;
    }
    public void BackToMenu()
    {
        overallSO.switchedOn = false;
        overallSO.playCount = 0;
        overallSO.p1Score = 0;
        overallSO.p2Score = 0;
        SceneManager.LoadScene("mainmenu");
        bgm.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }

    public void Pause()
    {
        Time.timeScale = 0;
        isPaused = true;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        PausePanel.SetActive(false);
        isPaused = false;
    }
}
