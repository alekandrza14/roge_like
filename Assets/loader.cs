using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loader : MonoBehaviour
{
    
    void Start()
    {
        if (File.Exists("save.data"))
        {


            saveother s = new saveother();
            global.point = s.load(File.ReadAllText("save.data"));
            global.move = Vector2Int.zero;
        }

        SceneManager.LoadSceneAsync(1);
    }

}
