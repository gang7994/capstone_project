using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponLevel : MonoBehaviour
{
    // Start is called before the first frame update
    private Text levelText, goldText, playerInfo;
    public GameObject TypeIcon1, TypeIcon2, TypeIcon3, TypeIcon4, TypeIcon5;
    public GameObject TypeIcon1_N, TypeIcon2_N, TypeIcon3_N, TypeIcon4_N, TypeIcon5_N;
    private int cost = 100;
    private AudioSource levelUpSound;

    public int SL;

    void Start()
    {
        levelText = GameObject.Find("Level_Text").GetComponent<Text>();
        goldText = GameObject.Find("Upgrade_Gold_Weapon").GetComponent<Text>();
        playerInfo = GameObject.Find("Player_Info").GetComponent<Text>();
        SL = 1;
        levelUpSound = GetComponent<AudioSource>();

        TypeIcon1_N.SetActive(true);
        TypeIcon2_N.SetActive(true);
        TypeIcon3_N.SetActive(true);
        TypeIcon4_N.SetActive(true);
        TypeIcon5_N.SetActive(true);
    }

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
        playerInfo.text = GameObject.Find("MainCharacter").GetComponent<Player>().Health.ToString() + "\n\n" + 
                        GameObject.Find("MainCharacter").GetComponent<Player>().weapon_atkVal.ToString() + "\n";

        
    }
    public void LevelUp_Sword()
    {
        if(SL < 25){
            SL++;
            levelText.text = "레벨 : "+SL;
            GameObject.Find("Main Camera").GetComponent<GameManager>().money -= cost;
            cost += 500;
            goldText.text = cost.ToString();
            GameObject.Find("MainCharacter").GetComponent<Player>().weapon_atkVal += 10;
            if(SL == 25) levelText.text += "(최대)";
            if(SL % 5 == 0) levelUpSound.Play();
        }

    }
}
