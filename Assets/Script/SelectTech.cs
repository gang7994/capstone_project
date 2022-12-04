using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectTech : MonoBehaviour
{
    public GameObject TechPanel;
    // Start is called before the first frame update
    

    public void OnClick1(){
        Debug.Log("특성1 선택됨");
        TechPanel.SetActive(false);
    }

    public void OnClick2(){
        Debug.Log("특성2 선택됨");
        TechPanel.SetActive(false);

    }

    public void OnClick3(){
        Debug.Log("특성3 선택됨");
        TechPanel.SetActive(false);
    }
}
