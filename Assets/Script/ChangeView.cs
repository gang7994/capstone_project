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

    public GameObject joyStick;

    public GameObject attackBtn;

    
    /*

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Topview();
        }
        
        viewBtn.onClick.AddListener(Topview);

    }
    */
    public void Topview()
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
    public void go_Topview()
    {
        isTopview = true;
        go_TopCamera.SetActive(true);
        joyStick.SetActive(false);
        attackBtn.SetActive(false);
    }
    public void go_Isometricview()
    {
        isTopview = false;
        go_TopCamera.SetActive(false);
        joyStick.SetActive(true);
        attackBtn.SetActive(true);
    }

}
