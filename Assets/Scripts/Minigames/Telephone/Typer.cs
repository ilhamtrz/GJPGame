using System.Collections;
using System.Collections.Generic;
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
    private int winner;

    public float timeDuration;
    public TextMeshProUGUI timerText;
    private float timer;

    public GameObject howToPlayPanel;
    public GameObject endGamePanel;
    public TextMeshProUGUI winnerText;

    public AudioSource bgm;
    public AudioSource introBgm;

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
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreP1 > scoreP2)
        {
            winner = 1;
            winnerText.text = "Player 1 Wins!";
        }
        else if (scoreP1 == scoreP2)
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

                howToPlayPanel.SetActive(false);

                introBgm.Stop();

                bgm.Play();

                
            }
        }
        else
        {
            CheckInput();
            timer -= 1 * Time.deltaTime;
            timerText.text = timer.ToString();
            if (timer <= 0)
            {
                SetCurrentNumber();
                turn++;
                if (turn == 2)
                {
                    player2Turn = true;
                    Debug.Log("turn:"+turn);
                }
                if (turn == 3)
                {
                    endGame();
                }
                timer = timeDuration;
            }
        }

        scoreP1Text.text = scoreP1.ToString();
        scoreP2Text.text = scoreP2.ToString();

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
        bgm.Stop();
        endGamePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Dial0()
    {
        keyPressed = "0";
    }

    public void Dial1()
    {
        keyPressed = "1";
    }
    public void Dial2()
    {
        keyPressed = "2";
    }
    public void Dial3()
    {
        keyPressed = "3";
    }
    public void Dial4()
    {
        keyPressed = "4";
    }
    public void Dial5()
    {
        keyPressed = "5";
    }
    public void Dial6()
    {
        keyPressed = "6";
    }
    public void Dial7()
    {
        keyPressed = "7";
    }
    public void Dial8()
    {
        keyPressed = "8";
    }
    public void Dial9()
    {
        keyPressed = "9";
    }
}
