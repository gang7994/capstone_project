using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObject : MonoBehaviour
{
    Vector3 mousePos;
    Vector3 pos;
    bool check = true;
    bool check1 = true;
    public GameObject cub;
    float h = Screen.height;
    float w = Screen.width;
    public GameObject go_TopCamera;
    public float h_size;
    public float w_size;
    public GameObject skycube;
    public GameObject cub1;
    Vector3[,] arr = new Vector3[10, 8];
    GameObject[,] arrO = new GameObject[10, 8];
    Vector3[,] arr1 = new Vector3[11, 7];
    GameObject[,] arrO1 = new GameObject[11, 7];
    bool wid_len = true;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int z = 0; z < 8; z++)
            {
                arr[i, z] = new Vector3(-45 + i * 10, 0, 35 - z * 10);
                GameObject temp = Instantiate(skycube, arr[i, z], Quaternion.identity);
                arrO[i, z] = temp;
                temp.SetActive(false);
            }
        }
        for (int i = 0; i < 11; i++)
        {
            for (int z = 0; z < 7; z++)
            {
                arr1[i, z] = new Vector3(-50 + i * 10, 0, 30 - z * 10);
                GameObject temp = Instantiate(skycube, arr1[i, z], Quaternion.identity);
                temp.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
                arrO1[i, z] = temp;
                temp.SetActive(false);
            }
        }
        


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            
            if (go_TopCamera.activeSelf)
            {
                if (check1)
                {
                    if (wid_len)
                    {
                        wid_len = false;
                        for (int i = 0; i < 11; i++)
                        {
                            for (int z = 0; z < 7; z++)
                            {
                                arrO1[i, z].SetActive(false);
                            }
                        }
                        for (int i = 0; i < 10; i++)
                        {
                            for (int z = 0; z < 8; z++)
                            {
                                arrO[i, z].SetActive(false);
                            }
                        }
                        len();
                        check1 = false;
                        Invoke("checking1", 0.3f);
                    }
                    else
                    {
                        wid_len = true;
                        for (int i = 0; i < 11; i++)
                        {
                            for (int z = 0; z < 7; z++)
                            {
                                arrO1[i, z].SetActive(false);
                            }
                        }
                        for (int i = 0; i < 10; i++)
                        {
                            for (int z = 0; z < 8; z++)
                            {
                                arrO[i, z].SetActive(false);
                            }
                        }
                        wid();
                        check1 = false;
                        Invoke("checking1", 0.3f);
                    }
                }
            }


        }
        mousePos = Input.mousePosition;
        pos = new Vector3(2 * w_size * ((mousePos.x - w / 2) / w), 0, 2 * h_size * ((mousePos.y - h / 2) / h));
        if (wid_len)
        {
            wid();
        }
        else
        {
            len();
        }
        


    }
    void Cheking()
    {
        check = true;
    }

    GameObject locationCheck(Vector3 locationObjeck)
    {

        int locx = ((int)locationObjeck.x + 50)/10;
        int locz = -((int)locationObjeck.z -40)/10;
        return arrO[locx,locz];
    }
    Vector3 locationReturn(Vector3 locationObjeck)
    {

        int locx = ((int)locationObjeck.x + 50) / 10;
        int locz = -((int)locationObjeck.z - 40) / 10;
        return arr[locx, locz];
    }
    GameObject locationCheck1(Vector3 locationObjeck)
    {

        int locx = ((int)locationObjeck.x + 55) / 10;
        int locz = -((int)locationObjeck.z - 35) / 10;
        return arrO1[locx, locz];
    }
    Vector3 locationReturn1(Vector3 locationObjeck)
    {

        int locx = ((int)locationObjeck.x + 55) / 10;
        int locz = -((int)locationObjeck.z - 35) / 10;
        return arr1[locx, locz];
    }
    void wid()
    {
        if (pos.x <= 50 && pos.x >= -50 && pos.z <= 40 && pos.z >= -40)
        {
            if (go_TopCamera.activeSelf)
            {
                if (wid_len)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        for (int z = 0; z < 8; z++)
                        {
                            arrO[i, z].SetActive(false);
                        }
                    }
                    locationCheck(pos).SetActive(true);
                    if (Input.GetMouseButton(0) && check)
                    {
                        check = false;
                        Instantiate(cub, locationReturn(pos), Quaternion.identity);
                        Invoke("Cheking", 0.3f);
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                for (int z = 0; z < 8; z++)
                {
                    arrO[i, z].SetActive(false);
                }
            }
            for (int i = 0; i < 11; i++)
            {
                for (int z = 0; z < 7; z++)
                {
                    arrO1[i, z].SetActive(false);
                }
            }
        }
    }
    void len()
    {
        if (pos.x <= 55 && pos.x >= -55 && pos.z <= 35 && pos.z >= -35)
        {
            if (go_TopCamera.activeSelf)
            {
                if (!wid_len)
                {
                    for (int i = 0; i < 11; i++)
                    {
                        for (int z = 0; z < 7; z++)
                        {
                            arrO1[i, z].SetActive(false);
                        }
                    }
                    locationCheck1(pos).SetActive(true);
                    if (Input.GetMouseButton(0) && check)
                    {
                        check = false;
                        GameObject temp = Instantiate(cub1, locationReturn1(pos), Quaternion.identity);
                        temp.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
                        Invoke("Cheking", 0.3f);
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < 11; i++)
            {
                for (int z = 0; z < 7; z++)
                {
                    arrO1[i, z].SetActive(false);
                }
            }
            for (int i = 0; i < 10; i++)
            {
                for (int z = 0; z < 8; z++)
                {
                    arrO[i, z].SetActive(false);
                }
            }
        }
    }
    void checking1()
    {
        check1 = true;
    }
}
