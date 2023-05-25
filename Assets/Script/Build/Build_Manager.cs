using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Build_Manager : MonoBehaviour
{
    public Camera getCamera;
    private RaycastHit hit;

    public bool isBuild = true;

    public int current_number_of_Tower = 0;
    public int current_number_of_Fence = 0;

    public string select_Build;
    public Vector3 select_Build_Position;

    public int build_num = 0;

    public Transform tilePrefab;
    public Vector2 mapSize;
    public int[,] build_Position = new int[13, 21];
    public int[,] fence_vertical_position = new int[13,22];
    
    public int[,] fence_horizontal_position = new int[14,21];
    [Range(0,1)]
    public float outlinePercent;


    public GameObject Btn_Tower_Panel;
    public GameObject Btn_Fence_Panel;
    public GameObject BackGround;


    private Text tower_num, fence_num;

    void Start()
    {
        tower_num = GameObject.Find("Tower_num").GetComponent<Text>(); 
        fence_num = GameObject.Find("Fence_num").GetComponent<Text>();

        build_Position = new int[(int)mapSize.y, (int)mapSize.x];
        for (int i = 0; i < (int)mapSize.y; i++)
        {
            for (int j = 0; j < (int)mapSize.x; j++)
            {
                build_Position[i, j] = 0;
            }
        }
        for (int i = 0; i < (int)mapSize.y+1; i++)
        {
            for (int j = 0; j < (int)mapSize.x; j++)
            {
                fence_horizontal_position[i, j] = 0;
            }
        }
        for (int i = 0; i < (int)mapSize.y; i++)
        {
            for (int j = 0; j < (int)mapSize.x+1; j++)
            {
                fence_vertical_position[i, j] = 0;
            }
        }

        for(int i = 5; i< 8;i++){
            for(int j = 9;j < 12;j++) {
                build_Position[i, j] = 1;
            }
        }
        for(int i = 5; i< 8;i++){
            for(int j = 10;j < 12;j++) {
                fence_vertical_position[i, j] = 1;
            }
        }
        for(int i = 6; i< 8;i++){
            for(int j = 9;j < 12;j++) {
                fence_horizontal_position[i, j] = 1;
            }
        }
    }
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = getCamera.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.CompareTag("Tower") && !Btn_Tower_Panel.activeSelf && !Btn_Fence_Panel.activeSelf)
            {
                select_Build = hit.collider.gameObject.name;
                select_Build_Position = hit.collider.gameObject.transform.position;
                if(hit.collider.gameObject.GetComponent<Tower>().isOn) Tower_Click(true);
            }
            else if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.CompareTag("Fence") && !Btn_Tower_Panel.activeSelf && !Btn_Fence_Panel.activeSelf)
            {
                select_Build = hit.collider.gameObject.name;
                select_Build_Position = hit.collider.gameObject.transform.position;
                if(hit.collider.gameObject.GetComponent<Fence>().isOn) Fence_Click(true);

            }
        }

        tower_num.text = current_number_of_Tower.ToString() + "/" + GameObject.Find("Main Camera").GetComponent<Elemental>().tower_max;
        fence_num.text = current_number_of_Fence.ToString() + "/" + GameObject.Find("Main Camera").GetComponent<Elemental>().fence_max;


    }

    public void Tower_Click(bool isClick)
    {
        if (isClick)
        {
            Btn_Fence_Panel.SetActive(false);
            Btn_Tower_Panel.transform.position =new Vector3(960f + select_Build_Position.x*21.5f, 540f + select_Build_Position.z*21f, 0f);
            Btn_Tower_Panel.SetActive(true);
            
        }
        else
        {
            Btn_Tower_Panel.SetActive(false);
        }
    }

    public void Fence_Click(bool isClick)
    {
        if (isClick)
        {
            Btn_Tower_Panel.SetActive(false);
            Btn_Fence_Panel.transform.position = new Vector3(960f + select_Build_Position.x * 21.5f, 540f + select_Build_Position.z * 21f, 0f);
            Btn_Fence_Panel.SetActive(true);
        }
        else
        {
            Btn_Fence_Panel.SetActive(false);
        }
    }


    public void AddTower()
    {
        if (isBuild)
        {
            current_number_of_Tower += 1;
        }
    }
    public void RemoveTower()
    {
        if(GameObject.Find(select_Build).CompareTag("Tower")){
            if (current_number_of_Tower > 0){
                Destroy(GameObject.Find(select_Build));
                build_Position[(int)GameObject.Find(select_Build).transform.position.z / 3 + 6, (int)GameObject.Find(select_Build).transform.position.x / 3 + 10] = 0;
                current_number_of_Tower -= 1;
                isBuild = true;
                Btn_Tower_Panel.SetActive(false);
            }
        }
    }
    public void AddFence()
    {
        current_number_of_Fence += 1;
    }
    public void RemoveFence()
    {
        if(GameObject.Find(select_Build).CompareTag("Fence")){
            if (current_number_of_Fence > 0)
            {
                if(GameObject.Find(select_Build).GetComponent<Fence>().inclined) build_Position[(int)GameObject.Find(select_Build).transform.position.z / 3 + 6, (int)GameObject.Find(select_Build).transform.position.x / 3 + 10] = 0;
                else{
                    if(GameObject.Find(select_Build).GetComponent<Fence>().horizontal) fence_horizontal_position[Convert.ToInt32(GameObject.Find(select_Build).transform.position.z+1.5) / 3 + 6, Convert.ToInt32(GameObject.Find(select_Build).transform.position.x) / 3 + 10] = 0;
                    else fence_vertical_position[Convert.ToInt32(GameObject.Find(select_Build).transform.position.z / 3) + 6, Convert.ToInt32(GameObject.Find(select_Build).transform.position.x+1.5) / 3 + 10] = 0;
                }
                Destroy(GameObject.Find(select_Build));
                current_number_of_Fence -= 1;
                isBuild = true;
                Btn_Fence_Panel.SetActive(false);
            }
        }
    }
    public void GenerateMap() {
        string holderName = "Generated Map";
        Transform mapHolder = new GameObject (holderName).transform;
        mapHolder.parent = transform;

         for (int x = 0; x < mapSize.x; x ++) {
            for (int y = 0; y < mapSize.y; y ++) {
                if(!((x==9 || x==10 || x==11)&&(y==5 || y==6 || y==7))) {
                    Vector3 tilePosition = new Vector3(-mapSize.x/2 +1.5f + x*3-mapSize.x, 1, -mapSize.y/2 + 1.5f + y*3-mapSize.y);
                    Transform newTile = Instantiate(tilePrefab, tilePosition, Quaternion.Euler(Vector3.right*90)) as Transform;
                    newTile.localScale = Vector3.one *(1-outlinePercent)*3;
                    newTile.parent = mapHolder;
                }
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
