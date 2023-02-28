using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnCtrl : MonoBehaviour
{
    float timer, coolTime;
    public bool is_up_down;
    public bool is_down_down;
    public bool is_left_down;
    public bool is_right_down;
    void Start(){
        timer = 0.0f;
        coolTime = 0.3f;
    }
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > coolTime){
            if(is_down_down){
                transform.Translate(new Vector3(0f, 0f, -3f), Space.World);
            }

            if(is_left_down){
                transform.Translate(new Vector3(-3f, 0f, 0f), Space.World);

            }
            if(is_right_down){
                transform.Translate(new Vector3(3f, 0f, 0f), Space.World);
            }

            if(is_up_down){
                transform.Translate(new Vector3(0f, 0f, 3f), Space.World);
            }
            timer = 0;
        }
    }

    public void UpDown()
    {
        is_up_down = true;
    }

    public void UpUp()
    {
        is_up_down = false;
    }
    public void DownDown()
    {
        is_down_down = true;
    }

    public void DownUp()
    {
        is_down_down = false;
    }public void LeftDown()
    {
        is_left_down = true;
    }

    public void LeftUp()
    {
        is_left_down = false;
    }
    
    public void RightDown()
    {
        is_right_down = true;
    }

    public void RightUp()
    {
        is_right_down = false;
    }
}
