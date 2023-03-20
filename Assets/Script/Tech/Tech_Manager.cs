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
    private Image image0, image1, image2; //��ũ �г� ������ �̹���

    int rand_tower, rand_public, rand_weapon; //��ũ �г� ������ ���� ����
    string left, mid, right; //Ÿ��, ����, ����

    List<List<string>> tech_tower = new List<List<string>>();
    List<List<string>> tech_public = new List<List<string>>();
    List<List<string>> tech_weapon = new List<List<string>>();

    public List<List<string>> select_tech_tower = new List<List<string>>();
    bool ulock_tower_tech_2 = false, unlock_tower_tech_3_fire = false, unlock_tower_tech_3_lightning = false, unlock_tower_tech_3_ice = false, unlock_tower_tech_3_earth = false;
    int tower_tech_tier1 = 0, tower_tech_fire = 0, tower_tech_lightning = 0, tower_tech_ice = 0, tower_tech_earth = 0;

    public List<List<string>> select_tech_public = new List<List<string>>();
    bool ulock_public_tech_2 = false, unlock_public_tech_3 = false;
    int public_tech_tier1 = 0, public_tech_tier2 = 0;

    public List<List<string>> select_tech_weapon = new List<List<string>>();
    bool ulock_weapon_tech_2 = false, unlock_weapon_tech_3_fire = false, unlock_weapon_tech_3_lightning = false, unlock_weapon_tech_3_ice = false, unlock_weapon_tech_3_earth = false;
    int weapon_tech_tier1 = 0, weapon_tech_fire = 0, weapon_tech_lightning = 0, weapon_tech_ice = 0, weapon_tech_earth = 0;

    public Image panel_Image0, panel_Image1, panel_Image2;

    void Start()
    {
        //��ũƮ��.txt�� �޾ƿ� ����Ʈ�� �־���
        TextAsset towerTech = Resources.Load<TextAsset>("TowerTech1");
        string[] lines_tower = towerTech.text.Split('\n');
        TextAsset publicTech = Resources.Load<TextAsset>("PublicTech1");
        string[] lines_public = publicTech.text.Split('\n');
        TextAsset weaponTech = Resources.Load<TextAsset>("WeaponTech1");
        string[] lines_weapon = weaponTech.text.Split('\n');

        foreach (string line_tower in lines_tower)
        {
            string[] words = line_tower.Split('|');
            tech_tower.Add(new List<string> { words[0], words[1], words[2], words[3], "1", words[4] }); //Ƽ��, �Ӽ�, �̸�, ����, ����, �ε���
        }

        foreach (string line_public in lines_public)
        {
            string[] words = line_public.Split('|');
            tech_public.Add(new List<string> { words[0], words[1], words[2], words[3], "1", words[4] }); //Ƽ��, �Ӽ�, �̸�, ����, ����, �ε���
        }

        foreach (string line_weapon in lines_weapon)
        {
            string[] words = line_weapon.Split('|');
            tech_weapon.Add(new List<string> { words[0], words[1], words[2], words[3], "1", words[4] }); //Ƽ��, �Ӽ�, �̸�, ����, ����, �ε���
        }


        content0.onClick.AddListener(() => display("left"));
        content1.onClick.AddListener(() => display("mid"));
        content2.onClick.AddListener(() => display("right"));
    }
    void Update()
    {
        if (tower_tech_tier1 >= 10 && !ulock_tower_tech_2) //타워 특성 1티어 10개 선택하면 2단계 특성해금
        { 
            Unlock_TowerTech_2();
            ulock_tower_tech_2 = true;
        }
        /*
        if (tower_tech_fire >= 3 && !unlock_tower_tech_3_fire) //타워 특성 1,2티어 10개 선택하면 3단계 특성해금
        {
            Unlock_TowerTech_3_Fire();
            unlock_tower_tech_3_fire = true;
        }
        if (tower_tech_lightning >= 10 && !unlock_tower_tech_3_lightning) 
        {
            Unlock_TowerTech_3_Lightning();
            unlock_tower_tech_3_lightning = true;
        }
        if (tower_tech_ice >= 10 && !unlock_tower_tech_3_ice) 
        {
            Unlock_TowerTech_3_Ice();
            unlock_tower_tech_3_ice = true;
        }
        if (tower_tech_earth >= 10 && !unlock_tower_tech_3_earth) 
        {
            Unlock_TowerTech_3_Earth();
            unlock_tower_tech_3_earth = true;
        }
*/
        if (public_tech_tier1 >= 10 && !ulock_public_tech_2)
        {
            Unlock_PublicTech_2();
            ulock_public_tech_2 = true;
        }
        if (public_tech_tier2 >= 3 && !unlock_public_tech_3)
        {
            Unlock_PublicTech_3();
            unlock_public_tech_3 = true;
        }

        if (weapon_tech_tier1 >= 10 && !ulock_weapon_tech_2) //무기 특성 1티어 10개 선택하면 2단계 특성해금
        {
            Unlock_WeaponTech_2();
            ulock_weapon_tech_2 = true;
        }
        if (weapon_tech_fire >= 10 && !unlock_weapon_tech_3_fire) //타워 특성 1,2티어 10개 선택하면 3단계 특성해금
        {
            Unlock_WeaponTech_3_Fire();
            unlock_weapon_tech_3_fire = true;
        }
        if (weapon_tech_lightning >= 10 && !unlock_weapon_tech_3_lightning)
        {
            Unlock_WeaponTech_3_Lightning();
            unlock_weapon_tech_3_lightning = true;
        }
        if (weapon_tech_ice >= 10 && !unlock_weapon_tech_3_ice)
        {
            Unlock_WeaponTech_3_Ice();
            unlock_weapon_tech_3_ice = true;
        }
        if (weapon_tech_earth >= 10 && !unlock_weapon_tech_3_earth)
        {
            Unlock_WeaponTech_3_Earth();
            unlock_weapon_tech_3_earth = true;
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


    public void Unlock_TowerTech_2() //타워 테크 2티어 해금 함수
    {
        TextAsset towerTech2 = Resources.Load<TextAsset>("TowerTech2");
        string[] lines_tower2 = towerTech2.text.Split('\n');

        foreach (string line_tower in lines_tower2)
        {
            string[] words = line_tower.Split('|');
            print(words);
            tech_tower.Add(new List<string> { words[0], words[1], words[2], words[3], "2", words[4] }); //Tier, Property, Name, Content, Number, Index
        }
    }
    public void Unlock_TowerTech_3_Fire() //타워 테크 3티어 불속성 해금 함수
    {
        print("타워 불속성 3티어 해금");
        TextAsset towerTech3 = Resources.Load<TextAsset>("TowerTech3_F");
        string[] lines_tower3 = towerTech3.text.Split('\n');

        foreach (string line_tower in lines_tower3)
        {
            string[] words = line_tower.Split('|');
            tech_tower.Add(new List<string> { words[0], words[1], words[2], words[3], "3", words[4] }); //Tier, Property, Name, Content, Number, Index
        }
    }
    public void Unlock_TowerTech_3_Lightning() //타워 테크 3티어 전기속성 해금 함수
    {
        TextAsset towerTech3 = Resources.Load<TextAsset>("TowerTech3_L");
        string[] lines_tower3 = towerTech3.text.Split('\n');

        foreach (string line_tower in lines_tower3)
        {
            string[] words = line_tower.Split('|');
            tech_tower.Add(new List<string> { words[0], words[1], words[2], words[3], "3", words[4] }); //Tier, Property, Name, Content, Number, Index
        }
    }
    public void Unlock_TowerTech_3_Ice()  //타워 테크 3티어 얼음속성 해금 함수
    {
        TextAsset towerTech3 = Resources.Load<TextAsset>("TowerTech3_I");
        string[] lines_tower3 = towerTech3.text.Split('\n');

        foreach (string line_tower in lines_tower3)
        {
            string[] words = line_tower.Split('|');
            tech_tower.Add(new List<string> { words[0], words[1], words[2], words[3], "3", words[4] }); //Tier, Property, Name, Content, Number, Index
        }
    }
    public void Unlock_TowerTech_3_Earth() //타워 테크 3티어 대지속성 해금 함수
    {
        TextAsset towerTech3 = Resources.Load<TextAsset>("TowerTech3_E");
        string[] lines_tower3 = towerTech3.text.Split('\n');

        foreach (string line_tower in lines_tower3)
        {
            string[] words = line_tower.Split('|');
            tech_tower.Add(new List<string> { words[0], words[1], words[2], words[3], "3", words[4] }); //Tier, Property, Name, Content, Number, Index
        }
    }
    
    public void Unlock_PublicTech_2() //공용 테크 2티어 해금 함수
    {
        TextAsset publicTech2 = Resources.Load<TextAsset>("PublicTech2");
        string[] lines_public2 = publicTech2.text.Split('\n');

        foreach (string line_public in lines_public2)
        {
            string[] words = line_public.Split('|');
            tech_public.Add(new List<string> { words[0], words[1], words[2], words[3], "2", words[4] }); //Tier, Property, Name, Content, Number, Index
        }
    }
    public void Unlock_PublicTech_3() //공용 테크 3티어 해금 함수
    {
        TextAsset publicTech3 = Resources.Load<TextAsset>("PublicTech3");
        string[] lines_public3 = publicTech3.text.Split('\n');

        foreach (string line_public in lines_public3)
        {
            string[] words = line_public.Split('|');
            tech_public.Add(new List<string> { words[0], words[1], words[2], words[3], "3", words[4] }); //Tier, Property, Name, Content, Number, Index
        }
    }

    public void Unlock_WeaponTech_2() //무기 테크 2티어 해금 함수
    {
        TextAsset weaponTech2 = Resources.Load<TextAsset>("WeaponTech2");
        string[] lines_weapon2 = weaponTech2.text.Split('\n');

        foreach (string line_weapon in lines_weapon2)
        {
            string[] words = line_weapon.Split('|');
            tech_weapon.Add(new List<string> { words[0], words[1], words[2], words[3], "2", words[4] }); //Tier, Property, Name, Content, Number, Index
        }
    }
    public void Unlock_WeaponTech_3_Fire() //무기 테크 3티어 불속성 해금 함수
    {
        TextAsset weaponTech3 = Resources.Load<TextAsset>("WeaponTech3_F");
        string[] lines_weapon3 = weaponTech3.text.Split('\n');

        foreach (string line_weapon in lines_weapon3)
        {
            string[] words = line_weapon.Split('|');
            tech_weapon.Add(new List<string> { words[0], words[1], words[2], words[3], "3", words[4] }); //Tier, Property, Name, Content, Number, Index
        }
    }
    public void Unlock_WeaponTech_3_Lightning() //무기 테크 3티어 전기속성 해금 함수
    {
        TextAsset weaponTech3 = Resources.Load<TextAsset>("WeaponTech3_L");
        string[] lines_weapon3 = weaponTech3.text.Split('\n');

        foreach (string line_weapon in lines_weapon3)
        {
            string[] words = line_weapon.Split('|');
            tech_weapon.Add(new List<string> { words[0], words[1], words[2], words[3], "3", words[4] }); //Tier, Property, Name, Content, Number, Index
        }
    }
    public void Unlock_WeaponTech_3_Ice() //무기 테크 3티어 얼음속성 해금 함수
    {
        TextAsset weaponTech3 = Resources.Load<TextAsset>("WeaponTech3_I");
        string[] lines_weapon3 = weaponTech3.text.Split('\n');

        foreach (string line_weapon in lines_weapon3)
        {
            string[] words = line_weapon.Split('|');
            tech_weapon.Add(new List<string> { words[0], words[1], words[2], words[3], "3", words[4] }); //Tier, Property, Name, Content, Number, Index
        }
    }
    public void Unlock_WeaponTech_3_Earth() //무기 테크 3티어 대지속성 해금 함수
    {
        TextAsset weaponTech3 = Resources.Load<TextAsset>("WeaponTech3_E");
        string[] lines_weapon3 = weaponTech3.text.Split('\n');

        foreach (string line_weapon in lines_weapon3)
        {
            string[] words = line_weapon.Split('|');
            tech_weapon.Add(new List<string> { words[0], words[1], words[2], words[3], "3", words[4] }); //Tier, Property, Name, Content, Number, Index
        }
    }



    public void Tech_Display_Panel()
    {
        rand_tower = Random.Range(0, tech_tower.Count);
        rand_public = Random.Range(0, tech_public.Count);
        rand_weapon = Random.Range(0, tech_weapon.Count);

        left = tech_tower[rand_tower][3]; 
        mid = tech_public[rand_public][3];
        right = tech_weapon[rand_weapon][3];

        //Tower
        if (tech_tower[rand_tower][0] == "1") panel_Image0.color = new Color(0.2f, 0.3f, 0.6f, 1.0f);
        else if (tech_tower[rand_tower][0] == "2") panel_Image0.color = new Color(0.3f, 0.65f, 0.4f, 1.0f);
        else panel_Image0.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

        image0.sprite = Resources.Load<Sprite>(tech_tower[rand_tower][2]);
        name0.text = tech_tower[rand_tower][2];
        text0.text = left;

        //Public
        if (tech_public[rand_public][0] == "1") panel_Image1.color = new Color(0.2f, 0.3f, 0.6f, 1.0f);
        else if (tech_public[rand_public][0] == "2") panel_Image1.color = new Color(0.3f, 0.65f, 0.4f, 1.0f);
        else panel_Image1.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

        image1.sprite = Resources.Load<Sprite>(tech_public[rand_public][2]);
        name1.text = tech_public[rand_public][2];
        text1.text = mid;

        //Weapon
        if (tech_weapon[rand_weapon][0] == "1") panel_Image2.color = new Color(0.2f, 0.3f, 0.6f, 1.0f);
        else if (tech_weapon[rand_weapon][0] == "2") panel_Image2.color = new Color(0.3f, 0.65f, 0.4f, 1.0f);
        else panel_Image2.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

        image2.sprite = Resources.Load<Sprite>(tech_weapon[rand_weapon][2]);
        name2.text = tech_weapon[rand_weapon][2];
        text2.text = right;


    }
    void Select_Tech(string type, string tier, string property, string name, string text, string index)
    {
        if (type == "T")
        {
            select_tech_tower.Add(new List<string> { tier, property, name, text, index });
            if (tier == "1") tower_tech_tier1 += 1;
            switch(property) {
                case "F":
                    tower_tech_fire+=1;
                    break;
                case "L":
                    tower_tech_lightning+=1;
                    break;
                case "I":
                    tower_tech_ice+=1;
                    break;
                case "E":
                    tower_tech_earth+=1;
                    break;
            }
        }
        else if (type == "P")
        {
            select_tech_public.Add(new List<string> { tier, property, name, text, index });
            if (tier == "1") public_tech_tier1 += 1;
            else if (tier == "2") public_tech_tier2 += 1;
        }
        else if (type == "W")
        {
            select_tech_weapon.Add(new List<string> { tier, property, name, text, index });
            if (tier == "1") weapon_tech_tier1 += 1;
            switch(property) {
                case "F":
                    weapon_tech_fire+=1;
                    break;
                case "L":
                    weapon_tech_lightning+=1;
                    break;
                case "I":
                    weapon_tech_ice+=1;
                    break;
                case "E":
                    weapon_tech_earth+=1;
                    break;
            }
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
        if(tier.Equals("1")){
            Tower.property_memory.Add(properties.IndexOf(property)*4+int.Parse(index));
        }
        else if(tier.Equals("2")){
            Tower.property_memory.Add(properties.IndexOf(property)*3+int.Parse(index)+16);
        }
        else if(tier.Equals("3")){
            Tower.property_memory.Add(properties.IndexOf(property)*2+int.Parse(index)+28);
        }
    }
}
