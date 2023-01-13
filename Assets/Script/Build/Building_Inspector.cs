using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building_Inspector : MonoBehaviour
{
    public Camera getCamera;
    private RaycastHit hit;

    public GameObject Building_Panel_Button;
    public GameObject Destory_Button;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            Ray ray = getCamera.ScreenPointToRay(Input.mousePosition);
            print("dsdsd");
            //print(GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().select_tower);
            if(Physics.Raycast(ray, out hit)&& hit.collider.gameObject.name =="tower1")
            {
                GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().select_tower = 1;
                Building_Click(true);
                print(GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().select_tower);
                
            }
            else if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.name == "tower2")
            {
                GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().select_tower = 2;
                Building_Click(true);
                
            }
            else if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.name == "tower3")
            {
                GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().select_tower = 3;
                Building_Click(true);
                
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
}
