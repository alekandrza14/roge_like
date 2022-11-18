using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mover : MonoBehaviour
{
    float tic; float tic2; float tic3; float tic4;
    public Rigidbody2D rb;
    public GameObject fire;
    Vector3 v3;
    float termo;
  public float gettermo;
    public Text txt;
    public Animator anim;
    public void Start()
    {
        termo = global.termo;
    }

    void Update()
    {
        txt.text = global.syier.ToString();
        if (Input.GetKeyDown(KeyCode.Tab))
        {
           global. autoclick = !global.autoclick;
        }
        if (global.autoclick)
        {
            anim.SetTrigger("attack");
            global.attack = true;
            tic2 = 0;
            tic3 = 1;
        }
        if (global.attack)
        {
            rb.velocity *= 0.99f;
            rb.mass = 4;
            if (global.termo > 30)
            {
                
                rb.velocity *= 0.89f;
                rb.mass = 8;
                tic3 = 3;
            }
            if (global.termo > 35)
            {
                Instantiate(fire, transform.position, Quaternion.identity);
            }
            if (global.termo > 35)
            {


                termo -= 0.2f;
                global.termo = (int)termo;
                gettermo = global.termo;
            }
            anim.SetTrigger("attack");
        }
        if (!global.attack)
        {
            
            rb.mass = 1;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && tic2 >= 0.5f)
        {
            
            global.attack = true;
            if (global.termo > 20)
            {
                Instantiate(fire, transform.position, Quaternion.identity);

                tic3 = 3;
            }
            if (global.termo > 30)
            {
                Instantiate(fire, transform.position, Quaternion.identity);
            }
            tic2 = 0;
            tic3 = 1;
        }
        if (termo > 0) {
            tic4 += Time.deltaTime;
        }
        if (termo >= 0)
        {

            global.termo = (int)termo;
            gettermo = global.termo;
            termo -= Time.deltaTime;
        }
        if (termo >= 0 && tic4 >= 5)
        {
            global.termo = (int)termo;
            gettermo = global.termo;

            termo -= Time.deltaTime*10;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && !global.autoclick && global.getskil("overcharge"))
        {
            termo+= 1f;
            
            global.termo = (int)termo;
         gettermo  = global.termo;
            tic4 = 0;
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
