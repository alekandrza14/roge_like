using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class saveroom
{
    public Vector2Int sizeroom;
    public Vector2Int sideroom;
    public float scale;
    public int idfoor;
}
public class global
{
    static public Vector2Int point;
    static public Vector2Int move;
    static public decimal syier;
    public static bool attack;
    static public string[] skils;
    public static bool autoclick;
    public static int termo;
    static public bool getskil(string skil)
    {
        if (skils != null)
        {
            if (skils.Length != 0)
            {


                for (int i = 0; i < skils.Length; i++)
                {
                    if (skils[i] == skil)
                    {
                        return true;
                    }
                }
            }
        }
            return false;
    }
}

public class gen : MonoBehaviour
{
    public GameObject[] tiles;
    public GameObject[] items;
    public Vector2Int sizeroom;
    public Vector2Int sideroom;
    public int idfoor;
    public float scale;
    bool generate;
    public void Rand()
    {
        scale += Random.Range(0, 0.01f);
        sizeroom.x += Random.Range(-2, 3);
        sizeroom.y += Random.Range(-1, 2);
        sideroom.x += Random.Range(-6, 6);
        sideroom.y += Random.Range(-6, 6);
        idfoor += Random.Range(0, 3);
    }
    public void load()
    {
        if (File.Exists("world/" + "x" + global.point.x + "y" + global.point.y))
        {
            saveroom sr = JsonUtility.FromJson<saveroom>(File.ReadAllText("world/" + "x" + global.point.x + "y" + global.point.y));
            sizeroom = sr.sizeroom;
            sideroom = sr.sideroom;
            scale = sr.scale;
            idfoor = sr.idfoor;
            generate = true;

        }
    }
    public void save()
    {
        Directory.CreateDirectory("world");
        if (!File.Exists("world/" + "x" + global.point.x + "y" + global.point.y))
        {


            saveroom sr = new saveroom();
            sr.scale = scale;
            sr.sideroom = sideroom;
            sr.sizeroom = sizeroom;
            sr.idfoor = idfoor;
            File.WriteAllText("world/" + "x" + global.point.x + "y" + global.point.y, JsonUtility.ToJson(sr));
        }
    }

    private void Awake()
    {
        Rand();
        load();
        save();
    }
    public int getwalltile()
    {
        int i = 1;
        if (idfoor == 0)
        {
            i = 1;
        }
        if (idfoor == 1)
        {
            i = 3;
        }
        if (idfoor == 2)
        {
            i = 4;
        }
        return i;
    }
    public int getfoortile()
    {
        int i = 1;
        if (idfoor == 0)
        {
            i = 0;
        }
        if (idfoor == 1)
        {
            i = 2;
        }
        if (idfoor == 2)
        {
            i = 5;
        }
        return i;
    }
    private void Start()
    {
        if (idfoor == 2 && !generate)
        {
            if (Random.Range(0, 3) == 0)
            {
                Vector2Int v2i = new Vector2Int(Random.Range(0, sizeroom.x), Random.Range(0, sizeroom.y));
                GameObject g = Instantiate(items[0], new Vector3(v2i.x, v2i.y, 0), Quaternion.identity);
                g.transform.position -= new Vector3(sizeroom.x / 2, sizeroom.y / 2);
            }
        }
        if (idfoor == 0)
        {
            if (Random.Range(0, 20) == 0)
            {
                Vector2Int v2i = new Vector2Int(Random.Range(0, sizeroom.x), Random.Range(0, sizeroom.y));
                GameObject g = Instantiate(items[1], new Vector3(v2i.x, v2i.y, 0), Quaternion.identity);
                g.transform.position -= new Vector3(sizeroom.x / 2, sizeroom.y / 2);
            }
        }
        if (idfoor == 2 && generate)
        {
            if (Random.Range(0, 40) == 0)
            {
                Vector2Int v2i = new Vector2Int(Random.Range(0, sizeroom.x), Random.Range(0, sizeroom.y));
                GameObject g = Instantiate(items[0], new Vector3(v2i.x, v2i.y, 0), Quaternion.identity);
                g.transform.position -= new Vector3(sizeroom.x / 2, sizeroom.y / 2);
            }
        }
        for (int x = 0; x < sizeroom.x; x++)
        {
            for (int y = 0; y < sizeroom.y; y++)
            {
                


                    Transform t = Instantiate(tiles[getfoortile()], gameObject.transform).GetComponent<Transform>();
                    t.position = new Vector3(x - (sizeroom.x / 2), y - (sizeroom.y / 2), 0);

                    t.position += transform.position;
                    Color c = t.GetComponent<SpriteRenderer>().color;
                    float t3 = Mathf.PerlinNoise(((float)(x + sideroom.x) * scale) + Random.Range(0, 0.1f), ((float)(y + sideroom.y) * scale) + Random.Range(0, 0.1f));
                    //  Debug.Log((t3,x,y));
                    t.GetComponent<SpriteRenderer>().color = c - (new Color(t3, t3, t3, 1) / 5f);
                
                
            }
        }
        for (int x = 0; x < sizeroom.y; x++)
        {

            Transform t = Instantiate(tiles[getwalltile()], gameObject.transform).GetComponent<Transform>();
            t.position = new Vector3((sizeroom.x / 2), x - (sizeroom.y / 2), 0);

            t.position += transform.position;

        }
        for (int x = 0; x < sizeroom.y; x++)
        {

            Transform t = Instantiate(tiles[getwalltile()], gameObject.transform).GetComponent<Transform>();
            t.position = new Vector3(-(sizeroom.x / 2), x - (sizeroom.y / 2), 0);

            t.position += transform.position;

        }
        for (int x = 0; x < sizeroom.x; x++)
        {

            Transform t = Instantiate(tiles[getwalltile()], gameObject.transform).GetComponent<Transform>();
            t.position = new Vector3(x - (sizeroom.x / 2), (sizeroom.y / 2), 0);

            t.position += transform.position;

        }
        for (int x = 0; x < sizeroom.x; x++)
        {

            Transform t = Instantiate(tiles[getwalltile()], gameObject.transform).GetComponent<Transform>();
            t.position = new Vector3(x - (sizeroom.x / 2), -(sizeroom.y / 2), 0);

            t.position += transform.position;

        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            SceneManager.LoadScene(1);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
