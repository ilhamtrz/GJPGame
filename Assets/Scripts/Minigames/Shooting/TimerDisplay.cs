using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerDisplay : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public ShootingGameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.gameTimer >= 0)
        {
            timerText.text = gameManager.gameTimer.ToString("0");
        }
        
        
    }
}
