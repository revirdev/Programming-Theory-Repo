using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameLocation : MonoBehaviour
{
    int i = 0;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Touch " + other.name);
        i++;
    }

    private void Update()
    {
        if (i == 1)
        {
            StartCoroutine(Play());
            i++;
        }    
    }

    IEnumerator Play()
    {
        yield return new WaitForSeconds(3);
        Debug.Log("Play");
    }


}
