using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponLevel : MonoBehaviour
{
    // Start is called before the first frame update
    private Text levelText;
    public GameObject TypeIcon1, TypeIcon2, TypeIcon3, TypeIcon4, TypeIcon5;
    public GameObject TypeIcon1_N, TypeIcon2_N, TypeIcon3_N, TypeIcon4_N, TypeIcon5_N;

    public int SL;

    void Start()
    {
        levelText = GameObject.Find("Level_Text").GetComponent<Text>();

        SL = 1;

        TypeIcon1_N.SetActive(true);
        TypeIcon2_N.SetActive(true);
        TypeIcon3_N.SetActive(true);
        TypeIcon4_N.SetActive(true);
        TypeIcon5_N.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        if(SL > 4)
        {
            TypeIcon1_N.SetActive(false);
            TypeIcon2_N.SetActive(true);
            TypeIcon3_N.SetActive(true);
            TypeIcon4_N.SetActive(true);
            TypeIcon5_N.SetActive(true);
        }
        if (SL > 9)
        {
            TypeIcon1_N.SetActive(false);
            TypeIcon2_N.SetActive(false);
            TypeIcon3_N.SetActive(true);
            TypeIcon4_N.SetActive(true);
            TypeIcon5_N.SetActive(true);
        }
        if(SL > 14)
        {
            TypeIcon1_N.SetActive(false);
            TypeIcon2_N.SetActive(false);
            TypeIcon3_N.SetActive(false);
            TypeIcon4_N.SetActive(true);
            TypeIcon5_N.SetActive(true);
        }
        if(SL > 19)
        {
            TypeIcon1_N.SetActive(false);
            TypeIcon2_N.SetActive(false);
            TypeIcon3_N.SetActive(false);
            TypeIcon4_N.SetActive(false);
            TypeIcon5_N.SetActive(true);
        }
        if(SL > 24){
            TypeIcon1_N.SetActive(false);
            TypeIcon2_N.SetActive(false);
            TypeIcon3_N.SetActive(false);
            TypeIcon4_N.SetActive(false);
            TypeIcon5_N.SetActive(false);
        }
        
    }
    public void LevelUp_Sword()
    {
        SL++;
        levelText.text = "레벨 : "+SL;
        if(SL == 25) levelText.text += "(최대)";
    }
}
