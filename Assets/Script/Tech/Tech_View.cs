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
    List<List<string>> select_tech_list;

    public Sprite[] sprite;

    Button tower_name0, tower_name1, tower_name2, tower_name3, tower_name4, tower_name5, tower_name6, tower_name7, tower_name8, tower_name9, tower_name10,
        tower_name11, tower_name12, tower_name13, tower_name14, tower_name15;
    Text tower_text0, tower_text1, tower_text2, tower_text3, tower_text4, tower_text5, tower_text6, tower_text7, tower_text8, tower_text9, tower_text10, tower_text11,
        tower_text12, tower_text13, tower_text14, tower_text15;

    public List<Button> tower_name_1 = new List<Button>();
    public List<Text> tower_text_1 = new List<Text>();
    public List<Button> tower_name_2 = new List<Button>();
    public List<Text> tower_text_2 = new List<Text>();
    public List<Button> tower_name_3 = new List<Button>();
    public List<Text> tower_text_3 = new List<Text>();

    Button public_name0, public_name1, public_name2, public_name3, public_name4, public_name5, public_name6, public_name7, public_name8, public_name9, public_name10,
        public_name11, public_name12, public_name13, public_name14, public_name15, public_name16, public_name17, public_name18, public_name19;
    Text public_text0, public_text1, public_text2, public_text3, public_text4, public_text5, public_text6, public_text7, public_text8, public_text9, public_text10, public_text11,
        public_text12, public_text13, public_text14, public_text15, public_text16, public_text17, public_text18, public_text19;

    public List<Button> public_name_1 = new List<Button>();
    public List<Text> public_text_1 = new List<Text>();
    public List<Button> public_name_2 = new List<Button>();
    public List<Text> public_text_2 = new List<Text>();

    Button weapon_name0, weapon_name1, weapon_name2, weapon_name3, weapon_name4, weapon_name5, weapon_name6, weapon_name7, weapon_name8, weapon_name9, weapon_name10,
        weapon_name11, weapon_name12, weapon_name13;
    Text weapon_text0, weapon_text1, weapon_text2, weapon_text3, weapon_text4, weapon_text5, weapon_text6, weapon_text7, weapon_text8, weapon_text9, weapon_text10, weapon_text11,
        weapon_text12, weapon_text13;

    public List<Button> weapon_name_1 = new List<Button>();
    public List<Text> weapon_text_1 = new List<Text>();
    public List<Button> weapon_name_2 = new List<Button>();
    public List<Text> weapon_text_2 = new List<Text>();
    public List<Button> weapon_name_3 = new List<Button>();
    public List<Text> weapon_text_3 = new List<Text>();

    // Start is called before the first frame update
    void Start()
    {
        tower_scroll.SetActive(true);
        public_scroll.SetActive(false);
        weapon_scroll.SetActive(false);
        card_info.SetActive(false);

        select_tech_list = GameObject.Find("TechUI").GetComponent<Tech_Manager>().select_tech_list;

       

        foreach (Button tn1 in tower_name_1)
        {
            tn1.GetComponent<Image>().sprite = sprite[0];
        }
        foreach (Button tn2 in tower_name_2)
        {
            tn2.GetComponent<Image>().sprite = sprite[0];
        }
        foreach (Button tn3 in tower_name_3)
        {
            tn3.GetComponent<Image>().sprite = sprite[0];
        }
        foreach (Button pn1 in public_name_1)
        {
            pn1.GetComponent<Image>().sprite = sprite[0];
        }
        foreach (Button pn2 in public_name_2)
        {
            pn2.GetComponent<Image>().sprite = sprite[0];
        }
        foreach (Button wn1 in weapon_name_1)
        {
            wn1.GetComponent<Image>().sprite = sprite[0];
        }
        foreach (Button wn2 in weapon_name_2)
        {
            wn2.GetComponent<Image>().sprite = sprite[0];
        }
        foreach (Button wn3 in weapon_name_3)
        {
            wn3.GetComponent<Image>().sprite = sprite[0];
        }
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

    public void Display_Select() //TechManagerUI_Panel���� ������ Ư�� ��� �Լ�
    {
        List<string> t_list = new List<string>();
        List<string> p_list = new List<string>();
        List<string> w_list = new List<string>();
        int t1 = 0, t2 = 0, t3 = 0;
        int p1 = 0, p2 = 0, p3 = 0;
        int w1 = 0, w2 = 0, w3 = 0;
        
        for (int i = 0; i<select_tech_list.Count; i++)
        {
            if(select_tech_list[i][1] == "T"){ //종류
                if(select_tech_list[i][0] == "1") {
                    if(!t_list.Contains(select_tech_list[i][4])){
                        tower_name_1[t1].GetComponent<Image>().sprite = sprite[1];
                        tower_text_1[t1].GetComponent<Text>().text = select_tech_list[i][4];
                        t1 += 1;
                    }
                }
                else if(select_tech_list[i][0] == "2"){
                    if(!t_list.Contains(select_tech_list[i][4])){
                        tower_name_2[t2].GetComponent<Image>().sprite = sprite[1];
                        tower_text_2[t2].GetComponent<Text>().text = select_tech_list[i][4];
                        t2 += 1;
                    }
                }
                else if(select_tech_list[i][0] == "3"){
                    if(!t_list.Contains(select_tech_list[i][4])){
                        tower_name_3[t3].GetComponent<Image>().sprite = sprite[1];
                        tower_text_3[t3].GetComponent<Text>().text = select_tech_list[i][4];
                        t3 += 1;
                    }
                }
                t_list.Add(select_tech_list[i][4]);
            }
            else if (select_tech_list[i][1] == "W"){
                if(select_tech_list[i][0] == "1") {
                    if(!w_list.Contains(select_tech_list[i][4])){
                        weapon_name_1[w1].GetComponent<Image>().sprite = sprite[1];
                        weapon_text_1[w1].GetComponent<Text>().text = select_tech_list[i][4];
                        w1 += 1;
                    }
                }
                else if(select_tech_list[i][0] == "2"){
                    if(!w_list.Contains(select_tech_list[i][4])){
                        weapon_name_2[w2].GetComponent<Image>().sprite = sprite[1];
                        weapon_text_2[w2].GetComponent<Text>().text = select_tech_list[i][4];
                        w2 += 1;
                    }
                }
                else if(select_tech_list[i][0] == "3"){
                    if(!w_list.Contains(select_tech_list[i][4])){
                        weapon_name_3[w3].GetComponent<Image>().sprite = sprite[1];
                        weapon_text_3[w3].GetComponent<Text>().text = select_tech_list[i][4];
                        w3 += 1;
                    }
                }
                w_list.Add(select_tech_list[i][4]);
            }
            else if (select_tech_list[i][1] == "P"){
                if(select_tech_list[i][0] == "1") {
                    if(!p_list.Contains(select_tech_list[i][4])){
                        public_name_1[p1].GetComponent<Image>().sprite = sprite[1];
                        public_text_1[p1].GetComponent<Text>().text = select_tech_list[i][4];
                        p1 += 1;
                    }
                }
                else if(select_tech_list[i][0] == "2"){
                    if(!p_list.Contains(select_tech_list[i][4])){
                        public_name_2[p2].GetComponent<Image>().sprite = sprite[1];
                        public_text_2[p2].GetComponent<Text>().text = select_tech_list[i][4];
                        p2 += 1;
                    }
                }
                
                p_list.Add(select_tech_list[i][4]);
            }

        }
    }
    public void Display_Info(int i) //TechManagerUI_Panel�� Card_Info ��� �Լ�
    {
        if (tower_scroll.activeSelf)
        {
            try
            {
                card_info.SetActive(true);

                tech_image = GameObject.Find("Tech_Image").GetComponent<Image>();
                tech_name = GameObject.Find("Tech_Name").GetComponent<Text>();
                tech_text = GameObject.Find("Tech_Text").GetComponent<Text>();
                if (i >= 12)
                {
                    i -= 12;
                    if (tower_text_3[i].GetComponent<Text>().text != "")
                    {
                        tech_image.sprite = Resources.Load<Sprite>(tower_text_3[i].GetComponent<Text>().text);
                        tech_name.text = tower_text_3[i].GetComponent<Text>().text;
                        tech_text.text = Find_TowerTech(tower_text_3[i].GetComponent<Text>().text);
                    }
                    else card_info.SetActive(false);
                }
                else if (i >= 8 && i <= 11)
                {
                    i -= 8;
                    if (tower_text_2[i].GetComponent<Text>().text != "")
                    {
                        tech_image.sprite = Resources.Load<Sprite>(tower_text_2[i].GetComponent<Text>().text);
                        tech_name.text = tower_text_2[i].GetComponent<Text>().text;
                        tech_text.text = Find_TowerTech(tower_text_2[i].GetComponent<Text>().text);
                    }
                    else card_info.SetActive(false);
                }
                else {
                    if (tower_text_1[i].GetComponent<Text>().text != "")
                    {
                        tech_image.sprite = Resources.Load<Sprite>(tower_text_1[i].GetComponent<Text>().text);
                        tech_name.text = tower_text_1[i].GetComponent<Text>().text;
                        tech_text.text = Find_TowerTech(tower_text_1[i].GetComponent<Text>().text);
                    }
                    else card_info.SetActive(false);
                }

            }
            catch (System.ArgumentOutOfRangeException ex)
            {
                card_info.SetActive(false);
            }
        }

        else if (public_scroll.activeSelf)
        {
            try
            {
                card_info.SetActive(true);

                tech_image = GameObject.Find("Tech_Image").GetComponent<Image>();
                tech_name = GameObject.Find("Tech_Name").GetComponent<Text>();
                tech_text = GameObject.Find("Tech_Text").GetComponent<Text>();
                if (i >= 12)
                {
                    i -= 16;
                    if (public_text_2[i].GetComponent<Text>().text != "")
                    {
                        tech_image.sprite = Resources.Load<Sprite>(public_text_2[i].GetComponent<Text>().text);
                        tech_name.text = public_text_2[i].GetComponent<Text>().text;
                        tech_text.text = Find_PublicTech(public_text_2[i].GetComponent<Text>().text);
                    }
                    else card_info.SetActive(false);
                }
                else
                {
                    if (public_text_1[i].GetComponent<Text>().text != "")
                    {
                        tech_image.sprite = Resources.Load<Sprite>(public_text_1[i].GetComponent<Text>().text);
                        tech_name.text = public_text_1[i].GetComponent<Text>().text;
                        tech_text.text = Find_PublicTech(public_text_1[i].GetComponent<Text>().text);
                    }
                    else card_info.SetActive(false);
                }
            }
            catch (System.ArgumentOutOfRangeException ex)
            {
                card_info.SetActive(false);
            }
        }
        else if (weapon_scroll.activeSelf)
        {
            try
            {
                card_info.SetActive(true);

                tech_image = GameObject.Find("Tech_Image").GetComponent<Image>();
                tech_name = GameObject.Find("Tech_Name").GetComponent<Text>();
                tech_text = GameObject.Find("Tech_Text").GetComponent<Text>();
                if (i >= 12)
                {
                    i -= 12;
                    if (weapon_text_3[i].GetComponent<Text>().text != "")
                    {
                        tech_image.sprite = Resources.Load<Sprite>(weapon_text_3[i].GetComponent<Text>().text);
                        tech_name.text = weapon_text_3[i].GetComponent<Text>().text;
                        tech_text.text = Find_WeaponTech(weapon_text_3[i].GetComponent<Text>().text);
                    }
                    else card_info.SetActive(false);
                }
                else if (i >= 8 && i <= 11)
                {
                    i -= 8;
                    if (weapon_text_2[i].GetComponent<Text>().text != "")
                    {
                        tech_image.sprite = Resources.Load<Sprite>(weapon_text_2[i].GetComponent<Text>().text);
                        tech_name.text = weapon_text_2[i].GetComponent<Text>().text;
                        tech_text.text = Find_WeaponTech(weapon_text_2[i].GetComponent<Text>().text);
                    }
                    else card_info.SetActive(false);
                }
                else
                {
                    if (weapon_text_1[i].GetComponent<Text>().text != "")
                    {
                        tech_image.sprite = Resources.Load<Sprite>(weapon_text_1[i].GetComponent<Text>().text);
                        tech_name.text = weapon_text_1[i].GetComponent<Text>().text;
                        tech_text.text = Find_WeaponTech(weapon_text_1[i].GetComponent<Text>().text);
                    }
                    else card_info.SetActive(false);
                }
            }
            catch (System.ArgumentOutOfRangeException ex)
            {
                card_info.SetActive(false);
            }
        }
    }

    string Find_TowerTech(string tmp)
    {
        for(int i=0; i < select_tech_list.Count; i++)
        {
            if (select_tech_list[i][3] == tmp) return select_tech_list[i][4];
            
        }
        return null;
    }
    string Find_PublicTech(string tmp)
    {
        for (int i = 0; i < select_tech_list.Count; i++)
        {
            if (select_tech_list[i][3] == tmp) return select_tech_list[i][4];
        }
        return null;
    }
    string Find_WeaponTech(string tmp)
    {
        for (int i = 0; i < select_tech_list.Count; i++)
        {
            if (select_tech_list[i][3] == tmp) return select_tech_list[i][4];
        }
        return null;
    }
}
