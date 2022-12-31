using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject tower;
    public GameObject fence;
    public GameObject tower_up;
    public GameObject tower_down;
    public GameObject tower_left;
    public GameObject tower_right;
    public GameObject fence_up;
    public GameObject fence_down;
    public GameObject fence_left;
    public GameObject fence_right;




    public void onClick1(){
        tower.SetActive(true);
        fence.SetActive(false);
        tower_up.SetActive(true);
        tower_down.SetActive(true);
        tower_left.SetActive(true);
        tower_right.SetActive(true);
        fence_up.SetActive(false);
        fence_down.SetActive(false);
        fence_left.SetActive(false);
        fence_right.SetActive(false);
    }

    public void onClick2(){
        tower.SetActive(false);
        fence.SetActive(true);
        fence_up.SetActive(true);
        fence_down.SetActive(true);
        fence_left.SetActive(true);
        fence_right.SetActive(true);
        tower_up.SetActive(false);
        tower_down.SetActive(false);
        tower_left.SetActive(false);
        tower_right.SetActive(false);
    }

    public void onClick3(){
        fence.SetActive(false);
        tower.SetActive(false);
        tower_up.SetActive(false);
        tower_down.SetActive(false);
        tower_left.SetActive(false);
        tower_right.SetActive(false);
        fence_up.SetActive(false);
        fence_down.SetActive(false);
        fence_left.SetActive(false);
        fence_right.SetActive(false);
    }
}
