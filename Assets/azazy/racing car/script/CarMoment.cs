using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMoment : MonoBehaviour
{
    [SerializeField] float movespeedX;
    [SerializeField] float movespeedY;
    Rigidbody2D rb;
    Vector2 playermove;
    [SerializeField] GameObject wallDisconected,panel;
    bool hit = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
       
        playermove.y = Input.GetAxisRaw("Vertical");
        playermove.x = Input.GetAxisRaw("Horizontal");
      
    }

    private void FixedUpdate()
    {
       if(!hit)
        rb.velocity = new Vector2(playermove.x * movespeedX, playermove.y * movespeedY);
        else
        {
            rb.velocity = new Vector2(0, -10);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           hit= true;
            wallDisconected.SetActive(false);
            Invoke("panelactive", 0.5f);
        }
    }
    public void panelactive()
    {
        panel.SetActive(true);
    }
}