using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build_UI : MonoBehaviour
{
    public GameObject tower_prefab;
    public GameObject fence_prefab;
    public GameObject move_button;
    public GameObject build_button;
    public GameObject rotate_button;


    public Material[] tower_base = new Material[3];
    public Material fence_base;

    public bool inclined = false;
    public bool horizontal = true;
    public int rotate_count = 0;

    public void start()
    {
        build_button.SetActive(false);

    }

    // Start is called before the first frame update
    public void onClick1() //Ÿ�� ������ Ȱ��ȭ
    {
        tower_prefab.SetActive(true);
        fence_prefab.SetActive(false);
        move_button.SetActive(true);
        build_button.SetActive(true);
        inclined = false;
        rotate_count = 0;
        horizontal = true;
    }

    public void onClick2() //�潺 ������ Ȱ��ȭ
    {
        tower_prefab.SetActive(false);
        fence_prefab.SetActive(true);
        move_button.SetActive(true);
        build_button.SetActive(true);
        rotate_button.SetActive(true);
        GameObject.Find("Rotate").GetComponent<Build_UI>().rotate_count = 0;
        GameObject.Find("Rotate").GetComponent<Build_UI>().inclined = false;
        GameObject.Find("Rotate").GetComponent<Build_UI>().horizontal = true;
    }

    public void onClick3() //Exit ��ư Ŭ���� ����
    {
        fence_prefab.SetActive(false);
        tower_prefab.SetActive(false);

    }

    public void onClick4() //�潺 ȸ����ư
    {
        if(Mathf.Abs(fence_prefab.transform.position.x)<30 && Mathf.Abs(fence_prefab.transform.position.z)<18){
            if(inclined){
                fence_prefab.transform.Rotate(new Vector3(0,-45f,0));
                fence_prefab.transform.Translate(new Vector3(0,0,1.5f));
            }
            else{
                fence_prefab.transform.Translate(new Vector3(0,0,1.5f));
                fence_prefab.transform.Rotate(new Vector3(0,-45f,0));
            }
            inclined = !inclined;
            rotate_count += 1;
            if(rotate_count%2 == 0) horizontal = !horizontal;
            if(rotate_count == 4) rotate_count = 0;
        }
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
                if(inclined){
                    GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().AddFence();
                    fence_prefab.GetComponent<MeshRenderer>().material = fence_base;
                    GameObject fence = Instantiate(fence_prefab);
                    fence.transform.position += new Vector3(0, 0, 0);
                    fence.name = $"fence{GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().build_num}";
                    fence.tag = "Fence";
                    GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().build_num += 1;
                    GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().build_Position[(int)fence.transform.position.z / 3 + 6, (int)fence.transform.position.x / 3 + 10] = 1;
                }
                else {
                    if(horizontal){
                        GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().AddFence();
                        fence_prefab.GetComponent<MeshRenderer>().material = fence_base;
                        GameObject fence = Instantiate(fence_prefab);
                        fence.transform.position += new Vector3(0, 0, 0);
                        fence.name = $"fence{GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().build_num}";
                        fence.tag = "Fence";
                        GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().build_num += 1;
                        GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().fence_horizontal_position[((int)fence.transform.position.z+3/2) / 3 + 6, (int)fence.transform.position.x / 3 + 10] = 1;
                    }
                    else{
                        GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().AddFence();
                        fence_prefab.GetComponent<MeshRenderer>().material = fence_base;
                        GameObject fence = Instantiate(fence_prefab);
                        fence.transform.position += new Vector3(0, 0, 0);
                        fence.name = $"fence{GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().build_num}";
                        fence.tag = "Fence";
                        GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().build_num += 1;
                        GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().fence_vertical_position[(int)fence.transform.position.z / 3 + 6, ((int)fence.transform.position.x+3/2) / 3 + 10] = 1;
                    }
                }
            }
            
        }

        fence_prefab.SetActive(false);
        tower_prefab.SetActive(false);
        move_button.SetActive(false);
        build_button.SetActive(false);
    }
    

    
    
}
