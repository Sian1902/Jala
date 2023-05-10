using System.Collections;
using System.Collections.Generic;
using System.Timers;
using Unity.VisualScripting;
using UnityEngine;

public class shake : MonoBehaviour
{
    public bool start = false;
    private void Update()
    {
        if (start)
        {
            start = false;
            StartCoroutine(shaking());
        }
    }
    IEnumerator shaking()
    {
        Vector2 startposition = transform.position;
        float elabsed = 0;
        while (elabsed < 1)
        {
            elabsed += Time.deltaTime;
            transform.position = startposition + Random.insideUnitCircle;

        }
        transform.position = startposition;
        yield return null;
    }
}
