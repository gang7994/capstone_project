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

    public GameObject TopScene;

    public GameObject FrontScene;

    void Start(){
        TopScene.SetActive(false);
    }
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
        TopScene.SetActive(true);
        FrontScene.SetActive(false);
    }
    public void go_Isometricview()
    {
        isTopview = false;
        go_TopCamera.SetActive(false);
        TopScene.SetActive(false);
        FrontScene.SetActive(true);
    }

}
