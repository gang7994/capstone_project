using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build_Manager : MonoBehaviour
{
    public Camera getCamera;
    private RaycastHit hit;

    public bool isBuild_tower = true;
    public bool isBuild_fence = true;
    public int max_number_of_Tower = 3;
    public int max_number_of_Fence = 3;
    public int current_number_of_Tower = 0;
    public int current_number_of_Fence = 0;
    public string select_tower;
    public string select_fence;
    public int build_num = 0;

    public GameObject Building_Panel_Button;
    public GameObject Destory_Button;

    public string objectname;


    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = getCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "Tower")
            {
                select_tower = hit.collider.gameObject.name;
                Building_Click(true);
                objectname = hit.collider.gameObject.name;

            }
            else if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "Fence")
            {
                select_fence = hit.collider.gameObject.name;
                Building_Click(true);
                objectname = hit.collider.gameObject.name;
            }
            else if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "Map")
            {
                Building_Click(false);
            }
        }
    }

    public void Building_Click(bool isClick)
    {
        if (isClick)
        {
            Building_Panel_Button.SetActive(true);
            Destory_Button.SetActive(true);
        }
        else
        {
            Building_Panel_Button.SetActive(false);
            Destory_Button.SetActive(false);
        }
    }

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
        if (current_number_of_Tower > 0){
            Destroy(GameObject.Find(select_tower));
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
            Destroy(GameObject.Find(select_fence));
            current_number_of_Fence -= 1;
            isBuild_fence = true;
        }
    }

    
}
