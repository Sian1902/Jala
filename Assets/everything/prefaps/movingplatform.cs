using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class movingplatform : MonoBehaviour
{
    Rigidbody2D rig;
    [SerializeField] float speed;
    [SerializeField] float seconds;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        StartCoroutine(wait());
    }

    // Update is called once per frame
    void Update()
    {
        rig.velocity = new Vector2(speed, 0);
        
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }

}
