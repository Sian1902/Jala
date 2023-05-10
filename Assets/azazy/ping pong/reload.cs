using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reload : MonoBehaviour
{
   public void reloadscene()
    {
         Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        Time.timeScale= 1.0f;   
       // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
