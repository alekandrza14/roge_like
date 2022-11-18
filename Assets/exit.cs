using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exit : MonoBehaviour
{
    public GameObject alien;
    private void Start()
    {
        if (transform.position.x > 1 && global.move.x == -1)
        {
            FindObjectOfType<mover>().transform.position = transform.position - (Vector3.right * 2);
        }
        if (transform.position.x < -1 && global.move.x == 1)
        {
            FindObjectOfType<mover>().transform.position = transform.position + (Vector3.right * 2);
        }
        if (transform.position.y > 1 && global.move.y == -1)
        {
            FindObjectOfType<mover>().transform.position = transform.position - (Vector3.up * 2);
        }
        if (transform.position.y < -1 && global.move.y == 1)
        {
            FindObjectOfType<mover>().transform.position = transform.position + (Vector3.up * 2);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.GetComponent<mover>())
        {


            if (transform.position.x > 1)
            {
                global.point.x += 1;

                global.move.x = 1;
                global.move.y = 0;
            }
            if (transform.position.x < -1)
            {
                global.point.x -= 1;

                global.move.x = -1;
                global.move.y = 0;
            }
            if (transform.position.y > 1)
            {
                global.point.y += 1;

                global.move.y = 1;
                global.move.x = 0;
            }
            if (transform.position.y < -1)
            {
                global.point.y -= 1;

                global.move.y = -1;
                global.move.x = 0;
            }
            Debug.Log(global.point);
            SceneManager.LoadSceneAsync(1);
        }
    }
    float tic;
    public void Update()
    {
        float dist = Vector3.Distance(transform.position, FindObjectOfType<mover>().transform.position);
        tic += Time.deltaTime;
        if (@event.destroycore)
        {
            tic += Time.deltaTime *3;
            if (Random.Range(0,1000)==0)
            {
                @event.destroycore = false;
            }
        }
        if (tic >= 1 && dist >= 2.6f && FindObjectsOfType<NOSPAWN>().Length ==0)
        {


            if (Random.Range(0, 10) == 0)
            {


                if (transform.position.x > 0)
                {
                    Instantiate(alien, transform.position, Quaternion.identity);
                }
            }
            if (Random.Range(0, 10) == 0)
            {

                if (transform.position.x < 0)
                {
                    Instantiate(alien, transform.position, Quaternion.identity);
                }
            }
            if (Random.Range(0, 10) == 0)
            {

                if (transform.position.y > 0)
                {
                    Instantiate(alien, transform.position, Quaternion.identity);
                }
            }
            if (Random.Range(0, 10) == 0)
            {

                if (transform.position.y < 0)
                {
                    Instantiate(alien, transform.position, Quaternion.identity);
                }
            }
            tic = 0;
        }

    }
}
