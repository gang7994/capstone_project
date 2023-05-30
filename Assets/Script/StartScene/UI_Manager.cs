using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_Manager : MonoBehaviour //StartScene�� UI �Ŵ���
{
    public GameObject Ranking_Panel;
    public GameObject Option_Panel;
    
 
    void Start()
    {
        Ranking_Panel.SetActive(false);
        Option_Panel.SetActive(false);
    }

    public void Start_Button_Click(){  //게임씬으로 가는 함수
        LoadingSceneController.LoadScene("GameScene");
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
    public void Exit_Click(){
        Application.Quit();
    }
}