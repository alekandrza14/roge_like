using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dub : MonoBehaviour
{
    public int dubs = 2;
    void Start()
    {
        if (Random.Range(0,4) ==0 && dubs >=0)
        {
            Instantiate(gameObject, transform.position,Quaternion.identity);
        }
        if (dubs < 0)
        {
            Destroy(gameObject);
        }
    }
}
