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

    public Transform tilePrefab;
    public Vector2 mapSize;

    [Range(0,1)]
    public float outlinePercent;

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

    public void GenerateMap() {
        string holderName = "Generated Map";
        Transform mapHolder = new GameObject (holderName).transform;
        mapHolder.parent = transform;

         for (int x = 0; x < mapSize.x; x ++) {
            for (int y = 0; y < mapSize.y; y ++) {
                Vector3 tilePosition = new Vector3(-mapSize.x/2 +1.5f + x*3-mapSize.x, 1, -mapSize.y/2 + 1.5f + y*3-mapSize.y);
                Transform newTile = Instantiate(tilePrefab, tilePosition, Quaternion.Euler(Vector3.right*90)) as Transform;
                newTile.localScale = Vector3.one *(1-outlinePercent)*3;
                newTile.parent = mapHolder;
            }
        }

    }

    public void ExitMap(){
        string holderName = "Generated Map";    
        if (transform.Find (holderName)) {
            DestroyImmediate(transform.Find(holderName).gameObject);
        }
    }
}
