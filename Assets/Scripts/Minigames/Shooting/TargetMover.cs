using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMover : MonoBehaviour
{
    public float speed;
    public bool leftDirection;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("TargetBorder"))
        {
            /*Destroy(gameObject);*/
            gameObject.SetActive(false);
            Debug.Log("collide with border");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
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
}
