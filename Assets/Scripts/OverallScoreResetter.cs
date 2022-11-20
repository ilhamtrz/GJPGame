using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverallScoreResetter : MonoBehaviour
{
    public ScoreOverallSO scoreSO;

    private void OnApplicationQuit()
    {
        Reset();
    }

    private void Reset()
    {
        scoreSO.p1Score = 0;
        scoreSO.p1Score = 0;
    }
}
