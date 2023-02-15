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
        tower_name11, tower_name12, tower_name13, tower_name14, tower_name15;
    Text tower_text0, tower_text1, tower_text2, tower_text3, tower_text4, tower_text5, tower_text6, tower_text7, tower_text8, tower_text9, tower_text10, tower_text11,
        tower_text12, tower_text13, tower_text14, tower_text15;

    public List<Button> tower_name = new List<Button>();
    public List<Text> tower_text = new List<Text>();

    // Start is called before the first frame update
    void Start()
    {
        tower_scroll.SetActive(true);
        public_scroll.SetActive(false);
        weapon_scroll.SetActive(false);

        select_tech_tower = GameObject.Find("TechUI").GetComponent<Tech_Manager>().select_tech_tower;
        //select_tech_public = GameObject.Find("TechUI").GetComponent<Tech_Manager>().select_tech_public;
        select_tech_weapon = GameObject.Find("TechUI").GetComponent<Tech_Manager>().select_tech_weapon;

        tower_name.AddRange(new List<Button> {tower_name0, tower_name1, tower_name2, tower_name3, tower_name4, tower_name5, tower_name6, tower_name7, tower_name8, tower_name9, tower_name10,
        tower_name11, tower_name12, tower_name13, tower_name14, tower_name15});
        tower_text.AddRange(new List<Text> {tower_text0, tower_text1, tower_text2, tower_text3, tower_text4, tower_text5, tower_text6, tower_text7, tower_text8, tower_text9, tower_text10, tower_text11,
        tower_text12, tower_text13, tower_text14, tower_text15});


        



    }

    // Update is called once per frame
    void Update()
    {
        Display_Select_Tower();
    }
    public void Tower_Button_Click()
    {
        tower_scroll.SetActive(true);
        public_scroll.SetActive(false);
        weapon_scroll.SetActive(false);
    }
    public void Public_Button_Click()
    {
        tower_scroll.SetActive(false);
        public_scroll.SetActive(true);
        weapon_scroll.SetActive(false);
    }
    public void Weapon_Button_Click()
    {
        tower_scroll.SetActive(false);
        public_scroll.SetActive(false);
        weapon_scroll.SetActive(true);
    }

    public void Display_Select_Tower()
    {
        for(int i = 0; i<select_tech_tower.Count; i++)
        {
            tower_text[i].GetComponent<Text>().text = select_tech_tower[i][2];
        }
    }
    public void Display_Info(int i) //TechManagerUI_Panel의 Card_Info 출력 함수
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
            print("none");
        }
    }
}
