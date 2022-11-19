using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class NumberBank : MonoBehaviour
{
    private List<string> originalNumbers = new List<string>() 
    {
        "882520222787826", "842699651066327", "248132371760981",
        "662555767924862", "542449383962739", "469202412593517",
        "474948690598465", "514201278055230", "322249340007401",
        "533374867459573", "488739932713720", "456599410249605",
        "9480999368503221", "743648675544669", "143648675544669"
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
