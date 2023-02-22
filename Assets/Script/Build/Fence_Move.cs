using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence_Move : MonoBehaviour
{
    Vector3 destination = new Vector3(3, 4, 5);
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
    }
    public void Up()
    {
        transform.Translate(new Vector3(0f, 0f, 1f), Space.World);
    }
    public void Down()
    {
        transform.Translate(new Vector3(0f, 0f, -1f), Space.World);
    }
    public void Left()
    {
        transform.Translate(new Vector3(-1f, 0f, 0f), Space.World);
    }
    public void Right()
    {
        transform.Translate(new Vector3(1f, 0f, 0f), Space.World);
    }

    private void OnTriggerStay(Collider other){
        GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().isBuild_fence = false;  
        Debug.Log("설치불가"); 
    }

    private void OnTriggerExit(Collider other){
        GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().isBuild_fence = true;
        Debug.Log("설치가능");  
    }

}
