using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrance : MonoBehaviour
{
    public string lastExitTime;
    void Start()
    {
        if(PlayerPrefs.GetString("LastExitName") == lastExitTime)
        {
            PlayScript.instance.transform.position = transform.position;
            PlayScript.instance.transform.eulerAngles = transform.eulerAngles;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
