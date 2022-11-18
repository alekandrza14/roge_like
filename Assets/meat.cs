using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meat : MonoBehaviour
{
    public GameObject damage;
    public GameObject blood;
    public int multyply =1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (global.attack && collision.collider.GetComponent<mover>())
        {
            Instantiate(damage, transform.position, Quaternion.identity);
            for (int i = 0; i < Random.Range(2,6) * multyply; i++)
            {
                Instantiate(blood, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
