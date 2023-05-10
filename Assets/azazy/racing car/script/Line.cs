using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Line : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float linespeed;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
	{
        if (transform.position.y < -4.5)
        {
            transform.position = new Vector2(0, 5.5f);
        }
        rb.velocity = new Vector2(0, linespeed);
    }
}
