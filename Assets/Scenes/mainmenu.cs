using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class mainmenu : MonoBehaviour
{

    public void gotoscene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void quitapp()
    {
        Application.Quit();
        Debug.Log("app has quit");
    }
}
