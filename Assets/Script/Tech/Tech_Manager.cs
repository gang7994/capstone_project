using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Tech_Manager : MonoBehaviour
{
    public GameObject Tech_Panel;
    public Button content0, content1, content2;
    private Text text0;
    private Text text1;
    private Text text2;

    string left, mid, right;

    List<string> tech_tower = new List<string>();
    List<string> tech_player = new List<string>();


    void Start()
    {
        TextAsset towerTech = Resources.Load<TextAsset>("TowerTech");
        string[] lines_tower = towerTech.text.Split('\n');
        foreach(string line_tower in lines_tower)
        {
            string[] words = line_tower.Split('\t');
            tech_tower.Add(words[1]);
        }

        content0.onClick.AddListener(() => display("left"));
        content1.onClick.AddListener(() => display("mid"));
        content2.onClick.AddListener(() => display("right"));
    }

    void Update()
    {
        
    }
    public void Tech_Button_Click()
    {
        Tech_Panel.SetActive(true);
        text0 = GameObject.Find("Text0").GetComponent<Text>();
        text1 = GameObject.Find("Text1").GetComponent<Text>();
        text2 = GameObject.Find("Text2").GetComponent<Text>();
        Tech_Display_Panel();
    }
    public void Tech_Exit_Button_Click()
    {
        Tech_Panel.SetActive(false);
    }

    public void Tech_Display_Panel()
    {
        int rand_tower = Random.Range(0, tech_tower.Count);
        int rand_tower1 = Random.Range(0, tech_tower.Count);
        int rand_tower2 = Random.Range(0, tech_tower.Count);

        left = tech_tower[rand_tower];
        mid = tech_tower[rand_tower1];
        right = tech_tower[rand_tower2];
        text0.text = left;
        text1.text = mid;
        text2.text = right;
    }
    void Select_Tech()
    {
        
    }

    void display(string i)
    {
        if (i == "left") print(left);
        else if (i == "mid") print(mid);
        else print(right);
        Tech_Exit_Button_Click();
    }
}
