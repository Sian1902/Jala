using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class LoadScenes : MonoBehaviour
{
	[SerializeField] Animator transtioans;
	[SerializeField] int sceneIndex;
	[SerializeField] int oldIndex;
	[SerializeField] float timeDelay;
	float clock = 30;
	private void FixedUpdate()
	{
        //clock -= Time.deltaTime;
        if (clock <= 0)
        {
            //sceneIndex = Random.Range(0, sceneIndex);
            //if(oldIndex == sceneIndex && sceneIndex < 3)
            //{
            //	sceneIndex++;
            //}
            //else
            //{
            //	oldIndex = sceneIndex;
            //}

            StartCoroutine(StartTransition());
            clock = 30;
        }
    }
	IEnumerator StartTransition()
	{
		transtioans.SetTrigger("end");
        yield return new WaitForSeconds(timeDelay);
		SceneManager.LoadScene(sceneIndex);
    }
}
