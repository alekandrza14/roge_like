using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
    float tic = 1;
    public int dublic;
    bool g = false;
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (global.attack && global.termo > 40)
        {
            tic -= 0.7f;
            if (gameObject.GetComponents<dub>().Length <2)
            {
                gameObject.AddComponent<dub>().dubs -= dublic;
            }
            if (gameObject.GetComponents<expolusion>().Length < 2)
            {
                gameObject.AddComponent<expolusion>();
                gameObject.AddComponent<expolusion>();
            }

                g = true;
        }
       
            tic -= 0.8f; if (gameObject.GetComponents<dub>().Length < 2)
        {
            gameObject.AddComponent<dub>().dubs -= dublic;
        }
        if (gameObject.GetComponents<expolusion>().Length < 2)
        {
            gameObject.AddComponent<expolusion>();
            gameObject.AddComponent<expolusion>();
        }

        g = false;

    }
    void FixedUpdate()
    {
        GetComponent<BoxCollider2D>().isTrigger = !GetComponent<BoxCollider2D>().isTrigger;
        GetComponent<Rigidbody2D>().mass = Random.Range(0.25f, 2f);
        if (Random.Range(0, 120) == 1)
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
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, tic);
        }
        transform.localScale = Vector3.one * Random.Range(1f, 3f);
        transform.position += Vector3.one * Random.Range(-0.1f, 0.1f);

    }
}
