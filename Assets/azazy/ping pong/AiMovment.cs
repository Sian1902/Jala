using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AiMovment : MonoBehaviour
{
	[SerializeField] Transform ball;
	Vector2 playerMove;
	Rigidbody2D rb;
    [SerializeField] float movespeed;

    private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}
	private void Update()
	{
		if(ball.transform.position.y > transform.position.y + 0.5)
		{
			playerMove.y = 1;
		}
		else if(ball.transform.position.y < transform.position.y - 0.5)
		{
			playerMove.y = -1;
		}
		else
		{
			playerMove.y = 0;
		}
	}
	private void FixedUpdate()
	{
		rb.velocity = playerMove * movespeed;
	}

}
