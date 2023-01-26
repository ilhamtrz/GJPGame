using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crow : MonoBehaviour
{
    public float speed;
    public bool leftDirection;
    public int point = -1;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("TargetBorder"))
        {
            /*Destroy(gameObject);*/
            gameObject.SetActive(false);
            
        }
    }


    // Update is called once per frame
    void Update()
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

    public void Die()
    {
        gameObject.SetActive(false);
    }
}
