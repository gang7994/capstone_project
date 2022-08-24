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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && check)
        {
            if (go_TopCamera.activeSelf)
            {
                check = false;
                mousePos = Input.mousePosition;
                pos = new Vector3(82 * ((mousePos.x - w / 2) / w), 2, 70 * ((mousePos.y - h / 2) / h));
                Instantiate(cub, pos, Quaternion.identity);
                Invoke("Cheking", 1.0f);
            }
            
        }
    }
    void Cheking()
    {
        check = true;
    }
}
