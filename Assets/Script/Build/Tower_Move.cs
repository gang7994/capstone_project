using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tower_Move : MonoBehaviour
{
    public Material[] can_build = new Material[3];
    public Material[] cannot_build = new Material[3];
    public GameObject BuildMod_UI;

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
        if(gameObject.transform.position.z <18){
            transform.Translate(new Vector3(0f, 0f, 3f), Space.World);
        }
        IsBuild_Tower();
    }
    public void Down()
    {
        if(gameObject.transform.position.z > -18){
            transform.Translate(new Vector3(0f, 0f, -3f), Space.World);
        }
        IsBuild_Tower();
    }
    public void Left()
    {
        if(gameObject.transform.position.x > -30){
            transform.Translate(new Vector3(-3f, 0f, 0f), Space.World);
        }
        IsBuild_Tower();
    }
    public void Right()
    {
        if(gameObject.transform.position.x < 30){
            transform.Translate(new Vector3(3f, 0f, 0f), Space.World);
        }
        IsBuild_Tower();
    }

       
    public void IsBuild_Tower()
    {
        if(gameObject.activeSelf == true){
            if(BuildMod_UI.activeSelf==true){
                if (GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().build_Position[Convert.ToInt32(transform.position.z / 3) + 6, Convert.ToInt32(transform.position.x / 3 + 10)] == 1){
                    GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().isBuild = false;
                    Renderer rd = this.GetComponent<MeshRenderer>();
                    rd.materials = cannot_build;
                }
                else{
                    GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().isBuild = true;
                    Renderer rd = this.GetComponent<MeshRenderer>();
                    rd.materials = can_build;
                }
            }   
        }   
    }
}

