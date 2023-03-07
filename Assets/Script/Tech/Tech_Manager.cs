using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;
using System.IO;

public class Tech_Manager : MonoBehaviour
{
    Tower towerscript = new Tower();
    public GameObject Tech_Panel;
    public GameObject TechManager_Panel;
    public GameObject BackGround;
    public Button content0, content1, content2;

    private Text name0, name1, name2; //테크 패널 선택지 이름
    private Text text0, text1, text2; //테크 패널 선택지 내용
    private Image image0, image1, image2; //테크 패널 선택지 이미지

    int rand_tower, rand_public, rand_weapon; //테크 패널 선택지 랜덤 변수
    string left, mid, right; //타워, 공용, 무기

    List<List<string>> tech_tower = new List<List<string>>();
    List<List<string>> tech_public = new List<List<string>>();
    List<List<string>> tech_weapon = new List<List<string>>();

    public List<List<string>> select_tech_tower = new List<List<string>>();
    bool ulock_tower_tech_2 = false, unlock_tower_tech_3 = false;
    int tower_tech_tier1 = 0, tower_tech_tier2 = 0;

    public List<List<string>> select_tech_public = new List<List<string>>();
    bool ulock_public_tech_2 = false, unlock_public_tech_3 = false;
    int public_tech_tier1 = 0, public_tech_tier2 = 0;

    public List<List<string>> select_tech_weapon = new List<List<string>>();
    bool ulock_weapon_tech_2 = false, unlock_weapon_tech_3 = false;
    int weapon_tech_tier1 = 0, weapon_tech_tier2 = 0;

    public Image panel_Image0, panel_Image1, panel_Image2;

    void Start()
    {
        //테크트리.txt를 받아와 리스트에 넣어줌
        TextAsset towerTech = Resources.Load<TextAsset>("TowerTech1");
        string[] lines_tower = towerTech.text.Split('\n');
        TextAsset publicTech = Resources.Load<TextAsset>("PublicTech1");
        string[] lines_public = publicTech.text.Split('\n');
        TextAsset weaponTech = Resources.Load<TextAsset>("WeaponTech1");
        string[] lines_weapon = weaponTech.text.Split('\n');

        foreach (string line_tower in lines_tower)
        {
            string[] words = line_tower.Split('\t');
            tech_tower.Add(new List<string> { words[0], words[1], words[2], words[3], "1", words[4] }); //티어, 속성, 이름, 설명, 레벨, 인덱스
        }

        foreach (string line_public in lines_public)
        {
            string[] words = line_public.Split('\t');
            tech_public.Add(new List<string> { words[0], words[1], words[2], words[3], "1", words[4] }); //티어, 속성, 이름, 설명, 레벨, 인덱스
        }

        foreach (string line_weapon in lines_weapon)
        {
            string[] words = line_weapon.Split('\t');
            tech_weapon.Add(new List<string> { words[0], words[1], words[2], words[3], "1", words[4] }); //티어, 속성, 이름, 설명, 레벨, 인덱스
        }

        //눌렀을 때 함수 작동
        content0.onClick.AddListener(() => display("left"));
        content1.onClick.AddListener(() => display("mid"));
        content2.onClick.AddListener(() => display("right"));
    }
    void Update()
    {
        if (tower_tech_tier1 >= 10 && !ulock_tower_tech_2)
        { //타워테크 티어2의 해금 조건(티어 1이 10개 이상 선택이 되면 해금)
            Unlock_TowerTech_2();
            ulock_tower_tech_2 = true;
        }
        if (tower_tech_tier2 >= 3 && !unlock_tower_tech_3) //타워테크 티어3의 해금 조건(티어 2가 3개 이상 선택이 되면 해금)
        {
            Unlock_TowerTech_3();
            unlock_tower_tech_3 = true;
        }
        if (public_tech_tier1 >= 10 && !ulock_public_tech_2) //공용테크 티어2의 해금 조건(티어 1이 10개 이상 선택이 되면 해금)
        {
            Unlock_PublicTech_2();
            ulock_public_tech_2 = true;
        }
        if (public_tech_tier2 >= 3 && !unlock_public_tech_3) //공용테크 티어3의 해금 조건(티어 2가 3개 이상 선택이 되면 해금)
        {
            Unlock_PublicTech_3();
            unlock_public_tech_3 = true;
        }
        if (weapon_tech_tier1 >= 10 && !ulock_weapon_tech_2) //무기테크 티어2의 해금 조건(티어 1이 10개 이상 선택이 되면 해금)
        {
            Unlock_WeaponTech_2();
            ulock_weapon_tech_2 = true;
        }
        if (weapon_tech_tier2 >= 3 && !unlock_weapon_tech_3) //무기테크 티어3의 해금 조건(티어 2가 3개 이상 선택이 되면 해금)
        {
            Unlock_WeaponTech_3();
            unlock_weapon_tech_3 = true;
        }
    }

    public void Tech_Button_Click()
    {
        Tech_Panel.SetActive(true);
        BackGround.SetActive(true);

        image0 = GameObject.Find("Image0").GetComponent<Image>();
        name0 = GameObject.Find("Name0").GetComponent<Text>();
        text0 = GameObject.Find("Text0").GetComponent<Text>();


        image1 = GameObject.Find("Image1").GetComponent<Image>();
        name1 = GameObject.Find("Name1").GetComponent<Text>();
        text1 = GameObject.Find("Text1").GetComponent<Text>();


        image2 = GameObject.Find("Image2").GetComponent<Image>();
        name2 = GameObject.Find("Name2").GetComponent<Text>();
        text2 = GameObject.Find("Text2").GetComponent<Text>();

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

    public void Unlock_TowerTech_2() //타워 테크 티어 2 해금
    {
        print("해금2");
        TextAsset towerTech2 = Resources.Load<TextAsset>("TowerTech2");
        string[] lines_tower2 = towerTech2.text.Split('\n');

        foreach (string line_tower in lines_tower2)
        {
            string[] words = line_tower.Split('\t');
            print(words);
            tech_tower.Add(new List<string> { words[0], words[1], words[2], words[3], "2", words[4] }); //티어, 속성, 이름, 설명, 레벨, 인덱스
        }
    }
    public void Unlock_TowerTech_3() //타워 테크 티어 3 해금
    {
        print("해금3");
        TextAsset towerTech3 = Resources.Load<TextAsset>("TowerTech3");
        string[] lines_tower3 = towerTech3.text.Split('\n');

        foreach (string line_tower in lines_tower3)
        {
            string[] words = line_tower.Split('\t');
            tech_tower.Add(new List<string> { words[0], words[1], words[2], words[3], "3", words[4] }); //티어, 속성, 이름, 설명, 레벨, 인덱스
        }
    }

    public void Unlock_PublicTech_2() //공용 테크 티어 2 해금
    {
        print("해금2");
        TextAsset publicTech2 = Resources.Load<TextAsset>("PublicTech2");
        string[] lines_public2 = publicTech2.text.Split('\n');

        foreach (string line_public in lines_public2)
        {
            string[] words = line_public.Split('\t');
            tech_public.Add(new List<string> { words[0], words[1], words[2], words[3], "2", words[4] }); //티어, 속성, 이름, 설명, 레벨, 인덱스
        }
    }
    public void Unlock_PublicTech_3() //공용 테크 티어 3 해금
    {
        print("해금3");
        TextAsset publicTech3 = Resources.Load<TextAsset>("PublicTech3");
        string[] lines_public3 = publicTech3.text.Split('\n');

        foreach (string line_public in lines_public3)
        {
            string[] words = line_public.Split('\t');
            tech_public.Add(new List<string> { words[0], words[1], words[2], words[3], "3", words[4] }); //티어, 속성, 이름, 설명, 레벨, 인덱스
        }
    }

    public void Unlock_WeaponTech_2() //무기 테크 티어 2 해금
    {
        print("해금2");
        TextAsset weaponTech2 = Resources.Load<TextAsset>("WeaponTech2");
        string[] lines_weapon2 = weaponTech2.text.Split('\n');

        foreach (string line_weapon in lines_weapon2)
        {
            string[] words = line_weapon.Split('\t');
            tech_weapon.Add(new List<string> { words[0], words[1], words[2], words[3], "2", words[4] }); //티어, 속성, 이름, 설명, 레벨, 인덱스
        }
    }
    public void Unlock_WeaponTech_3() //무기 테크 티어 3 해금
    {
        print("해금3");
        TextAsset weaponTech3 = Resources.Load<TextAsset>("WeaponTech3");
        string[] lines_weapon3 = weaponTech3.text.Split('\n');

        foreach (string line_weapon in lines_weapon3)
        {
            string[] words = line_weapon.Split('\t');
            tech_weapon.Add(new List<string> { words[0], words[1], words[2], words[3], "3", words[4] }); //티어, 속성, 이름, 설명, 레벨, 인덱스
        }
    }

    public void Tech_Display_Panel()
    {
        rand_tower = Random.Range(0, tech_tower.Count);
        rand_public = Random.Range(0, tech_public.Count);
        rand_weapon = Random.Range(0, tech_weapon.Count);

        left = tech_tower[rand_tower][3]; //설명
        mid = tech_public[rand_public][3];
        right = tech_weapon[rand_weapon][3];

        //타워
        //티어에 따른 카드 테두리색 변경
        if (tech_tower[rand_tower][0] == "1") panel_Image0.color = new Color(0.2f, 0.3f, 0.6f, 1.0f);
        else if (tech_tower[rand_tower][0] == "2") panel_Image0.color = new Color(0.3f, 0.65f, 0.4f, 1.0f);
        else panel_Image0.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

        image0.sprite = Resources.Load<Sprite>(tech_tower[rand_tower][2]);
        name0.text = tech_tower[rand_tower][2];
        text0.text = left;

        //공용
        //티어에 따른 카드 테두리색 변경
        if (tech_public[rand_public][0] == "1") panel_Image1.color = new Color(0.2f, 0.3f, 0.6f, 1.0f);
        else if (tech_public[rand_public][0] == "2") panel_Image1.color = new Color(0.3f, 0.65f, 0.4f, 1.0f);
        else panel_Image1.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

        image1.sprite = Resources.Load<Sprite>(tech_public[rand_public][2]);
        name1.text = tech_public[rand_public][2];
        text1.text = mid;

        //무기
        //티어에 따른 카드 테두리색 변경
        if (tech_weapon[rand_weapon][0] == "1") panel_Image2.color = new Color(0.2f, 0.3f, 0.6f, 1.0f);
        else if (tech_weapon[rand_weapon][0] == "2") panel_Image2.color = new Color(0.3f, 0.65f, 0.4f, 1.0f);
        else panel_Image2.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

        image2.sprite = Resources.Load<Sprite>("weapon");
        name2.text = tech_weapon[rand_weapon][2];
        text2.text = right;


    }
    void Select_Tech(string type, string tier, string property, string name, string text, string index)
    {
        if (type == "T")
        {
            select_tech_tower.Add(new List<string> { tier, property, name, text, index }); //티어, 속성, 이름, 설명, 인덱스
            if (tier == "1") tower_tech_tier1 += 1;
            else if (tier == "2") tower_tech_tier2 += 1;
        }
        else if (type == "P")
        {
            select_tech_public.Add(new List<string> { tier, property, name, text, index }); //티어, 속성, 이름, 설명, 인덱스
            if (tier == "1") public_tech_tier1 += 1;
            else if (tier == "2") public_tech_tier2 += 1;
        }
        else if (type == "W")
        {
            select_tech_weapon.Add(new List<string> { tier, property, name, text, index }); //티어, 속성, 이름, 설명, 인덱스
            if (tier == "1") weapon_tech_tier1 += 1;
            else if (tier == "2") weapon_tech_tier2 += 1;
        }
    }

    void display(string i)
    {
        if (i == "left")
        {
            print(left);
            Select_Tech("T", tech_tower[rand_tower][0], tech_tower[rand_tower][1], tech_tower[rand_tower][2], tech_tower[rand_tower][3], tech_tower[rand_tower][5]);
            if (tech_tower[rand_tower][4] == "1")
            {
                tech_tower[rand_tower][4] = "2";
            }
            else if (tech_tower[rand_tower][4] == "2")
            {
                tech_tower[rand_tower][4] = "3";
            }
            else if (tech_tower[rand_tower][4] == "3")
            {
                tech_tower.Remove(tech_tower[rand_tower]);
            }
            SendSelectedAttributeToTower(tech_tower[rand_tower][0], tech_tower[rand_tower][1], tech_tower[rand_tower][5]);
        }
        else if (i == "mid")
        {
            print(mid);
            Select_Tech("P", tech_public[rand_public][0], tech_public[rand_public][1], tech_public[rand_public][2], tech_public[rand_public][3], tech_public[rand_public][5]);
            if (tech_public[rand_public][4] == "1")
            {
                tech_public[rand_public][4] = "2";
            }
            else if (tech_public[rand_public][4] == "2")
            {
                tech_public[rand_public][4] = "3";
            }
            else if (tech_public[rand_public][4] == "3")
            {
                tech_public.Remove(tech_public[rand_public]);
            }
        }
        else
        {
            print(right);
            Select_Tech("W", tech_weapon[rand_weapon][0], tech_weapon[rand_weapon][1], tech_weapon[rand_weapon][2], tech_weapon[rand_weapon][3], tech_weapon[rand_weapon][5]);
            if (tech_weapon[rand_weapon][4] == "1")
            {
                tech_weapon[rand_weapon][4] = "2";
            }
            else if (tech_weapon[rand_weapon][4] == "2")
            {
                tech_weapon[rand_weapon][4] = "3";
            }
            else if (tech_weapon[rand_weapon][4] == "3")
            {
                tech_weapon.Remove(tech_weapon[rand_weapon]);
            }
        }
        Tech_Exit_Button_Click();
    }

    public void SendSelectedAttributeToTower(string tier, string property, string index)
    {
        towerscript.tier = int.Parse(tier);
        towerscript.property = property;
        towerscript.index = int.Parse(index);
        

    }
}
