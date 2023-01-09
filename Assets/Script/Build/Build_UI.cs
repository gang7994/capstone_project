using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build_UI : MonoBehaviour
{
    public GameObject Build_Panel;
    public GameObject Build_Panel_Exit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Building_Panel_Click()
    {
        Build_Panel.SetActive(true);
    }
    public void Building_Panel_Exit_Click()
    {
        Build_Panel.SetActive(false);
    }
}
