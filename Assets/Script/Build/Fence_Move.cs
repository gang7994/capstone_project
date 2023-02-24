using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence_Move : MonoBehaviour
{
    Vector3 destination = new Vector3(3, 4, 5);

    public GameObject BuildMod_UI;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void init_position()
    {
        transform.position = new Vector3(0, 0, 0);
        IsBuild_Fence();
    }
    public void Up()
    {
        transform.Translate(new Vector3(0f, 0f, 3f), Space.World);
        IsBuild_Fence();
    }
    public void Down()
    {
        transform.Translate(new Vector3(0f, 0f, -3f), Space.World);
        IsBuild_Fence();
    }
    public void Left()
    {
        transform.Translate(new Vector3(-3f, 0f, 0f), Space.World);
        IsBuild_Fence();
    }
    public void Right()
    {
        transform.Translate(new Vector3(3f, 0f, 0f), Space.World);
        IsBuild_Fence();
    }

    public void IsBuild_Fence()
    {
        if (BuildMod_UI.activeSelf == true)
        {
            if (GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().build_Position[Mathf.Abs((int)transform.position.z / 3) + 6, (int)transform.position.x / 3 + 10] == 1)
                GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().isBuild_fence = false;
            else
                GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().isBuild_fence = true;
        }
    }
}
