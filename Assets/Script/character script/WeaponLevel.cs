using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public Text SwordLevel;

    public int SL;

    void Start()
    {
        SwordLevel.GetComponent<Text>().text = "Level : 1";

        SL = 1;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LevelUp_Sword()
    {
        SL++;
        SwordLevel.GetComponent<Text>().text = "Level : " + SL;
    }
}
