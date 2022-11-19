using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneExit : MonoBehaviour
{
    public string sceneToLoad;
    public string exitName;
    private void OnTriggerEnter(Collider other)
    {
        if (Input.GetKey(KeyCode.C)) {

            PlayerPrefs.SetString("LastExitName", exitName);
            SceneManager.LoadScene(sceneToLoad);

        }
        
    }

    public void LeaveScene()
    {
        SceneManager.LoadScene("Rizzik");
        PlayerPrefs.SetString("LastExitName", "test1");
    }
}
