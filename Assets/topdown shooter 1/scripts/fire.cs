using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fire : MonoBehaviour
{
    

 
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("enemy")){
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
