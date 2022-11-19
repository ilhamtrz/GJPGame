using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostObject : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode KeyToPressed;
    public int forPlayer;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyToPressed))
        {
            if (canBePressed)
            {
                gameObject.SetActive(false);
                KarateGameManager.instance.GhostHit();
                if(forPlayer == 1)
                {
                    KarateGameManager.instance.scoreP1++;
                }
                else
                {
                    KarateGameManager.instance.scoreP2++;
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Activator")
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Activator")
        {
            canBePressed = false;
            KarateGameManager.instance.GhostMissed();
        }
    }
}
