using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shop : MonoBehaviour
{
    public Button[] buttons;
    public Button select;
    public bool ya;
    List<string> skils = new List<string>();
    public void Update()
    {
        for (int i =0;i<buttons.Length;i++)
        {
            if (buttons[i].GetComponent<buton>().onclick())
            {


                select = buttons[i].GetComponent<buton>().onclick();
                buttons[i].GetComponent<buton>().select = null;
            }
        }
        if (select)
        {
            if (decimal.Parse(select.GetComponent<buton>().cost.text) <= global.syier)
            {
                global.syier -= decimal.Parse(select.GetComponent<buton>().cost.text);
                ya = true;
            }
        }
        if (ya)
        {
            if (!global.getskil(select.GetComponent<buton>().neme.text))
            {
                skils.Clear();
                foreach (string s in global.skils)
                {
                    skils.Add(s);
                }
                skils.Add(select.GetComponent<buton>().neme.text);
                global.skils = skils.ToArray();
            }
            select = null;
            ya = false;
        }
    }
    
}
