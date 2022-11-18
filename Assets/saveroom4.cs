using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
public class saveother
{
    public Vector2Int point;
    public string save(Vector2Int point)
    {
        saveother s = new saveother();
        s.point = point;
        return JsonUtility.ToJson(s);
    }
    public Vector2Int load(string point)
    {
        saveother s = JsonUtility.FromJson<saveother>(point);
        return s.point;
    }
}

public class saveroom4 : MonoBehaviour
{
    public void save()
    {
        saveother s = new saveother();
        File.WriteAllText("save.data",s.save(global.point));
    }
}
