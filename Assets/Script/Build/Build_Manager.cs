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

    public string select_Build;
    public Vector3 select_Build_Position;

    public int build_num = 0;

    public Transform tilePrefab;
    public Vector2 mapSize;
    public int[,] build_Position = new int[13, 21];

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

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = getCamera.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.CompareTag("Tower") && !Btn_Tower_Panel.activeSelf)
            {
                select_Build = hit.collider.gameObject.name;
                select_Build_Position = hit.collider.gameObject.transform.position;
                Tower_Click(true);
            }
            else if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.CompareTag("Fence") && !Btn_Fence_Panel.activeSelf)
            {
                select_Build = hit.collider.gameObject.name;
                select_Build_Position = hit.collider.gameObject.transform.position;
                Fence_Click(true);

            }
        }

        tower_num.text = current_number_of_Tower.ToString() + "/" + max_number_of_Tower;
        fence_num.text = current_number_of_Fence.ToString() + "/" + max_number_of_Fence;


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
            if(current_number_of_Tower == max_number_of_Tower) isBuild = false;
        }
    }
    public void RemoveTower()
    {
        if (current_number_of_Tower > 0){
            Destroy(GameObject.Find(select_Build));
            current_number_of_Tower -= 1;
            isBuild = true;
            Btn_Tower_Panel.SetActive(false);
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
            Destroy(GameObject.Find(select_Build));
            current_number_of_Fence -= 1;
            isBuild = true;
            Btn_Fence_Panel.SetActive(false);
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
