using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class traider : MonoBehaviour
{
    public GameObject ui;
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.GetComponent<mover>() && Input.GetKey(KeyCode.Mouse1) && !FindObjectOfType<shop>())
        {

            Instantiate(ui,transform);
            
        }
    }
}
