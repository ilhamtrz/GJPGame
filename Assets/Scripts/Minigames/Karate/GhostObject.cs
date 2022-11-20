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
                if(transform.position.x == -3)
                {
                    //play left punch animation
                }
                else if(transform.position.x == 0)
                {
                    //play middle punch animation
                }
                else if(transform.position.x == 3)
                {
                    //play right punch animation
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        int random = Random.Range(0, 3);
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
