using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class games : MonoBehaviour
{
    public void pingpong()
    {
        SceneManager.LoadScene("ping pong game");

    }
    public void racing()
    {
        SceneManager.LoadScene("racing game");

    }
    public void platformer()
    {
        SceneManager.LoadScene("platformer");

    }
    public void shooter()
    {
        SceneManager.LoadScene("topdown shooter");

    }
}
