using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Prologue : MonoBehaviour
{

    public GameObject Button_UjiCoba;


    void Update()
    {

    }

    public void PindahScene()
    {
        SceneManager.LoadScene("Rizzik");
    }
}
