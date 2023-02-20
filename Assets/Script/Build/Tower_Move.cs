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
        transform.position = new Vector3(0, 3.5f, 0);
    }
    public void Up()
    {
        transform.Translate(new Vector3(0f, 0f, 1f));
    }
    public void Down()
    {
        transform.Translate(new Vector3(0f, 0f, -1f));
    }
    public void Left()
    {
        transform.Translate(new Vector3(-1f, 0f, 0f));
    }
    public void Right()
    {
        transform.Translate(new Vector3(1f, 0f, 0f));
    }

    private void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("Tower")){
            GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().isBuild_tower = false;  
            Debug.Log("설치불가"); 
        }
    }

    private void OnTriggerExit(Collider other){
        if (other.gameObject.CompareTag("Tower")){
            GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().isBuild_tower = true;
            Debug.Log("설치가능");  
        }
    }
}

