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
    public int select_tower = 0;
    public int select_fence = 0;

    public GameObject Building_Panel_Button;
    public GameObject Destory_Button;

    public string objectname;
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = getCamera.ScreenPointToRay(Input.mousePosition);
            print("dsdsd");
            //print(GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().select_tower);
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.name == "tower1")
            {
                GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().select_tower = 1;
                Building_Click(true);
                print(GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().select_tower);
                objectname = "tower1";

            }
            else if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.name == "tower2")
            {
                GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().select_tower = 2;
                Building_Click(true);
                objectname = "tower2";

            }
            else if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.name == "tower3")
            {
                GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().select_tower = 3;
                Building_Click(true);
                objectname = "tower3";

            }

            else if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.name == "fence1")
            {
                GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().select_fence = 1;
                Building_Click(true);
                objectname = "fence1";

            }
            else if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.name == "fence2")
            {
                GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().select_fence = 2;
                Building_Click(true);
                objectname = "fence2";

            }

            else if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.name == "fence3")
            {
                GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().select_fence = 3;
                Building_Click(true);
                objectname = "fence3";

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
