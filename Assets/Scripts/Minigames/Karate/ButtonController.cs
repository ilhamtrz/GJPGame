using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public KeyCode keyToPress;

    private MeshRenderer MR;
    public Material defaultMaterial;
    public Material pressedMaterial;
    public GameObject lightt;
    // Start is called before the first frame update
    void Start()
    {
        MR = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            MR.material = pressedMaterial;
            lightt.SetActive(false);
           
        }
        if (Input.GetKeyUp(keyToPress))
        {
            MR.material = defaultMaterial;
            lightt.SetActive(true);
        }
    }
}
