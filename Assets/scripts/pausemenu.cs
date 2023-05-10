using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;
public class pausemenu : MonoBehaviour
{
    [SerializeField] GameObject PauseMenu;
    public bool pausing=false;

   public void pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        pausing = true;
        
        Debug.Log("pause");
    }
    public void resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        pausing = false;
    }
    public void home()
    {
        SceneManager.LoadScene("mainmenuscene");
        Time.timeScale = 1f;
    }
  

}
