using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayManager : MonoBehaviour
{

    public TextMeshProUGUI p1ScoreText;
    public TextMeshProUGUI p2ScoreText;

    public GameObject p1WinsPanel;
    public GameObject p2WinsPanel;

    public ScoreOverallSO overallSO;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        p1ScoreText.text = overallSO.p1Score.ToString();
        p2ScoreText.text = overallSO.p2Score.ToString();

        if(overallSO.p1Score + overallSO.p2Score == 5)
        {
            if(overallSO.p1Score > overallSO.p2Score)
            {
                p1WinsPanel.SetActive(true);
            }
            else if(overallSO.p2Score > overallSO.p1Score)
            {
                p2WinsPanel.SetActive(true);
            }
            SceneManager.LoadScene("mainmenu");
        }
        
    }
}
