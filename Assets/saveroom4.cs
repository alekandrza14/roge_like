using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
public class saveother
{
    public Vector2Int point;
    public decimal syier;
    public string syierdata;
    public string[] skils;
    public string save(Vector2Int point)
    {
        saveother s = this;
        
        s.syierdata = syier.ToString();
        s.point = point;
        s.skils = global.skils;
        

        return JsonUtility.ToJson(s);
    }
    public Vector2Int load(string point)
    {
        saveother s = JsonUtility.FromJson<saveother>(point);
        return s.point;
    }
    public decimal loadsyier(string point)
    {
        saveother s = JsonUtility.FromJson<saveother>(point);
        s.syier = decimal.Parse(s.syierdata);
        return s.syier;
    }
    public saveother loadall(string point)
    {
        saveother s = JsonUtility.FromJson<saveother>(point);
        s.syier = decimal.Parse(s.syierdata);
        return s;
    }
}

public class saveroom4 : MonoBehaviour
{
    public void save()
    {
        saveother s = new saveother();
        if (File.Exists("save.data"))
        {


            s = s.loadall(File.ReadAllText("save.data"));
        }
        s.syier = global.syier;
        File.WriteAllText("save.data",s.save(global.point));
    }
}
