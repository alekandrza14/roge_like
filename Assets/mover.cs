using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover : MonoBehaviour
{
    float tic; float tic2; float tic3;
    public Rigidbody2D rb;
    Vector3 v3;
    public Animator anim;

    void Update()
    {
        if (global.attack)
        {
            rb.velocity *= 0.99f;
            rb.mass = 4;
        }
        if (!global.attack)
        {
            
            rb.mass = 1;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && tic2 >= 0.5f)
        {
            anim.SetTrigger("attack");
            global.attack = true;
            tic2 = 0;
            tic3 = 1;
        }
        tic += Time.deltaTime; tic2 += Time.deltaTime; tic3 -= Time.deltaTime;
        if (tic3 <0)
        {

            global.attack = false;
        }
        v3 = Vector3.zero;
        if (Input.GetKey(KeyCode.W) && tic >= 0.125f)
        {
            v3 += (Vector3.up/8);
            
           
        }
        if (Input.GetKey(KeyCode.A) && tic >= 0.125f)
        {
            v3 +=  (Vector3.left/8);
           
        }
        if (Input.GetKey(KeyCode.S) && tic >= 0.125f)
        {
            v3 += - (Vector3.up / 8);
            
        }
        if (Input.GetKey(KeyCode.D) && tic >= 0.125f)
        {
            v3 += - (Vector3.left / 8);
            
        }
        if (Input.GetKey(KeyCode.D) && tic >= 0.125f || Input.GetKey(KeyCode.S) && tic >= 0.125f || Input.GetKey(KeyCode.A) && tic >= 0.125f || Input.GetKey(KeyCode.W) && tic >= 0.125f)
        {
            anim.SetFloat("x", v3.x * 8);
            anim.SetFloat("y", v3.y * 8);
            rb.MovePosition(transform.position + v3);
            v3 = Vector3.zero;
            tic = 0;
        }
        if (!Input.GetKey(KeyCode.D) && tic >= 0.125f || !Input.GetKey(KeyCode.S) && tic >= 0.125f || !Input.GetKey(KeyCode.A) && tic >= 0.125f || !Input.GetKey(KeyCode.W) && tic >= 0.125f)
        {
            anim.SetFloat("x", v3.x * 8);
            anim.SetFloat("y", v3.y * 8);
            v3 = Vector3.zero;
            tic = 0;
        }

    }
}
