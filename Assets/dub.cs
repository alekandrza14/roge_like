using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dub : MonoBehaviour
{
    void Start()
    {
        if (Random.Range(0,4) ==0)
        {
            Instantiate(gameObject, transform.position,Quaternion.identity);
        }
    }
}
