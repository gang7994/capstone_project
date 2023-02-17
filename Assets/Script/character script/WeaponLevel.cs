using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public Text SwordLevel;
    public GameObject TypeIcon1, TypeIcon2, TypeIcon3, TypeIcon4, TypeIcon5;

    public int SL;

    void Start()
    {
        SwordLevel.GetComponent<Text>().text = "Level : 1";

        SL = 1;
        TypeIcon2.SetActive(false);
        TypeIcon3.SetActive(false);
        TypeIcon4.SetActive(false);
        TypeIcon5.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(SL > 4)
        {
            TypeIcon2.SetActive(true);
        }
        if (SL > 9)
        {
            TypeIcon3.SetActive(true);
        }
        if(SL > 14)
        {
            TypeIcon4.SetActive(true);
        }
        if(SL > 19)
        {
            TypeIcon5.SetActive(true);
        }
    }
    public void LevelUp_Sword()
    {
        SL++;
        SwordLevel.GetComponent<Text>().text = "Level : " + SL;
    }
}
