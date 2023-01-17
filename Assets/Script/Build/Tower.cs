using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public int durability = 100;
    public int attack_val = 10;
    public int slot_num = 0;
    public int level = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Level_Manager(level);
    }
    public void Level_Manager(int level)
    {
        durability = 10 * level;
        attack_val = level;
        slot_num = (level / 10);
    }
}
