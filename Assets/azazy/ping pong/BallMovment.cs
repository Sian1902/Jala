using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovment : MonoBehaviour
{
	[SerializeField] float initialSpeed;
	[SerializeField] float increaseSpeed;
	float hitcounter;
	Rigidbody2D rb;
    float xDirection=1, yDirection;
	[SerializeField] GameObject panel;
    private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		Invoke("StartBall", 1);
	}
	private void FixedUpdate()
	{
		rb.velocity = Vector2.ClampMagnitude(rb.velocity, initialSpeed + (increaseSpeed * hitcounter));
	}
	void StartBall()
	{
		rb.velocity = new Vector2(1, 0) * (initialSpeed + increaseSpeed * hitcounter); 
	}
	void ResetBall()
	{
		rb.velocity = new Vector2(0, 0);
		transform.position = Vector2.zero;
		hitcounter = 0;
        Invoke("StartBall", 2);
    }
    void BallBounds(Transform myObject)
	{
		hitcounter++;
		Vector2 ballPos = transform.position;
		Vector2 playerPos = myObject.position;

	
		yDirection = (ballPos.y - playerPos.y) / myObject.GetComponent<Collider2D>().bounds.size.y;
		if(yDirection == 0)
		{
			yDirection = 0.25f;
		}
		rb.velocity = new Vector2(xDirection, yDirection) * (initialSpeed + (increaseSpeed * hitcounter));
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.name == "player 1" || collision.gameObject.name == "player 2")
		{
			BallBounds(collision.transform);
			xDirection = -xDirection;

        }
		else if ( collision.gameObject.name == "gole 2")
		{
			Time.timeScale = 0;
			panel.SetActive(true);
		}
        else if (collision.gameObject.name == "gole 1")
        {
			Time.timeScale = 0;
            panel.SetActive(true);


        }

    }
}
