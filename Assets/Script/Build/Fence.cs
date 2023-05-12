using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence : MonoBehaviour
{
    public float max_hp = 100;
    public float hp = 100;
    
    public Material[] material;

    public int level = 0;
    void Start()
    {
        //gameObject.GetComponent<MeshRenderer>().material = material[0];
    }
    void Update()
    {
        if(level >= 20) {
            gameObject.GetComponent<MeshRenderer>().material = material[1];
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
