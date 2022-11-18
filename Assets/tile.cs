using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tile : MonoBehaviour
{
    public Sprite[] sp;
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = sp[Random.Range(0,sp.Length)];
    }
}
