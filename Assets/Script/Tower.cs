using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject tower;
    public GameObject fence;

    

    public void onClick1(){
        tower.SetActive(true);
        fence.SetActive(false);
    }

    public void onClick2(){
        tower.SetActive(false);
        fence.SetActive(true);
    }

    public void onClick3(){
        fence.SetActive(false);
        tower.SetActive(false);
    }
}
