using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public Text SwordLevel;
    public Text GunLevel;
    public Text ShotgunLevel;
    public int SL;
    public int GL;
    public int SGL;
    void Start()
    {
        SwordLevel.GetComponent<Text>().text = "Level : 1";
        GunLevel.GetComponent<Text>().text = "Level : 1";
        ShotgunLevel.GetComponent<Text>().text = "Level : 1";
        SL = 1;
        GL = 1;
        SGL = 1;
        
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
    public void LevelUp_Gun()
    {
        GL++;
        GunLevel.GetComponent<Text>().text = "Level : " + GL;
    }
    public void LevelUp_Shotgun()
    {
        SGL++;
        ShotgunLevel.GetComponent<Text>().text = "Level : " + SGL;
    }
}
