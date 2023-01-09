using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building_Inspector : MonoBehaviour
{
    public Camera getCamera;
    private RaycastHit hit;

    public GameObject Building_Panel_Button;
    public GameObject Destory_Button;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            Ray ray = getCamera.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit)&& hit.collider.gameObject.tag =="Tower")
            {
                Building_Click(true);
            }
            else if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.tag == "Map")
            {
                Building_Click(false);
            }
        }
    }

    public void Building_Click(bool isClick)
    {
        if (isClick)
        {
            Building_Panel_Button.SetActive(true);
            Destory_Button.SetActive(true);
        }
        else
        {
            Building_Panel_Button.SetActive(false);
            Destory_Button.SetActive(false);
        }
    }
}
