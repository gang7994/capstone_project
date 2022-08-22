using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildCamera : MonoBehaviour
{
    public bool isTopview = false;

    [SerializeField]
    private GameObject go_TopCamera;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Topview();
        }
    }

    private void Topview()
    {
        if(!isTopview)
        {
            go_Topview();
        }
        else
        {
            go_Isometricview();
        }
    }
    private void go_Topview()
    {
        isTopview = true;
        go_TopCamera.SetActive(true);
    }
    private void go_Isometricview()
    {
        isTopview = false;
        go_TopCamera.SetActive(false);
    }
}
