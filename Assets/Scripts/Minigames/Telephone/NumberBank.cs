using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class NumberBank : MonoBehaviour
{
    private List<string> originalNumbers = new List<string>() 
    {
        "88252022278", "84269965106", "24813237176",
        "66255576792", "54244938396", "46920241259",
        "47494869059", "51420127805", "32224934000",
        "53337486743", "48873993271", "45659941024",
        "948099936850", "74364867554", "14364867554"
    };

    private List<string> workingNumbers = new List<string>();
    // Start is called before the first frame update
    private void Awake()
    {
        workingNumbers.AddRange(originalNumbers);
        Shuffle(workingNumbers);
    }

    private void Shuffle(List<string> list)
    {
        for(int i = 0; i < list.Count; i++)
        {
            int random = Random.Range(i, list.Count);
            string temporary = list[i];

            list[i] = list[random];
            list[random] = temporary;
        }
    }

    public string GetNumber()
    {
        string newNumber = string.Empty;

        if(workingNumbers.Count != 0)
        {
            newNumber = workingNumbers.Last();
            workingNumbers.Remove(newNumber);
        }

        return newNumber;
    }
}
