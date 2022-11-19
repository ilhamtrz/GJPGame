using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public KarateGameManager GM;
    public int forPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(forPlayer == 1)
        {
            scoreText.text = GM.scoreP1.ToString();
        }
        else
        {
            scoreText.text = GM.scoreP2.ToString();
        }
    }
}
