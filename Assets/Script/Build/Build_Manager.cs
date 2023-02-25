using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Build_Manager : MonoBehaviour
{
    public Camera getCamera;
    private RaycastHit hit;

    public bool isBuild = true;

    public int max_number_of_Tower = 3;
    public int max_number_of_Fence = 3;
    public int current_number_of_Tower = 0;
    public int current_number_of_Fence = 0;
    public string select_tower;
    public string select_fence;
    public int build_num = 0;

    public Transform tilePrefab;
    public Vector2 mapSize;
    public int[,] build_Position = new int[13, 21];

    [Range(0,1)]
    public float outlinePercent;

    public GameObject Building_Panel_Button;
    public GameObject Destory_Button;

    private Text tower_num, fence_num;
    

    public string objectname;

    void Start()
    {
        tower_num = GameObject.Find("Tower_num").GetComponent<Text>(); 
        fence_num = GameObject.Find("Fence_num").GetComponent<Text>();

        build_Position = new int[(int)mapSize.y, (int)mapSize.x]; //행, 열
        for (int i = 0; i < (int)mapSize.y; i++)
        {
            for (int j = 0; j < (int)mapSize.x; j++)
            {
                build_Position[i, j] = 0; // 배열의 모든 요소를 0으로 초기화
            }
        }
    }
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
        tower_num.text = current_number_of_Tower.ToString() + "/" + max_number_of_Tower;
        fence_num.text = current_number_of_Fence.ToString() + "/" + max_number_of_Fence;


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
        if (isBuild)
        {
            current_number_of_Tower += 1;
            if(current_number_of_Tower == max_number_of_Tower) isBuild = false;
        }
    }
    public void RemoveTower()
    {
        if (current_number_of_Tower > 0){
            Destroy(GameObject.Find(select_tower));
            current_number_of_Tower -= 1;
            isBuild = true;
        }
    }
    public void AddFence()
    {
        if (current_number_of_Fence < max_number_of_Fence)
        {
            current_number_of_Fence += 1;
        }
        else isBuild = false;
    }
    public void RemoveFence()
    {
        if (current_number_of_Fence > 0)
        {
            Destroy(GameObject.Find(select_fence));
            current_number_of_Fence -= 1;
            isBuild = true;
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
