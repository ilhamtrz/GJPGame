using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using FMODUnity;

public class ButtonManager : MonoBehaviour
{
    public Typer typer;

    public AudioSource dialPhone1Sfx;
    public AudioSource dialPhone2Sfx;
    public AudioSource dialPhone3Sfx;

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Dial0()
    {
        typer.keyPressed= "0";
        //dialPhone2Sfx.Play();
        RuntimeManager.PlayOneShot("event:/PhoneGame/PhoneDial_2", GetComponent<Transform>().position);
    }

    public void Dial1()
    {
        typer.keyPressed = "1";
        //dialPhone1Sfx.Play();
        RuntimeManager.PlayOneShot("event:/PhoneGame/PhoneDial_1", GetComponent<Transform>().position);
    }
    public void Dial2()
    {
        typer.keyPressed = "2";
        //dialPhone1Sfx.Play();
        RuntimeManager.PlayOneShot("event:/PhoneGame/PhoneDial_1", GetComponent<Transform>().position);
    }
    public void Dial3()
    {
        typer.keyPressed = "3";
        //dialPhone1Sfx.Play();
        RuntimeManager.PlayOneShot("event:/PhoneGame/PhoneDial_1", GetComponent<Transform>().position);
    }
    public void Dial4()
    {
        typer.keyPressed = "4";
        //dialPhone2Sfx.Play();
        RuntimeManager.PlayOneShot("event:/PhoneGame/PhoneDial_2", GetComponent<Transform>().position);
    }
    public void Dial5()
    {
        typer.keyPressed = "5";
        //dialPhone2Sfx.Play();
        RuntimeManager.PlayOneShot("event:/PhoneGame/PhoneDial_2", GetComponent<Transform>().position);
    }
    public void Dial6()
    {
        typer.keyPressed = "6";
        //dialPhone2Sfx.Play();
        RuntimeManager.PlayOneShot("event:/PhoneGame/PhoneDial_2", GetComponent<Transform>().position);
    }
    public void Dial7()
    {
        typer.keyPressed = "7";
        //dialPhone3Sfx.Play();
        RuntimeManager.PlayOneShot("event:/PhoneGame/PhoneDial_3", GetComponent<Transform>().position);
    }
    public void Dial8()
    {
        typer.keyPressed = "8";
        //dialPhone3Sfx.Play();
        RuntimeManager.PlayOneShot("event:/PhoneGame/PhoneDial_3", GetComponent<Transform>().position);
    }
    public void Dial9()
    {
        typer.keyPressed = "9";
        //dialPhone3Sfx.Play();
        RuntimeManager.PlayOneShot("event:/PhoneGame/PhoneDial_3", GetComponent<Transform>().position);
    }
}
