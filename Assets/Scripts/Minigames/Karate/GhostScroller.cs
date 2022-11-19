using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostScroller : MonoBehaviour
{
    public float beatTempo;
    public bool hasStarted;
    public GameObject border;
    public GameObject howToPlayPanel;
    // Start is called before the first frame update
    void Start()
    {
        beatTempo = beatTempo / 60f;
        hasStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasStarted)
        {
            /*if (Input.anyKeyDown)
            {
                hasStarted = true;
                howToPlayPanel.SetActive(false);
                border.SetActive(true);
            }*/
            transform.position += new Vector3(0f, 0f, beatTempo * Time.deltaTime);
        }
    }
}
