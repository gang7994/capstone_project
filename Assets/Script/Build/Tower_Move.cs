using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Move : MonoBehaviour
{
    CapsuleCollider build_Collider;

    void Start(){
        build_Collider = GetComponent<CapsuleCollider>();
    }

    public void init_position()
    {
        transform.position = new Vector3(0, 0.5f, 0);
        IsBuild_Tower();
    }
    public void Up()
    {
        transform.Translate(new Vector3(0f, 0f, 3f));
        IsBuild_Tower();
    }
    public void Down()
    {
        transform.Translate(new Vector3(0f, 0f, -3f));
        IsBuild_Tower();
    }
    public void Left()
    {
        transform.Translate(new Vector3(-3f, 0f, 0f));
        IsBuild_Tower();
    }
    public void Right()
    {
        transform.Translate(new Vector3(3f, 0f, 0f));
        IsBuild_Tower();
    }

       
    public void IsBuild_Tower()
    {
        if (GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().build_Position[Mathf.Abs((int)transform.position.z / 3) + 6, (int)transform.position.x / 3 + 10] == 1)
            GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().isBuild_tower = false;
        else
            GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().isBuild_tower = true;
    }
}

