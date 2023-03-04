using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour //StartScene의 UI 매니져
{
    public GameObject Ranking_Panel;
    public GameObject Option_Panel;

    void Start()
    {
        Ranking_Panel.SetActive(false);
        Option_Panel.SetActive(false);
    }

    public void Ranking_Button_Click()
    {
        Ranking_Panel.SetActive(true);
    }
    public void Ranking_Exit_Button_Click()
    {
        Ranking_Panel.SetActive(false);
    }
    public void Option_Button_Click()
    {
        Option_Panel.SetActive(true);
    }
    public void Option_Exit_Button_Click()
    {
        Option_Panel.SetActive(false);
    }
}
