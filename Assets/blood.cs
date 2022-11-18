using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blood : MonoBehaviour
{
    float tic = 1;
    bool g = false;
    void FixedUpdate()
    {
        GetComponent<BoxCollider2D>().isTrigger = !GetComponent<BoxCollider2D>().isTrigger;
        GetComponent<Rigidbody2D>().mass = Random.Range(0.25f,2f);
        if (Random.Range(0,120)==1)
        {
            g = true;
        }
        if (tic < 0)
        {

            Destroy(gameObject);
        }
        if (g)
        {
            tic -= Time.deltaTime;
            GetComponent<SpriteRenderer>().color = new Color(1,1,1, tic);
        }

    }
}
