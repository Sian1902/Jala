using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform : MonoBehaviour
{
    [SerializeField] GameObject[] waypoint;
    int waypointindex = 0;
    float speed = 2f;


    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, waypoint[waypointindex].transform.position) < 1)
        {
            waypointindex++;
            if(waypointindex>= waypoint.Length)
            {
                waypointindex= 0; 
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoint[waypointindex].transform.position, Time.deltaTime * speed);
        
    }
}
