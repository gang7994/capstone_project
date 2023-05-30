using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;
using System.IO;

public class Tech_Manager : MonoBehaviour
{
    public List<string> properties = new List<string>{"F","L","I","E"};
    public GameObject Tech_Panel;
    public GameObject TechManager_Panel;
    public GameObject BackGround;
    public Button content0, content1, content2;

    private Text name0, name1, name2; //��ũ �г� ������ �̸�
    private Text text0, text1, text2; //��ũ �г� ������ ����
    private Text current0, current1, current2;
    private Text max0, max1, max2;
    private Image image0, image1, image2; //특성 이미지
    private Image icon0, icon1, icon2; //타입 아이콘

    int rand_left, rand_mid, rand_right; //랜덤변수
    string left, mid, right; //Ÿ��, ����, ����

    List<List<string>> tech_list = new List<List<string>>();


    public List<List<string>> select_tech_list = new List<List<string>>();
    bool unlock_tech_2 = false, unlock_tech_3 = false;
    int tech_tier1 = 0, tech_tier2 = 0;


    public Image panel_Image0, panel_Image1, panel_Image2;

    void Start()
    {
        TextAsset tier1Tech = Resources.Load<TextAsset>("Tier1");
        string[] lines_tier1 = tier1Tech.text.Split('\n');

        foreach (string line_tier1 in lines_tier1)
        {
            string[] words = line_tier1.Split('|');
            tech_list.Add(new List<string> { words[0], words[1], words[2], words[3], words[4], words[5], words[6], words[7] }); //티어, 종류, 특성, 인덱스, 이름, 내용, 초기값, 최대값
        }


        content0.onClick.AddListener(() => display("left"));
        content1.onClick.AddListener(() => display("mid"));
        content2.onClick.AddListener(() => display("right"));
    }
    void Update()
    {
        if (tech_tier1 >= 10 && !unlock_tech_2) //1티어 10개 선택하면 2단계 특성해금
        { 
            Unlock_Tech_2();
            unlock_tech_2 = true;
        }
        if (tech_tier2 >= 3 && !unlock_tech_3) //2티어 3개 선택하면 3단계 특성해금
        { 
            Unlock_Tech_3();
            unlock_tech_3 = true;
        }
        
    }

    public void Tech_Button_Click()
    {
        Tech_Panel.SetActive(true);
        BackGround.SetActive(true);

        image0 = GameObject.Find("Image0").GetComponent<Image>();
        icon0 = GameObject.Find("Icon0").GetComponent<Image>();
        name0 = GameObject.Find("Name0").GetComponent<Text>();
        text0 = GameObject.Find("Text0").GetComponent<Text>();
        current0 = GameObject.Find("Current0").GetComponent<Text>();
        max0 = GameObject.Find("Max0").GetComponent<Text>();

        image1 = GameObject.Find("Image1").GetComponent<Image>();
        icon1 = GameObject.Find("Icon1").GetComponent<Image>();
        name1 = GameObject.Find("Name1").GetComponent<Text>();
        text1 = GameObject.Find("Text1").GetComponent<Text>();
        current1 = GameObject.Find("Current1").GetComponent<Text>();
        max1 = GameObject.Find("Max1").GetComponent<Text>();


        image2 = GameObject.Find("Image2").GetComponent<Image>();
        icon2 = GameObject.Find("Icon2").GetComponent<Image>();
        name2 = GameObject.Find("Name2").GetComponent<Text>();
        text2 = GameObject.Find("Text2").GetComponent<Text>();
        current2 = GameObject.Find("Current2").GetComponent<Text>();
        max2 = GameObject.Find("Max2").GetComponent<Text>();

        Tech_Display_Panel();
    }
    public void Tech_Exit_Button_Click()
    {
        Tech_Panel.SetActive(false);
        BackGround.SetActive(false);
    }

    public void TechManager_Button_Click()
    {
        TechManager_Panel.SetActive(true);
    }
    public void TechManager_Exit_Button_Click()
    {
        TechManager_Panel.SetActive(false);
    }


    public void Unlock_Tech_2() //2티어 해금 함수
    {
        TextAsset tier2Tech = Resources.Load<TextAsset>("Tier2");
        string[] lines_tier2 = tier2Tech.text.Split('\n');

        foreach (string line_tier2 in lines_tier2)
        {
            string[] words = line_tier2.Split('|');
            tech_list.Add(new List<string> { words[0], words[1], words[2], words[3], words[4], words[5], words[6], words[7] }); //티어, 종류, 특성, 인덱스, 이름, 내용, 초기값, 최대값
        }
    }
    public void Unlock_Tech_3() //3티어 해금 함수
    {
        TextAsset tier3Tech = Resources.Load<TextAsset>("Tier3");
        string[] lines_tier3 = tier3Tech.text.Split('\n');

        foreach (string line_tier3 in lines_tier3)
        {
            string[] words = line_tier3.Split('|');
            tech_list.Add(new List<string> { words[0], words[1], words[2], words[3], words[4], words[5], words[6], words[7] }); //티어, 종류, 특성, 인덱스, 이름, 내용, 초기값, 최대값
        }
    }



    public void Tech_Display_Panel()
    {
        rand_left = Random.Range(0, tech_list.Count);
        rand_mid = Random.Range(0, tech_list.Count);
        rand_right = Random.Range(0, tech_list.Count);

        left = tech_list[rand_left][4]; 
        mid = tech_list[rand_mid][4];
        right = tech_list[rand_right][4];

        //Left
        if (tech_list[rand_left][0] == "1") panel_Image0.color = new Color(0.2f, 0.3f, 0.6f, 1.0f);
        else if (tech_list[rand_left][0] == "2") panel_Image0.color = new Color(0.3f, 0.65f, 0.4f, 1.0f);
        else panel_Image0.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

        image0.sprite = Resources.Load<Sprite>(tech_list[rand_left][4]);
        icon0.sprite = Resources.Load<Sprite>($"Icon/{tech_list[rand_left][1]}");
        name0.text = tech_list[rand_left][4];
        text0.text = tech_list[rand_left][5];
        current0.text = tech_list[rand_left][6];
        max0.text = tech_list[rand_left][7];

        //Mid
        if (tech_list[rand_mid][0] == "1") panel_Image1.color = new Color(0.2f, 0.3f, 0.6f, 1.0f);
        else if (tech_list[rand_mid][0] == "2") panel_Image1.color = new Color(0.3f, 0.65f, 0.4f, 1.0f);
        else panel_Image1.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

        image1.sprite = Resources.Load<Sprite>(tech_list[rand_mid][4]);
        icon1.sprite = Resources.Load<Sprite>($"Icon/{tech_list[rand_mid][1]}");
        name1.text = tech_list[rand_mid][4];
        text1.text = tech_list[rand_mid][5];
        current1.text = tech_list[rand_mid][6];
        max1.text = tech_list[rand_mid][7];

        //Right
        if (tech_list[rand_right][0] == "1") panel_Image2.color = new Color(0.2f, 0.3f, 0.6f, 1.0f);
        else if (tech_list[rand_right][0] == "2") panel_Image2.color = new Color(0.3f, 0.65f, 0.4f, 1.0f);
        else panel_Image2.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

        image2.sprite = Resources.Load<Sprite>(tech_list[rand_right][4]);
        icon2.sprite = Resources.Load<Sprite>($"Icon/{tech_list[rand_right][1]}");
        name2.text = tech_list[rand_right][4];
        text2.text = tech_list[rand_right][5];
        current2.text = tech_list[rand_right][6];
        max2.text = tech_list[rand_right][7];


    }
    void Select_Tech(string tier, string type, string property, string index, string name, string text, string init_val, string max_val) //티어, 종류, 특성, 인덱스, 이름, 내용, 초기값, 최대값
    {
        if (type == "T") //타워
        {
            if(tier=="1") tech_tier1+=1;
            else if(tier=="2") tech_tier2+=1;
            select_tech_list.Add(new List<string> { tier, type, property, index, name, text, init_val, max_val });
            
            
        }
        else if (type == "W") //무기
        {
            if(tier=="1") tech_tier1+=1;
            else if(tier=="2") tech_tier2+=1;
            select_tech_list.Add(new List<string> { tier, type, property, index, name, text, init_val, max_val });
            
            
        }
        else //공용
        {
            if(tier=="1") tech_tier1+=1;
            else if(tier=="2") tech_tier2+=1;
            select_tech_list.Add(new List<string> { tier, type, property, index, name, text, init_val, max_val });

        }
        SendSelectedAttributeToElemental(tier, type, property, index);
    }

    void display(string i)
    {
        if (i == "left")
        {
            Select_Tech(tech_list[rand_left][0], tech_list[rand_left][1], tech_list[rand_left][2],tech_list[rand_left][3],tech_list[rand_left][4],tech_list[rand_left][5], tech_list[rand_left][6], tech_list[rand_left][7]);
            //티어, 종류, 특성, 인덱스, 이름, 내용, 초기값, 최대값
            if(tech_list[rand_left][0] == "1") {
                if (tech_list[rand_left][6] == "1")
                {
                    tech_list[rand_left][6] = "2";
                }
                else if (tech_list[rand_left][6] == "2")
                {
                    tech_list[rand_left][6] = "3";
                }
                else if (tech_list[rand_left][6] == "3")
                {
                    tech_list.Remove(tech_list[rand_left]);
                }
            }
            else if(tech_list[rand_left][0] == "2") {
                if (tech_list[rand_left][6] == "1")
                {
                    tech_list[rand_left][6] = "2";
                }
                else if (tech_list[rand_left][6] == "2")
                {
                    tech_list.Remove(tech_list[rand_left]);
                }
            }
            else {
                if (tech_list[rand_left][6] == "1")
                {
                    tech_list.Remove(tech_list[rand_left]);
                }
            }
        }
        else if (i == "mid")
        {
            Select_Tech(tech_list[rand_mid][0], tech_list[rand_mid][1], tech_list[rand_mid][2],tech_list[rand_mid][3],tech_list[rand_mid][4],tech_list[rand_mid][5], tech_list[rand_mid][6], tech_list[rand_mid][7]);
            //티어, 종류, 특성, 인덱스, 이름, 내용, 초기값, 최대값
            if(tech_list[rand_mid][0] == "1") {
                if (tech_list[rand_mid][6] == "1")
                {
                    tech_list[rand_mid][6] = "2";
                }
                else if (tech_list[rand_mid][6] == "2")
                {
                    tech_list[rand_mid][6] = "3";
                }
                else if (tech_list[rand_mid][6] == "3")
                {
                    tech_list.Remove(tech_list[rand_mid]);
                }
            }
            else if(tech_list[rand_mid][0] == "2") {
                if (tech_list[rand_mid][6] == "1")
                {
                    tech_list[rand_mid][6] = "2";
                }
                else if (tech_list[rand_mid][6] == "2")
                {
                    tech_list.Remove(tech_list[rand_mid]);
                }
            }
            else {
                if (tech_list[rand_mid][6] == "1")
                {
                    tech_list.Remove(tech_list[rand_mid]);
                }
            }
        }
        else
        {
            Select_Tech(tech_list[rand_right][0], tech_list[rand_right][1], tech_list[rand_right][2],tech_list[rand_right][3],tech_list[rand_right][4],tech_list[rand_right][5], tech_list[rand_right][6], tech_list[rand_right][7]);
            //티어, 종류, 특성, 인덱스, 이름, 내용, 초기값, 최대값
            if(tech_list[rand_right][0] == "1") {
                if (tech_list[rand_right][6] == "1")
                {
                    tech_list[rand_right][6] = "2";
                }
                else if (tech_list[rand_right][6] == "2")
                {
                    tech_list[rand_right][6] = "3";
                }
                else if (tech_list[rand_right][6] == "3")
                {
                    tech_list.Remove(tech_list[rand_right]);
                }
            }
            else if(tech_list[rand_right][0] == "2") {
                if (tech_list[rand_right][6] == "1")
                {
                    tech_list[rand_right][6] = "2";
                }
                else if (tech_list[rand_right][6] == "2")
                {
                    tech_list.Remove(tech_list[rand_right]);
                }
            }
            else {
                if (tech_list[rand_right][6] == "1")
                {
                    tech_list.Remove(tech_list[rand_right]);
                }
            }
        }
        Tech_Exit_Button_Click();
    }
    
    public void SendSelectedAttributeToElemental(string tier, string type, string property, string index) //티어, 종류, 속성, 인덱스
    {
        Elemental.property_memory.Add(tier+type+property+index);
    }
}
