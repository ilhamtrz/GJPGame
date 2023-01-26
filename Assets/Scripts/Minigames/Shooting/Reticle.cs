using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reticle : MonoBehaviour
{
    public float speed;
    public bool isP1;


    // Update is called once per frame
    void Update()
    {
        if (isP1)
        {
            if (Input.GetKey(KeyCode.A))
            {
                gameObject.transform.position -= new Vector3(speed, 0f, 0f);
            }
            if (Input.GetKey(KeyCode.D))
            {
                gameObject.transform.position += new Vector3(speed, 0f, 0f);
            }
            if (Input.GetKey(KeyCode.W))
            {
                gameObject.transform.position += new Vector3(0f, speed, 0f);
            }
            if (Input.GetKey(KeyCode.S))
            {
                gameObject.transform.position -= new Vector3(0f, speed, 0f);
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                gameObject.transform.position -= new Vector3(speed, 0f, 0f);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                gameObject.transform.position += new Vector3(speed, 0f, 0f);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                gameObject.transform.position += new Vector3(0f, speed, 0f);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                gameObject.transform.position -= new Vector3(0f, speed, 0f);
            }
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out hit))
        {
            Debug.Log(hit.transform.tag);

            TargetMover target = hit.transform.GetComponent<TargetMover>();
            Crow crow = hit.transform.GetComponent<Crow>();
            if(target != null)
            {
                target.Die();
            }
            if(crow != null)
            {
                crow.Die();
            }
        }
        
    }
}
