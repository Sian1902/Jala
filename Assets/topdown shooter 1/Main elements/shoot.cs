using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class shoot : MonoBehaviour
{

    [SerializeField]
    Transform firepoint;
    [SerializeField]
    GameObject bulletbrefap;
    [SerializeField]
    float bulletforce = 2f;

    [SerializeField]
    GameObject player_object;
    [SerializeField]
    Camera scenecamera;
    [SerializeField] GameObject panel;
    Vector2 mouseposition;
    [SerializeField]float smooth = 5.0f;
    float tiltAngle = 90;
    void Update()
    {
    

        mouseposition = scenecamera.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetKeyDown(KeyCode.Space))
        {

            GameObject bullet = Instantiate(bulletbrefap, firepoint.position, firepoint.rotation);
            Rigidbody2D rb2 = bullet.GetComponent<Rigidbody2D>();
            rb2.AddForce(firepoint.right * bulletforce, ForceMode2D.Impulse);

        }
        move();
        // Smoothly tilts a transform towards a target rotation.
        float tiltAroundZ = tiltAngle;
       

        // Rotate the cube by converting the angles into a quaternion.
        Quaternion target = Quaternion.Euler(0, 0, tiltAroundZ);

        // Dampen towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
    
}
    void move()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {

            tiltAngle = 0;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            tiltAngle = 176.225f;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {

            tiltAngle = 270.364f;

        }
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            tiltAngle = 84.199f;

        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            panel.SetActive(true);
        }
    }
}


