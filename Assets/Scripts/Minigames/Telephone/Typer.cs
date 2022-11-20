using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Typer : MonoBehaviour
{
    public TextMeshProUGUI numberOutput = null;

    public NumberBank numberBank = null;

    private string remainingNumber = string.Empty;
    private string currentNumber = string.Empty;

    private string keyPressed =string.Empty;

    private bool player1Turn;
    private bool player2Turn;
    private int turn;

    private int scoreP1;
    private int scoreP2;
    public TextMeshProUGUI scoreP1Text;
    public TextMeshProUGUI scoreP2Text;

    public TextMeshProUGUI scoreP1TextDraw;
    public TextMeshProUGUI scoreP2TextDraw;

    public TextMeshProUGUI scoreP1Text1Wins;
    public TextMeshProUGUI scoreP2Text1Wins;

    public TextMeshProUGUI scoreP1Text2Wins;
    public TextMeshProUGUI scoreP2Text2Wins;
    private int winner;

    public float timeDuration;
    public float inBetweenDuration;
    public TextMeshProUGUI timerText;
    private float timer;
    private float inBetweenTimer;
    private bool isInBetween;

    public GameObject player2GetReady;
    public GameObject howToPlayPanel;
    public GameObject endGamePanel;
    public GameObject player1WinsPanel;
    public GameObject player2WinsPanel;
    public GameObject drawPanel;

    private bool endGameReached;

    public AudioSource bgm;
    public AudioSource introBgm;

    public AudioSource dialPhone1Sfx;
    public AudioSource dialPhone2Sfx;
    public AudioSource dialPhone3Sfx;

    public ScoreOverallSO overallSO;

    public bool startPlaying;

    public Button buttonDial0;
    public Button buttonDial1;
    public Button buttonDial2;
    public Button buttonDial3;
    public Button buttonDial4;
    public Button buttonDial5;
    public Button buttonDial6;
    public Button buttonDial7;
    public Button buttonDial8;
    public Button buttonDial9;
    // Start is called before the first frame update
    void Start()
    {
        Button btn0 = buttonDial0.GetComponent<Button>();
        btn0.onClick.AddListener(Dial0);
        Button btn1 = buttonDial1.GetComponent<Button>();
        btn1.onClick.AddListener(Dial1);
        Button btn2 = buttonDial2.GetComponent<Button>();
        btn2.onClick.AddListener(Dial2);
        Button btn3 = buttonDial3.GetComponent<Button>();
        btn3.onClick.AddListener(Dial3);
        Button btn4 = buttonDial4.GetComponent<Button>();
        btn4.onClick.AddListener(Dial4);
        Button btn5 = buttonDial5.GetComponent<Button>();
        btn5.onClick.AddListener(Dial5);
        Button btn6 = buttonDial6.GetComponent<Button>();
        btn6.onClick.AddListener(Dial6);
        Button btn7 = buttonDial7.GetComponent<Button>();
        btn7.onClick.AddListener(Dial7);
        Button btn8 = buttonDial8.GetComponent<Button>();
        btn8.onClick.AddListener(Dial8);
        Button btn9 = buttonDial9.GetComponent<Button>();
        btn9.onClick.AddListener(Dial9);
        SetCurrentNumber();
        turn = 1;
        scoreP1 = 0;
        scoreP2 = 0;
        player1Turn = true;
        timer = timeDuration;
        inBetweenTimer = inBetweenDuration;
        endGameReached = false;
        isInBetween = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreP1 > scoreP2)
        {
            if (endGameReached)
            {
                winner = 1;

                player1WinsPanel.SetActive(true);

                overallSO.p1Score++;
            }
        }
        else if (scoreP1 == scoreP2)
        {
            
            if (endGameReached)
            {
                winner = 0;
                drawPanel.SetActive(true);
                overallSO.p1Score++;
                overallSO.p2Score++;
            }
            
        }
        else
        {
            if (endGameReached)
            {
                winner = 2;
                player2WinsPanel.SetActive(true);
                overallSO.p2Score++;
            }

        }

        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;

                howToPlayPanel.SetActive(false);

                introBgm.Stop();

                bgm.Play();

                
            }
        }
        else
        {
            if (!isInBetween)
            {
                CheckInput();
                timer -= 1 * Time.deltaTime;
                timerText.text = timer.ToString("0");
                if (timer <= 0)
                {
                    SetCurrentNumber();
                    turn++;
                    if (turn == 2)
                    {
                        player2Turn = true;
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
                player2GetReady.SetActive(true);
                inBetweenTimer -= 1 * Time.deltaTime;
                if(inBetweenTimer <= 0)
                {
                    player2GetReady.SetActive(false);
                    isInBetween = false;
                    inBetweenTimer = inBetweenDuration;
                }
            }
        }

        scoreP1Text.text = scoreP1.ToString();
        scoreP2Text.text = scoreP2.ToString();

        scoreP1Text1Wins.text = scoreP1.ToString();
        scoreP2Text1Wins.text = scoreP2.ToString();

        scoreP1Text2Wins.text = scoreP1.ToString();
        scoreP2Text2Wins.text = scoreP2.ToString();

        scoreP1TextDraw.text = scoreP1.ToString();
        scoreP2TextDraw.text = scoreP2.ToString();

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
        if (Input.anyKeyDown)
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
        bgm.Stop();
        endGamePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Dial0()
    {
        keyPressed = "0";
        dialPhone2Sfx.Play();
    }

    public void Dial1()
    {
        keyPressed = "1";
        dialPhone1Sfx.Play();
    }
    public void Dial2()
    {
        keyPressed = "2";
        dialPhone1Sfx.Play();
    }
    public void Dial3()
    {
        keyPressed = "3";
        dialPhone1Sfx.Play();
    }
    public void Dial4()
    {
        keyPressed = "4";
        dialPhone2Sfx.Play();
    }
    public void Dial5()
    {
        keyPressed = "5";
        dialPhone2Sfx.Play();
    }
    public void Dial6()
    {
        keyPressed = "6";
        dialPhone2Sfx.Play();
    }
    public void Dial7()
    {
        keyPressed = "7";
        dialPhone3Sfx.Play();
    }
    public void Dial8()
    {
        keyPressed = "8";
        dialPhone3Sfx.Play();
    }
    public void Dial9()
    {
        keyPressed = "9";
        dialPhone3Sfx.Play();
    }
}
