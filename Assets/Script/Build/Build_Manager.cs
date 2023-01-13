using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build_Manager : MonoBehaviour
{
    public bool isBuild_tower = true;
    public bool isBuild_fence = true;
    public int max_number_of_Tower = 3;
    public int max_number_of_Fence = 3;
    public int current_number_of_Tower = 0;
    public int current_number_of_Fence = 0;
    public int select_tower = 0;
    public int select_fence = 0;

    public void AddTower()
    {
        if (isBuild_tower)
        {
            current_number_of_Tower += 1;
            if(current_number_of_Tower == max_number_of_Tower) isBuild_tower = false;
        }
    }
    public void RemoveTower()
    {
        print("current"+ current_number_of_Tower);
        print("select" + select_tower);

        if (current_number_of_Tower > 0){
            if (select_tower == 1) Destroy(GameObject.Find("tower1"));
            else if (select_tower == 2) Destroy(GameObject.Find("tower2"));
            else if (select_tower == 3) Destroy(GameObject.Find("tower3"));
            current_number_of_Tower -= 1;
            isBuild_tower = true;
        }
    }
    public void AddFence()
    {
        if (current_number_of_Fence < max_number_of_Fence)
        {
            current_number_of_Fence += 1;
        }
        else isBuild_fence = false;
    }
    public void RemoveFence()
    {
        if (current_number_of_Fence > 0)
        {
            current_number_of_Fence -= 1;
            isBuild_fence = true;
        }
    }
}
