using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RacingCar : MonoBehaviour
{
    [SerializeField] GameObject[] carPrefab;
    [SerializeField] float timeDelay;
    [SerializeField] GameObject[] position;
    [SerializeField] float maxspeedcar;
    [SerializeField] float minspeedcar;

    private void Start()
    {
        StartCoroutine(Cars());
    }
    
    IEnumerator Cars()
    {
        while (true)
        {
            Vector2 pos = new Vector2(position[Random.Range(0, position.Length)].transform.position.x, transform.position.y - 3);
            carPrefab[Random.Range(0, carPrefab.Length)].gameObject.GetComponent<Rigidbody2D>().gravityScale = Random.Range(minspeedcar, maxspeedcar);
            GameObject carInstantiate = Instantiate(carPrefab[Random.Range(0, carPrefab.Length)], pos, Quaternion.identity);
            yield return new WaitForSeconds(timeDelay);
            Destroy(carInstantiate, 5f);
        }
    }
}