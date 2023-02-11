using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneExit : MonoBehaviour
{
    public string sceneToLoad;
    public string exitName;
    public GameObject UIPrompt;
    public ScoreOverallSO SO;

   
    private void OnTriggerStay(Collider other)
    {
        UIPrompt.SetActive(true);
        if (Input.GetKey(KeyCode.C)) {

            PlayerPrefs.SetString("LastExitName", exitName);
            SceneManager.LoadScene(sceneToLoad);
            GameplayManager.Instance.bgm.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            SO.playCount++;
        }
        
    }

    public void LeaveScene()
    {
        SceneManager.LoadScene("Rizzik");
        PlayerPrefs.SetString("LastExitName", "test1");
    }

    private void OnTriggerExit(Collider other)
    {
        UIPrompt.SetActive(false);
    }
}
