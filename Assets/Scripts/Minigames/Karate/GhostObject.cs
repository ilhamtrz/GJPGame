using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostObject : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode KeyToPressed;
    public int forPlayer;

    public GameObject hitEffect;
    public GameObject missEffect;
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
                Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
                
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
        if(other.tag == "MissBorder")
        {
            gameObject.SetActive(false);
            Instantiate(missEffect, transform.position, missEffect.transform.rotation);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Activator")
        {
            canBePressed = false;
            KarateGameManager.instance.GhostMissed();
            gameObject.SetActive(false);
            Instantiate(missEffect, transform.position, missEffect.transform.rotation);
        }
    }
}
