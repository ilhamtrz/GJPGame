using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmoDisplay : MonoBehaviour
{
    public TextMeshProUGUI ammoText;
    public Reticle player;
    private string reloadingText = "Reloading";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (player.currentAmmo == 0)
        {
            ammoText.text = reloadingText.ToString();
        }
        else
        {
            ammoText.text = player.currentAmmo.ToString();
        }
    }
}
