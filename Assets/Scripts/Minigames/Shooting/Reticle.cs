using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticle : MonoBehaviour
{
    public float speed;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            gameObject.transform.position -= new Vector3(speed, 0f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            gameObject.transform.position += new Vector3(speed, 0f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            gameObject.transform.position += new Vector3(0f,speed, 0f);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            gameObject.transform.position -= new Vector3(0f, speed, 0f);
        }
    }
}
