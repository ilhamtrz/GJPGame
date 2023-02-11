using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrance : MonoBehaviour
{
    public string lastExitTime;
    public GameObject Dialogue;
    void Start()
    {
        if(PlayerPrefs.GetString("LastExitName") == lastExitTime)
        {
            PlayScript.instance.transform.position = transform.position;
            PlayScript.instance.transform.eulerAngles = transform.eulerAngles;
            Dialogue.SetActive(false);
            GameplayManager.Instance.bgm.start();
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
