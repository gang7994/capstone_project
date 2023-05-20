using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence : MonoBehaviour
{
    public bool inclined, horizontal;
    public float max_hp = 100;
    public float hp = 100;
    
    public Material[] material;

    public int level = 0;

    void Update()
    {
        if(level >= 20) {
            gameObject.GetComponent<MeshRenderer>().material = material[1];
        }
        Check_Fence();
    }

    public void Check_Fence(){
        GameObject warning = transform.Find("SmokeBright").gameObject;
        GameObject danger1 = transform.Find("SmokeDark").gameObject;
        GameObject danger2 = transform.Find("RedFire").gameObject;

        if(hp > max_hp/2){
            warning.SetActive(false);
            danger1.SetActive(false);
            danger2.SetActive(false);
        }
        else if(hp <= max_hp/2 && hp > max_hp/4){
            warning.SetActive(true);
            danger1.SetActive(false);
            danger2.SetActive(false);
        }
        else if(hp <= 0) {
            Destroy(gameObject);
        }
        else{
            warning.SetActive(false);
            danger1.SetActive(true);
            danger2.SetActive(true);
        }
    }
/*
    // Update is called once per frame
    void Update()
    {
        Level_Manager(level);
    }
    
    public void Level_Manager(int level)
    {
        max_hp = 10 * level;
    }
    */

}
