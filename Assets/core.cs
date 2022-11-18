using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class core : MonoBehaviour
{
    public GameObject damage;
    public GameObject[] phisics;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (global.attack && collision.collider.GetComponent<mover>())
        {
            Instantiate(damage, transform.position, Quaternion.identity);
            for (int i = 0; i < phisics.Length; i++)
            {
                Instantiate(phisics[i], transform.position, Quaternion.identity);
            }
            @event.destroycore = true;
            Destroy(gameObject);
        }
    }

    
}
