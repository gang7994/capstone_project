using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build_UI : MonoBehaviour
{
    public GameObject tower_prefab;
    public GameObject fence_prefab;
    public GameObject tower_up;
    public GameObject tower_down;
    public GameObject tower_left;
    public GameObject tower_right;
    public GameObject fence_up;
    public GameObject fence_down;
    public GameObject fence_left;
    public GameObject fence_right;
    public Material[] tower_base = new Material[3];


    
    // Start is called before the first frame update
    public void onClick1()
    {
        tower_prefab.SetActive(true);
        fence_prefab.SetActive(false);
        tower_up.SetActive(true);
        tower_down.SetActive(true);
        tower_left.SetActive(true);
        tower_right.SetActive(true);
        fence_up.SetActive(false);
        fence_down.SetActive(false);
        fence_left.SetActive(false);
        fence_right.SetActive(false);
    }

    public void onClick2()
    {
        tower_prefab.SetActive(false);
        fence_prefab.SetActive(true);
        fence_up.SetActive(true);
        fence_down.SetActive(true);
        fence_left.SetActive(true);
        fence_right.SetActive(true);
        tower_up.SetActive(false);
        tower_down.SetActive(false);
        tower_left.SetActive(false);
        tower_right.SetActive(false);
    }

    public void onClick3()
    {
        fence_prefab.SetActive(false);
        tower_prefab.SetActive(false);
        tower_up.SetActive(false);
        tower_down.SetActive(false);
        tower_left.SetActive(false);
        tower_right.SetActive(false);
        fence_up.SetActive(false);
        fence_down.SetActive(false);
        fence_left.SetActive(false);
        fence_right.SetActive(false);
    }

    public void onClick4()
    {
        fence_prefab.transform.Rotate(new Vector3(0,45f,0));
    }

    public void SetUp()
    {
        if (tower_prefab.activeSelf == true)
        {
            if (GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().isBuild_tower)
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
            if (GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().isBuild_fence)
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
        tower_up.SetActive(false);
        tower_down.SetActive(false);
        tower_left.SetActive(false);
        tower_right.SetActive(false);
        fence_up.SetActive(false);
        fence_down.SetActive(false);
        fence_left.SetActive(false);
        fence_right.SetActive(false);
    }
    

    
    
}
