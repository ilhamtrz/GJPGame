using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Score Overall", menuName = "Score Overall")]
public class ScoreOverallSO : ScriptableObject
{


    public int p1Score;
    public int p2Score;
    public int playCount = 0;
    public bool switchedOn = false;
}
