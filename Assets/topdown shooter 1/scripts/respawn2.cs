using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn2 : MonoBehaviour
{
    [SerializeField] GameObject[] g;
    Vector3 randomposition;
    float wait = 3;
    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
        wait -= Time.deltaTime;
        if (wait < 0)
        {
            wait = Random.Range(4,8);
            randomposition = new Vector3(transform.position.x,transform.position.y,transform.position.z);
            createobject(Random.Range(0, 3));
        }
    }
    void createobject(int x)
    {
     
        
            Instantiate(g[0], randomposition, Quaternion.identity);
        
        

    }
}
