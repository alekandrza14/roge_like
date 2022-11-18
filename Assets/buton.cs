using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buton : MonoBehaviour
{
    public Button select;
    public Text neme;
    public Text cost;
    public void onClick()
    {
        select = GetComponent<Button>();
    }
    public Button onclick()
    {
        return select;
    }
}
