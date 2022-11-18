using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class expolusion : MonoBehaviour
{
    
    void Start()
    {
        Rigidbody2D r = GetComponent<Rigidbody2D>();
        r.AddForce(new Vector3(Random.Range(-30f, 30f), Random.Range(-30f, 30f)));
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (global.attack && collision.collider.GetComponent<mover>())
        {
            Rigidbody2D r = GetComponent<Rigidbody2D>();
            r.AddForce(new Vector3(Random.Range(-30f, 30f), Random.Range(-30f, 30f)));
        }
    }
}
