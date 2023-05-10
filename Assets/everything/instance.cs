using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instance : MonoBehaviour
{

    public GameObject[] prefab;
    [SerializeField] float spawntime;
    [SerializeField] float upper,lower;
    // Update is called once per frame
    private void Start()
    {
        StartCoroutine(spawn());
    }
    void Update()
    {

        
    }

    IEnumerator spawn()
    {
        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(spawntime);
            spawnshit();
        }
    }
    public void spawnshit()
    {
        GameObject p = Instantiate(prefab[Random.Range(0,prefab.Length)]);
        p.transform.position = new Vector2(transform.position.x,Random.Range(transform.position.y - upper, transform.position.y + lower));
    }

}
