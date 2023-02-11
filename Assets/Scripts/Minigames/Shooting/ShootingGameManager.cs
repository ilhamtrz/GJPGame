using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingGameManager : MonoBehaviour
{
    public static ShootingGameManager Instance { get; private set; }
    
    public float gameTimer;
    public float timeDuration;
    public bool gameStart;
    public bool endGame;

    public FMOD.Studio.EventInstance bgm;

    public Reticle p1;
    public Reticle p2;

    public GameObject HowToPlayPanel;
    public GameObject p1EndPanel;
    public GameObject p2EndPanel;
    public GameObject drawEndPanel;

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
        gameStart = false;
        gameTimer = timeDuration;
        HowToPlayPanel.SetActive(true);
        p1EndPanel.SetActive(false);
        p2EndPanel.SetActive(false);
        drawEndPanel.SetActive(false);
        bgm = FMODUnity.RuntimeManager.CreateInstance("event:/ShootingGame/BGM_ShootingGame");
        bgm.start();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            gameStart = true;
            HowToPlayPanel.SetActive(false);
        }
        if (gameStart)
        {
            gameTimer -= 1 * Time.deltaTime;
            if (gameTimer <= 0)
            {
                gameStart = false;
                endGame = true;
            }
        }
        if (endGame)
        {
            bgm.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            if(p1.totalPoint > p2.totalPoint)
            {
                p1EndPanel.SetActive(true);
                Time.timeScale = 0;
            }
            else if(p2.totalPoint > p1.totalPoint)
            {
                p2EndPanel.SetActive(true);
                Time.timeScale = 0;
            }
            else if(p1.totalPoint == p2.totalPoint)
            {
                drawEndPanel.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}
