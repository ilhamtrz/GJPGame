using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverallScoreResetter : MonoBehaviour
{
    public ScoreOverallSO scoreSO;

    private void OnApplicationQuit()
    {
        ResetScoreOverall();
    }

    public void ResetScoreOverall()
    {
        scoreSO.p1Score = 0;
        scoreSO.p2Score = 0;
    }
}
