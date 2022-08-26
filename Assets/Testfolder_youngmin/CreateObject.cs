using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObject : MonoBehaviour
{
    Vector3 mousePos;
    Vector3 pos;
    bool check = true;
    public GameObject cub;
    float h = Screen.height;
    float w = Screen.width;
    public GameObject go_TopCamera;
    public float h_size;
    public float w_size;
    public GameObject skycube;
    Vector3[,] arr = new Vector3[10, 10];
    GameObject[,] arrO = new GameObject[10, 10];
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int z = 0; z < 10; z++)
            {
                arr[i, z] = new Vector3(-45 + i * 10, 7, 45 - z * 10);
                GameObject temp = Instantiate(skycube, arr[i, z], Quaternion.identity);
                arrO[i, z] = temp;
                temp.SetActive(false);
            }
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
        mousePos = Input.mousePosition;
        pos = new Vector3(2 * w_size * ((mousePos.x - w / 2) / w), 2, 2 * h_size * ((mousePos.y - h / 2) / h));
        if (pos.x <= 50 && pos.x >= -50 && pos.z <= 50 && pos.z >= -50)
        {
            if (go_TopCamera.activeSelf)
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int z = 0; z < 10; z++)
                    {
                        arrO[i, z].SetActive(false);
                    }
                }
                locationCheck(pos).SetActive(true);
                if (Input.GetMouseButton(0) && check)
                {
                    check = false;
                    Instantiate(cub, locationReturn(pos), Quaternion.identity);
                    Invoke("Cheking", 1.0f);
                }
            }
        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                for (int z = 0; z < 10; z++)
                {
                    arrO[i, z].SetActive(false);
                }
            }
        }


    }
    void Cheking()
    {
        check = true;
    }

    GameObject locationCheck(Vector3 locationObjeck)
    {

        int locx = ((int)locationObjeck.x + 50)/10;
        int locz = -((int)locationObjeck.z -50)/10;
        return arrO[locx,locz];
    }
    Vector3 locationReturn(Vector3 locationObjeck)
    {

        int locx = ((int)locationObjeck.x + 50) / 10;
        int locz = -((int)locationObjeck.z - 50) / 10;
        return arr[locx, locz];
    }
}
