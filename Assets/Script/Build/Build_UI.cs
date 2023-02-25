using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build_UI : MonoBehaviour
{
    public GameObject tower_prefab;
    public GameObject fence_prefab;
    public GameObject move_button;
    public GameObject build_button;

    public Material[] tower_base = new Material[3];

    public void start()
    {
        build_button.SetActive(false);
    }

    // Start is called before the first frame update
    public void onClick1() //타워 프리팹 활성화
    {
        tower_prefab.SetActive(true);
        fence_prefab.SetActive(false);
        move_button.SetActive(true);
        build_button.SetActive(true);

    }

    public void onClick2() //펜스 프리팹 활성화
    {
        tower_prefab.SetActive(false);
        fence_prefab.SetActive(true);
        move_button.SetActive(true);
        build_button.SetActive(true);
    }

    public void onClick3() //Exit 버튼 클릭시 실행
    {
        fence_prefab.SetActive(false);
        tower_prefab.SetActive(false);

    }

    public void onClick4() //펜스 회전버튼
    {
        fence_prefab.transform.Rotate(new Vector3(0,45f,0));
    }

    public void SetUp()
    {
        if (tower_prefab.activeSelf == true)
        {
            if (GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().isBuild)
            {
                GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().AddTower();
                tower_prefab.GetComponent<MeshRenderer>().materials = tower_base;
                GameObject tower = Instantiate(tower_prefab);
                tower.transform.position += new Vector3(0, 0, 0);
                tower.name = $"tower{GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().build_num}";
                tower.tag = "Tower";
                GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().build_num += 1;
                GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().build_Position[Mathf.Abs((int)tower.transform.position.z / 3) + 6,(int)tower.transform.position.x / 3 + 10] = 1;
                

            }
        }
        else if (fence_prefab.activeSelf == true)
        {
            if (GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().isBuild)
            {
                GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().AddFence();
                GameObject fence = Instantiate(fence_prefab);
                fence.transform.position += new Vector3(0, 0, 0);
                fence.name = $"fence{GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().build_num}";
                fence.tag = "Fence";
                GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().build_num += 1;
                GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().build_Position[Mathf.Abs((int)fence.transform.position.z / 3) + 6, (int)fence.transform.position.x / 3 + 10] = 1;
            }
        }

        fence_prefab.SetActive(false);
        tower_prefab.SetActive(false);
        move_button.SetActive(false);
        build_button.SetActive(false);

    }
    

    
    
}
