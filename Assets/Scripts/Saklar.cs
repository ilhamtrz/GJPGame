using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saklar : MonoBehaviour
{
    
    public GameObject Saklar1, Saklar2, Saklar3, Saklar4, Saklar5, Saklar6, Saklar7, Saklar8, Saklar9, Saklar10, Saklar11, Saklar12;
    public GameObject Font, Urgent;
    void Start()
    {
        Saklar1.SetActive(false);
        Saklar2.SetActive(false);
        Saklar3.SetActive(false);
        Saklar4.SetActive(false);
        Saklar5.SetActive(false);
        Saklar6.SetActive(false);
        Saklar7.SetActive(false);
        Saklar8.SetActive(false);
        Saklar9.SetActive(false);
        Saklar10.SetActive(false);
        Saklar11.SetActive(false);
        Saklar12.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                Saklar1.SetActive(true);
                Saklar2.SetActive(true);
                Saklar3.SetActive(true);
                Saklar4.SetActive(true);
                Saklar5.SetActive(true);
                Saklar6.SetActive(true);
                Saklar7.SetActive(true);
                Saklar8.SetActive(true);
                Saklar9.SetActive(true);
                Saklar10.SetActive(true);
                Saklar11.SetActive(true);
                Saklar12.SetActive(true);

                Font.SetActive(false);
                Urgent.SetActive(false);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                Saklar1.SetActive(true);
                Saklar2.SetActive(true);
                Saklar3.SetActive(true);
                Saklar4.SetActive(true);
                Saklar5.SetActive(true);
                Saklar6.SetActive(true);
                Saklar7.SetActive(true);
                Saklar8.SetActive(true);
                Saklar9.SetActive(true);
                Saklar10.SetActive(true);
                Saklar11.SetActive(true);
                Saklar12.SetActive(true);

                Font.SetActive(false);
                Urgent.SetActive(false);
            }
        }
    }
}
