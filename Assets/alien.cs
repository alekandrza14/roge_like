using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class alien : MonoBehaviour
{
    public GameObject damage;
    public GameObject[] phisics;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<mover>())
        {
            saveother s = new saveother();
            global.point = s.load(File.ReadAllText("save.data"));
            global.move = Vector2Int.zero;
            
            SceneManager.LoadSceneAsync(1);
        }
    }
    private void Update()
    {
        float dist = Vector3.Distance(transform.position,FindObjectOfType<mover>().transform.position);
        Vector3 v3 = transform.position - FindObjectOfType<mover>().transform.position;
        transform.position -= (v3 / dist)*(Time.deltaTime);
        if (dist <= 2.5f && global.attack)
        {
            Instantiate(damage,transform.position,Quaternion.identity);
            for (int i =0;i<phisics.Length;i++)
            {
                Instantiate(phisics[i], transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
