using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Typer : MonoBehaviour
{
    public TextMeshProUGUI numberOutput = null;

    private string remainingNumber = string.Empty;
    private string currentNumber = "082283422218";

    private string keyPressed =string.Empty;

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
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
    }

    private void SetCurrentNumber()
    {
        //get bank number
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
                EnterLetter(keyPressed);
        }
    }

    private void EnterLetter(string typedLetter)
    {
        if (IsCorrectLetter(typedLetter))
        {
            RemoveLetter();

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
