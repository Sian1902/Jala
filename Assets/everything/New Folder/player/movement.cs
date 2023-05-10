using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class movement : MonoBehaviour
{
    Rigidbody2D rig;
    Animator anim;
    SpriteRenderer SpriteRenderer;
    Collider2D coll;
    int score = 0;
    float direction;
    [SerializeField] float speed;
    [SerializeField] float jumpforce;
    [SerializeField] LayerMask ground;
    [SerializeField] Text scorecount;
    [SerializeField] GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        SpriteRenderer = GetComponent<SpriteRenderer>();
        coll = GetComponent<Collider2D>();
        scorecount.text = "score"+" "+score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        direction = Input.GetAxis("Horizontal");
        if (direction > 0)
        {
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
            rig.velocity = new Vector2(direction*(speed-10),rig.velocity.y);
        }
        if (direction < 0)
        {
            transform.localScale = new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y);
            rig.velocity = new Vector2(direction * (speed-10), rig.velocity.y);
        }
        if (Input.GetButtonDown("Jump")&&isgrounded())
        {
            rig.velocity = new Vector2(rig.velocity.y, jumpforce);
            anim.SetTrigger("jump");
        }
        if (onwall()&&(transform.localScale.x > 0 && direction > 0 || transform.localScale.x < 0 && direction < 0))
        {
            rig.velocity = new Vector2(0, rig.velocity.y);
        }
        else
        {
            rig.velocity = new Vector2(direction * speed, rig.velocity.y);
        }
        if (isgrounded())
        {
            rig.velocity = rig.velocity - new Vector2(5, 0);
        }
        Debug.Log(score);
     

        //checkers
        anim.SetFloat("y_velocity", Mathf.Abs(rig.velocity.y));
        anim.SetFloat("x_velocity", Mathf.Abs(direction));
        anim.SetBool("isgrounded", isgrounded());
        anim.SetBool("onwall", onwall());
    }
    bool isgrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center,coll.bounds.size,0f,Vector2.down,0.1f,ground);
    }
    private bool onwall()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, new Vector2(transform.localScale.x, 0), 0.1f, ground);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("fire"))
        {
            anim.SetTrigger("dead");
            coll.enabled = false;
            Invoke("paneled", 3f);
        }
    }

    private void paneled()
    {
        panel.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("coins"))
        {
            score++;
            scorecount.text = "score" + " " + score.ToString();
            Destroy(collision.gameObject);
        }
    }

}
