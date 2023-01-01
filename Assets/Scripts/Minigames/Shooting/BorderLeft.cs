using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderLeft : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target"))
        {
            Debug.Log("kena target");
            Destroy(other);
        }
    }
}
