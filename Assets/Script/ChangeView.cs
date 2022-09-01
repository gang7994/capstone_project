using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeView : MonoBehaviour
{
    public bool isTopview = false;

    public Button viewBtn;

    [SerializeField]
    private GameObject go_TopCamera;

    void Update()
    {/*
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Topview();
        }
        */
        viewBtn.onClick.AddListener(Topview);

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
