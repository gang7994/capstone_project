using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public GameObject Option_Panel;


    public void Option_Button_Click()
    {
        Option_Panel.SetActive(true);
    }

    public void Option_Exit_Button_Click()
    {
        Option_Panel.SetActive(false);
    }

    public void Paused() {
        Time.timeScale = 0f;
    }
    public void Resumed() {
        Time.timeScale = 1f;
    }
    
}
