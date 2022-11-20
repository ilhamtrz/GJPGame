using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TlpGameManager : MonoBehaviour
{

    public List<int> dialedNumberList = new List<int>(12);
    public List<int> givenNumberList = new List<int>(12);
    public int currentNumber;
    public string givenNumberString;
    public TextMeshProUGUI givenNumberText;
    // Start is called before the first frame update
    void Start()
    {
        GenerateGivenNumber();
        givenNumberString = "56248192202";
        /*givenNumberText.text = givenNumberString.ToString();*/
    }

    // Update is called once per frame
    void Update()
    {
        
        givenNumberText.text = givenNumberString.ToString();
    }

    public void GenerateGivenNumber()
    {
        for(int i = 0; i < givenNumberList.Count; i++)
        {
            
            /*givenNumberList.Add(randomNumber);*/

        }
    }
    public void Dial0()
    {
        currentNumber = 0;
    }

    public void Dial1()
    {
        currentNumber = 1;
    }
    public void Dial2()
    {
        currentNumber = 2;
    }
    public void Dial3()
    {
        currentNumber = 3;
    }
    public void Dial4()
    {
        currentNumber = 4;
    }
    public void Dial5()
    {
        currentNumber = 5;
    }
    public void Dial6()
    {
        currentNumber = 6;
    }
    public void Dial7()
    {
        currentNumber = 7;
    }
    public void Dial8()
    {
        currentNumber = 8;
    }
    public void Dial9()
    {
        currentNumber = 9;
    }
}
