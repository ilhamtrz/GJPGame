using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crow : MonoBehaviour
{
    public ShootingGameManager gameManager;
    public float speed;
    public bool leftDirection;
    public int point = -1;
    private Rigidbody rb;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("TargetBorder"))
        {
            /*Destroy(gameObject);*/
            gameObject.SetActive(false);
            
        }
    }

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameStart)
        {
            if (leftDirection)
            {
                gameObject.transform.position -= new Vector3(speed, 0f, 0f);
            }
            else
            {
                gameObject.transform.position += new Vector3(speed, 0f, 0f);
            }
        }
        else
        {
            speed = 0;
            rb.constraints = RigidbodyConstraints.FreezePosition;
        }
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }
}
