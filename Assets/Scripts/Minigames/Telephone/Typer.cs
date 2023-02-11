using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using FMODUnity;

public class Typer : MonoBehaviour
{
    public TextMeshProUGUI numberOutput = null;

    public NumberBank numberBank = null;

    private string remainingNumber = string.Empty;
    private string currentNumber = string.Empty;

    [HideInInspector]
    public string keyPressed =string.Empty;

    private int turn;

    private int scoreP1;
    private int scoreP2;

    public ScoreManager scoreManager;

    public float timeDuration;
    public float inBetweenDuration;
    private float timer;
    private float inBetweenTimer;
    private bool isInBetween;

    public PanelManager panelManager;

    private bool endGameReached;

    public AudioSource bgm;
    public AudioSource introBgm;

    FMOD.Studio.EventInstance BGM;


    public ScoreOverallSO overallSO;

    private bool startPlaying;

    // Start is called before the first frame update
    void Start()
    {
        
        SetCurrentNumber();
        turn = 1;
        scoreP1 = 0;
        scoreP2 = 0;
        timer = timeDuration;
        inBetweenTimer = inBetweenDuration;
        endGameReached = false;
        isInBetween = false;
        BGM = RuntimeManager.CreateInstance("event:/PhoneGame/BGM_PhoneGame");
    }
    public void PreviousCall()
    {
        if (scoreP1 > scoreP2)
        {
            overallSO.p1Score++;
        }
        else if (scoreP2 > scoreP1)
        {
            overallSO.p2Score++;
        }
        Time.timeScale = 1;
        SceneManager.LoadScene("Rizzik");
        PlayerPrefs.SetString("LastExitName", "test1");
    }
    // Update is called once per frame
    void Update()
    {
        if (scoreP1 > scoreP2)
        {
            if (endGameReached)
            {

                panelManager.player1WinsPanel.SetActive(true);
            }
        }
        else if (scoreP1 == scoreP2)
        {
            
            if (endGameReached)
            {
                
                panelManager.drawPanel.SetActive(true);
            }
            
        }
        else
        {
            if (endGameReached)
            {

                panelManager.player2WinsPanel.SetActive(true);
            }

        }

        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;

                panelManager.howToPlayPanel.SetActive(false);

                //introBgm.Stop();

                BGM.start();

                //bgm.Play();

                
            }
        }
        else
        {
            if (!isInBetween)
            {
                CheckInput();
                timer -= 1 * Time.deltaTime;
                scoreManager.timerText.text = timer.ToString("0");
                if (timer <= 0)
                {
                    SetCurrentNumber();
                    turn++;
                    if (turn == 2)
                    {
                        Debug.Log("turn:" + turn);
                        isInBetween = true;
                    }
                    if (turn == 3)
                    {
                        endGame();
                    }
                    timer = timeDuration;
                }
            }
            else
            {
                panelManager.player2GetReady.SetActive(true);
                inBetweenTimer -= 1 * Time.deltaTime;
                if(inBetweenTimer <= 0)
                {
                    panelManager.player2GetReady.SetActive(false);
                    isInBetween = false;
                    inBetweenTimer = inBetweenDuration;
                }
            }
        }

        scoreManager.scoreP1Text.text = scoreP1.ToString();
        scoreManager.scoreP2Text.text = scoreP2.ToString();

        scoreManager.scoreP1Text1Wins.text = scoreP1.ToString();
        scoreManager.scoreP2Text1Wins.text = scoreP2.ToString();

        scoreManager.scoreP1Text2Wins.text = scoreP1.ToString();
        scoreManager.scoreP2Text2Wins.text = scoreP2.ToString();

        scoreManager.scoreP1TextDraw.text = scoreP1.ToString();
        scoreManager.scoreP2TextDraw.text = scoreP2.ToString();

    }

    private void SetCurrentNumber()
    {
        //get bank number
        currentNumber = numberBank.GetNumber();
        SetRemainingNumber(currentNumber);
    }

    private void SetRemainingNumber(string newString)
    {
        remainingNumber = newString;
        numberOutput.text = remainingNumber;
    }

    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            //keyPressed = Input.inputString;


            if (keyPressed.Length == 1)
            {
                EnterLetter(keyPressed);
                
            }
                
        }
    }

    private void EnterLetter(string typedLetter)
    {
        if (IsCorrectLetter(typedLetter))
        {
            RemoveLetter();
            if (turn == 1)
            {
                scoreP1++;
            }
            else if (turn == 2)
            {
                scoreP2++;
            }

            if (IsWordCComplete())
            {
                SetCurrentNumber();
            }
        }
    }

    private bool IsCorrectLetter(string letter)
    {
        return remainingNumber.IndexOf(letter) == 0;
    }

    private void RemoveLetter()
    {
        string newString = remainingNumber.Remove(0,1);
        SetRemainingNumber(newString);
    }

    private bool IsWordCComplete()
    {
        return remainingNumber.Length == 0;
    }


    public void endGame()
    {
        endGameReached = true;
        BGM.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        panelManager.endGamePanel.SetActive(true);
        panelManager.player1WinsPanel.SetActive(false);
        panelManager.player2WinsPanel.SetActive(false);
        panelManager.drawPanel.SetActive(false);
        Time.timeScale = 0;
    }

}
