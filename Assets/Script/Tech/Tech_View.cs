using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tech_View : MonoBehaviour
{
    public Button tower_button, public_button, weapon_button;
    public GameObject tower_scroll, public_scroll, weapon_scroll;
    public GameObject card_info;
    public Image tech_image;
    public Text tech_name, tech_text;
    List<List<string>> select_tech_tower, select_tech_public, select_tech_weapon;

    Button tower_name0, tower_name1, tower_name2, tower_name3, tower_name4, tower_name5, tower_name6, tower_name7, tower_name8, tower_name9, tower_name10,
        tower_name11, tower_name12, tower_name13, tower_name14, tower_name15, tower_name16, tower_name17, tower_name18, tower_name19, tower_name20, tower_name21, 
        tower_name22, tower_name23, tower_name24, tower_name25, tower_name26, tower_name27, tower_name28, tower_name29, tower_name30, tower_name31, tower_name32, 
        tower_name33, tower_name34, tower_name35;
    Text tower_text0, tower_text1, tower_text2, tower_text3, tower_text4, tower_text5, tower_text6, tower_text7, tower_text8, tower_text9, tower_text10, tower_text11,
        tower_text12, tower_text13, tower_text14, tower_text15, tower_text16, tower_text17, tower_text18, tower_text19, tower_text20, tower_text21, tower_text22, tower_text23, 
        tower_text24, tower_text25, tower_text26, tower_text27, tower_text28, tower_text29, tower_text30, tower_text31, tower_text32, tower_text33, tower_text34, tower_text35;

    public List<Button> tower_name = new List<Button>();
    public List<Text> tower_text = new List<Text>();

    Button public_name0, public_name1, public_name2, public_name3, public_name4, public_name5, public_name6, public_name7, public_name8, public_name9, public_name10,
        public_name11, public_name12, public_name13, public_name14, public_name15, public_name16, public_name17, public_name18, public_name19, public_name20, public_name21,
        public_name22, public_name23, public_name24, public_name25, public_name26, public_name27, public_name28, public_name29, public_name30, public_name31, public_name32,
        public_name33, public_name34, public_name35;
    Text public_text0, public_text1, public_text2, public_text3, public_text4, public_text5, public_text6, public_text7, public_text8, public_text9, public_text10, public_text11,
        public_text12, public_text13, public_text14, public_text15, public_text16, public_text17, public_text18, public_text19, public_text20, public_text21, public_text22, public_text23,
        public_text24, public_text25, public_text26, public_text27, public_text28, public_text29, public_text30, public_text31, public_text32, public_text33, public_text34, public_text35;

    public List<Button> public_name = new List<Button>();
    public List<Text> public_text = new List<Text>();

    Button weapon_name0, weapon_name1, weapon_name2, weapon_name3, weapon_name4, weapon_name5, weapon_name6, weapon_name7, weapon_name8, weapon_name9, weapon_name10,
        weapon_name11, weapon_name12, weapon_name13, weapon_name14, weapon_name15, weapon_name16, weapon_name17, weapon_name18, weapon_name19, weapon_name20, weapon_name21,
        weapon_name22, weapon_name23, weapon_name24, weapon_name25, weapon_name26, weapon_name27, weapon_name28, weapon_name29, weapon_name30, weapon_name31, weapon_name32,
        weapon_name33, weapon_name34, weapon_name35;
    Text weapon_text0, weapon_text1, weapon_text2, weapon_text3, weapon_text4, weapon_text5, weapon_text6, weapon_text7, weapon_text8, weapon_text9, weapon_text10, weapon_text11,
        weapon_text12, weapon_text13, weapon_text14, weapon_text15, weapon_text16, weapon_text17, weapon_text18, weapon_text19, weapon_text20, weapon_text21, weapon_text22, weapon_text23,
        weapon_text24, weapon_text25, weapon_text26, weapon_text27, weapon_text28, weapon_text29, weapon_text30, weapon_text31, weapon_text32, weapon_text33, weapon_text34, weapon_text35;

    public List<Button> weapon_name = new List<Button>();
    public List<Text> weapon_text = new List<Text>();

    // Start is called before the first frame update
    void Start()
    {
        tower_scroll.SetActive(true);
        public_scroll.SetActive(false);
        weapon_scroll.SetActive(false);

        select_tech_tower = GameObject.Find("TechUI").GetComponent<Tech_Manager>().select_tech_tower;
        select_tech_public = GameObject.Find("TechUI").GetComponent<Tech_Manager>().select_tech_public;
        select_tech_weapon = GameObject.Find("TechUI").GetComponent<Tech_Manager>().select_tech_weapon;

        tower_name.AddRange(new List<Button> {tower_name0, tower_name1, tower_name2, tower_name3, tower_name4, tower_name5, tower_name6, tower_name7, tower_name8, tower_name9, tower_name10,
                            tower_name11, tower_name12, tower_name13, tower_name14, tower_name15, tower_name16, tower_name17, tower_name18, tower_name19, tower_name20, tower_name21,tower_name22, tower_name23, 
                            tower_name24, tower_name25, tower_name26, tower_name27, tower_name28, tower_name29, tower_name30, tower_name31, tower_name32, tower_name33, tower_name34, tower_name35});
        tower_text.AddRange(new List<Text> {tower_text0, tower_text1, tower_text2, tower_text3, tower_text4, tower_text5, tower_text6, tower_text7, tower_text8, tower_text9, tower_text10, tower_text11,
                            tower_text12, tower_text13, tower_text14, tower_text15, tower_text16, tower_text17, tower_text18, tower_text19, tower_text20, tower_text21, tower_text22, tower_text23, tower_text24, 
                            tower_text25, tower_text26, tower_text27, tower_text28, tower_text29, tower_text30, tower_text31, tower_text32, tower_text33, tower_text34, tower_text35});

        public_name.AddRange(new List<Button> {public_name0, public_name1, public_name2, public_name3, public_name4, public_name5, public_name6, public_name7, public_name8, public_name9, public_name10,
                            public_name11, public_name12, public_name13, public_name14, public_name15, public_name16, public_name17, public_name18, public_name19, public_name20, public_name21,
                            public_name22, public_name23, public_name24, public_name25, public_name26, public_name27, public_name28, public_name29, public_name30, public_name31, public_name32,
                            public_name33, public_name34, public_name35});
        public_text.AddRange(new List<Text> {public_text0, public_text1, public_text2, public_text3, public_text4, public_text5, public_text6, public_text7, public_text8, public_text9, public_text10, public_text11,
                            public_text12, public_text13, public_text14, public_text15, public_text16, public_text17, public_text18, public_text19, public_text20, public_text21, public_text22, public_text23,
                            public_text24, public_text25, public_text26, public_text27, public_text28, public_text29, public_text30, public_text31, public_text32, public_text33, public_text34, public_text35});

        public_name.AddRange(new List<Button> { weapon_name0, weapon_name1, weapon_name2, weapon_name3, weapon_name4, weapon_name5, weapon_name6, weapon_name7, weapon_name8, weapon_name9, weapon_name10,
                            weapon_name11, weapon_name12, weapon_name13, weapon_name14, weapon_name15, weapon_name16, weapon_name17, weapon_name18, weapon_name19, weapon_name20, weapon_name21,
                            weapon_name22, weapon_name23, weapon_name24, weapon_name25, weapon_name26, weapon_name27, weapon_name28, weapon_name29, weapon_name30, weapon_name31, weapon_name32,
                            weapon_name33, weapon_name34, weapon_name35});
        public_text.AddRange(new List<Text> {weapon_text0, weapon_text1, weapon_text2, weapon_text3, weapon_text4, weapon_text5, weapon_text6, weapon_text7, weapon_text8, weapon_text9, weapon_text10, weapon_text11,
                            weapon_text12, weapon_text13, weapon_text14, weapon_text15, weapon_text16, weapon_text17, weapon_text18, weapon_text19, weapon_text20, weapon_text21, weapon_text22, weapon_text23,
                            weapon_text24, weapon_text25, weapon_text26, weapon_text27, weapon_text28, weapon_text29, weapon_text30, weapon_text31, weapon_text32, weapon_text33, weapon_text34, weapon_text35});
    }


    void Update()
    {
        Display_Select();
    }
    public void Tower_Button_Click()
    {
        tower_scroll.SetActive(true);
        public_scroll.SetActive(false);
        weapon_scroll.SetActive(false);
        card_info.SetActive(false);
    }
    public void Public_Button_Click()
    {
        tower_scroll.SetActive(false);
        public_scroll.SetActive(true);
        weapon_scroll.SetActive(false);
        card_info.SetActive(false);
    }
    public void Weapon_Button_Click()
    {
        tower_scroll.SetActive(false);
        public_scroll.SetActive(false);
        weapon_scroll.SetActive(true);
        card_info.SetActive(false);
    }

    public void Display_Select()
    {
        int t1 = 0, t2 = 0, t3 = 0;
        int p1 = 0, p2 = 0, p3 = 0;
        int w1 = 0, w2 = 0, w3 = 0;
        for (int i = 0; i<select_tech_tower.Count; i++)
        {
            int tmp;
            if(select_tech_tower[i][0] == "1"){
                tmp = t1;
                t1 += 1;
            }
            else if (select_tech_tower[i][0] == "2"){
                tmp = t2 + 16;
                t2 += 1;
            }
            else{
                tmp = t3 + 28;
                t3 += 1;
            }
            tower_text[tmp].GetComponent<Text>().text = select_tech_tower[i][2];
        }
        for (int i = 0; i < select_tech_public.Count; i++)
        {
            int tmp;
            if (select_tech_public[i][0] == "1")
            {
                tmp = p1;
                p1 += 1;
            }
            else if (select_tech_public[i][0] == "2")
            {
                tmp = p2 + 16;
                p2 += 1;
            }
            else
            {
                tmp = p3 + 28;
                p3 += 1;
            }
            public_text[tmp].GetComponent<Text>().text = select_tech_public[i][2];
        }
        for (int i = 0; i < select_tech_weapon.Count; i++)
        {
            int tmp;
            if (select_tech_weapon[i][0] == "1")
            {
                tmp = w1;
                w1 += 1;
            }
            else if (select_tech_weapon[i][0] == "2")
            {
                tmp = w2 + 16;
                w2 += 1;
            }
            else
            {
                tmp = w3 + 28;
                w3 += 1;
            }
            weapon_text[tmp].GetComponent<Text>().text = select_tech_weapon[i][2];
        }
    }
    public void Display_Info(int i) //TechManagerUI_Panel의 Card_Info 출력 함수
    {
        if (tower_scroll.activeSelf)
        {
            if (i < select_tech_tower.Count)
            {
                card_info.SetActive(true);

                tech_image = GameObject.Find("Tech_Image").GetComponent<Image>();
                tech_name = GameObject.Find("Tech_Name").GetComponent<Text>();
                tech_text = GameObject.Find("Tech_Text").GetComponent<Text>();
                tech_image.sprite = Resources.Load<Sprite>(select_tech_tower[i][2]);
                tech_name.text = select_tech_tower[i][2];
                tech_text.text = select_tech_tower[i][3];
            }
            else
            {
                card_info.SetActive(false);
            }
        }
        else if (public_scroll.activeSelf)
        {
            if (i < select_tech_public.Count)
            {
                card_info.SetActive(true);

                tech_image = GameObject.Find("Tech_Image").GetComponent<Image>();
                tech_name = GameObject.Find("Tech_Name").GetComponent<Text>();
                tech_text = GameObject.Find("Tech_Text").GetComponent<Text>();
                tech_image.sprite = Resources.Load<Sprite>(select_tech_public[i][2]);
                tech_name.text = select_tech_public[i][2];
                tech_text.text = select_tech_public[i][3];
            }
            else
            {
                card_info.SetActive(false);
            }
        }
        else if (weapon_scroll.activeSelf)
        {
            if (i < select_tech_weapon.Count)
            {
                card_info.SetActive(true);

                tech_image = GameObject.Find("Tech_Image").GetComponent<Image>();
                tech_name = GameObject.Find("Tech_Name").GetComponent<Text>();
                tech_text = GameObject.Find("Tech_Text").GetComponent<Text>();
                tech_image.sprite = Resources.Load<Sprite>(select_tech_weapon[i][2]);
                tech_name.text = select_tech_weapon[i][2];
                tech_text.text = select_tech_weapon[i][3];
            }
            else
            {
                card_info.SetActive(false);
            }
        }
    }
}
