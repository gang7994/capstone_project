using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence : MonoBehaviour
{
    public float durability = 100;
    public float hp = 100;
    
    public int level = 0;
    void Start()
    {
        
    }
/*
    // Update is called once per frame
    void Update()
    {
        Level_Manager(level);
    }
    
    public void Level_Manager(int level)
    {
        durability = 10 * level;
    }
    */

}
