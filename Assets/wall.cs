using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour
{
    public GameObject exit;
    void Start()
    {
        if (transform.position.x == 0)
        {
            Instantiate(exit, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if (transform.position.y == 0)
        {
            Instantiate(exit, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    
}
