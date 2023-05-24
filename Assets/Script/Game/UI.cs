using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public GameObject Option_Panel;
    public GameObject Gameover_Panel;
    GameManager gm;


    void Start(){
        gm = GameObject.Find("Main Camera").GetComponent<GameManager>();
    }
    
    
    public void Option_Button_Click()
    {
        Option_Panel.SetActive(true);
    }

    public void Option_Exit_Button_Click()
    {
        Option_Panel.SetActive(false);
    }

    public void Gameover_Panel_active(){
        Paused();
        Gameover_Panel.SetActive(true);
        int day = gm.GetDay();
        GameObject.Find("Record_Text").GetComponent<TextMeshProUGUI>().text = $"{day}일 생존";
        gm.GameOver();
    }

    public void Gameover_Panel_not_active(){
        Gameover_Panel.SetActive(false);
    }


    public void Paused() {
        Time.timeScale = 0f;
    }
    public void Resumed() {
        Time.timeScale = 1f;
    }
    
    public void ChangeToStartScene(){  //스타트씬으로 가는 함수
        SceneManager.LoadScene("StartScene");
    }

    public void ChangeToLoadingScene(){  //로딩씬으로 가는 함수
        SceneManager.LoadScene("GameScene");
    }

    
}
