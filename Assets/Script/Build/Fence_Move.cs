using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Fence_Move : MonoBehaviour
{
    public Material[] can_build = new Material[3];
    public Material[] cannot_build = new Material[3];
    Vector3 destination = new Vector3(3, 4, 5);

    public GameObject BuildMod_UI;
    // Start is called before the first frame update
    
    // Update is called once per frame
    
    public void init_position()
    {
        transform.position = new Vector3(0, 0, 1.5f);
        transform.localEulerAngles = new Vector3(0,0,0);
        IsBuild_Fence();
    }
    public void Up()
    {
        if(gameObject.transform.position.z <18){
            transform.Translate(new Vector3(0f, 0f, 3f), Space.World);
        }
        IsBuild_Fence();
    }
    public void Down()
    {
        if(gameObject.transform.position.z > -18){
            transform.Translate(new Vector3(0f, 0f, -3f), Space.World);
        }
        IsBuild_Fence();
    }
    public void Left()
    {
        if(gameObject.transform.position.x > -30){
            transform.Translate(new Vector3(-3f, 0f, 0f), Space.World);
        }
        IsBuild_Fence();
    }
    public void Right()
    {
        if(gameObject.transform.position.x < 30){
            transform.Translate(new Vector3(3f, 0f, 0f), Space.World);
        }
        IsBuild_Fence();
    }

    public void IsBuild_Fence()
    {
        if(gameObject.activeSelf == true){
            if (BuildMod_UI.activeSelf == true){
                if(GameObject.Find("Building_Inspector").GetComponent<Build_UI>().inclined){
                    if (GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().build_Position[Convert.ToInt32(transform.position.z / 3) + 6, Convert.ToInt32(transform.position.x) / 3 + 10] == 1){
                        GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().isBuild = false;
                        Renderer rd = this.GetComponent<MeshRenderer>();
                        rd.material = cannot_build[0];
                    
                }
                    else{
                        GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().isBuild = true;
                        Renderer rd = this.GetComponent<MeshRenderer>();
                        rd.material = can_build[0];
                    }
                }
                else{
                    if(GameObject.Find("Building_Inspector").GetComponent<Build_UI>().horizontal){
                        if (GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().fence_horizontal_position[Convert.ToInt32(transform.position.z+1.5) / 3 + 6, Convert.ToInt32(transform.position.x) / 3 + 10] == 1){
                            GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().isBuild = false;
                            Renderer rd = this.GetComponent<MeshRenderer>();
                            rd.material = cannot_build[0];
                        }
                        else{
                            GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().isBuild = true;
                            Renderer rd = this.GetComponent<MeshRenderer>();
                            rd.material = can_build[0];
                        }
                    }
                    else{
                        if (GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().fence_vertical_position[Convert.ToInt32(transform.position.z) / 3 + 6, Convert.ToInt32(transform.position.x+1.5) / 3 + 10] == 1){
                            GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().isBuild = false;
                            Renderer rd = this.GetComponent<MeshRenderer>();
                            rd.material = cannot_build[0];
                        }
                        else{
                            GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().isBuild = true;
                            Renderer rd = this.GetComponent<MeshRenderer>();
                            rd.material = can_build[0];
                        }
                    }
                }
            }
        }
    }
}
