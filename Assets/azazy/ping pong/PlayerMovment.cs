using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
	[SerializeField] float movespeed;
	Rigidbody2D rb;
	Vector2 playermove;
	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}
	private void Update()
	{
		playermove.y = Input.GetAxisRaw("Vertical");
	}
	private void FixedUpdate()
	{
		rb.velocity = playermove * movespeed;
	}
}
