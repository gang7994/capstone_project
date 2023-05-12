using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class Build_Panel : MonoBehaviour
{
    public Slider hpBar;
    public GameObject Tower_Panel;
    public GameObject Fence_Panel;
    public GameObject TechUI_Panel;

    public GameObject TypeIcon1_Y, TypeIcon2_Y, TypeIcon3_Y, TypeIcon4_Y, TypeIcon5_Y;
    public GameObject TypeIcon1_N, TypeIcon2_N, TypeIcon3_N, TypeIcon4_N, TypeIcon5_N;
    public Sprite FireImage, LightImage, IceImage, EarthImage, WhiteImage;

    public Sprite[] typeImages = new Sprite[5]; 

    private Text Info;
    private Text Level;

    private Text Name;
    private Text Upgrade_Gold, Repair_Gold;
    

    public Material[] mat = new Material[5]; 


    string objectname;

    public GameObject TypePanel;

    // Start is called before the first frame update
    void Start()
    {
        Info = GameObject.Find("Info_Text").GetComponent<Text>();
        Level = GameObject.Find("Level_Text").GetComponent<Text>();
        Name = GameObject.Find("Name_Text").GetComponent<Text>();
        Upgrade_Gold = GameObject.Find("Upgrade_Gold").GetComponent<Text>();
        Repair_Gold = GameObject.Find("Repair_Gold").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        objectname = GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().select_Build;
        //print(objectname);
        if (objectname.Contains("tower")){
            Tower_Display_Panel(objectname);
        }
        else if (objectname.Contains("fence"))
        {
            Fence_Display_Panel(objectname);
        }

    }

    public void Tower_Panel_Click()
    {
        GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().BackGround.SetActive(true);
        Tower_Panel.SetActive(true);
        TypeIcon1_N.SetActive(true);
        TypeIcon2_N.SetActive(true);
        TypeIcon3_N.SetActive(true);
        TypeIcon4_N.SetActive(true);
        TypeIcon5_N.SetActive(true);
    }
    public void Tower_Panel_Exit_Click()
    {
        Tower_Panel.SetActive(false);
        GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().Btn_Tower_Panel.SetActive(false);
        GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().BackGround.SetActive(false);
    }

    public void Fence_Panel_Click()
    {
        GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().BackGround.SetActive(true);
        Fence_Panel.SetActive(true);
    }
    public void Fence_Panel_Exit_Click()
    {
        Fence_Panel.SetActive(false);
        GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().Btn_Fence_Panel.SetActive(false);
        GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().BackGround.SetActive(false);
    }


    public void TechUI_Panel_Exit_Click()
    {
        TechUI_Panel.SetActive(false);
    }
    public void LevelUp_Click()
    {
        if (objectname.Contains("tower"))
        {
            if (GameObject.Find(objectname).GetComponent<Tower>().level < 25)
            {
                GameObject.Find(objectname).GetComponent<Tower>().level += 1;
                GameObject.Find(objectname).GetComponent<Tower>().max_hp += 10;
                GameObject.Find(objectname).GetComponent<Tower>().basic_max_hp += 10;
                GameObject.Find(objectname).GetComponent<Tower>().hp += 10;
                GameObject.Find(objectname).GetComponent<Tower>().attack_val += 1;
                GameObject.Find(objectname).GetComponent<Tower>().basic_attack_val += 1;
                Upgrade_Gold.text = (100 + GameObject.Find(objectname).GetComponent<Tower>().level *100).ToString();

            }
        }
        else if (objectname.Contains("fence"))
        {
            GameObject.Find(objectname).GetComponent<Fence>().level += 1;
            GameObject.Find(objectname).GetComponent<Fence>().max_hp += 10;
            GameObject.Find(objectname).GetComponent<Fence>().hp += 10;
        }
        else return;
    }

    public void repair(){
        if (objectname.Contains("tower"))
        {
            GameObject.Find(objectname).GetComponent<Tower>().hp = GameObject.Find(objectname).GetComponent<Tower>().max_hp; 

        }
        else if (objectname.Contains("fence"))
        {
            GameObject.Find(objectname).GetComponent<Fence>().hp = GameObject.Find(objectname).GetComponent<Fence>().max_hp;  
        }
        else return;
    }

    public void check_type(string ObjectName){
        List<int> types = GameObject.Find(ObjectName).GetComponent<Tower>().types;
        for (int i=0; i<5; i++){
            if(types[0] == i){
                TypeIcon1_Y.GetComponent<Image>().sprite = typeImages[i];
            }
            if(types[1] == i){
                TypeIcon2_Y.GetComponent<Image>().sprite = typeImages[i];
            }
            if(types[2] == i){
                TypeIcon3_Y.GetComponent<Image>().sprite = typeImages[i];
            }
            if(types[3] == i){
                TypeIcon4_Y.GetComponent<Image>().sprite = typeImages[i];
            }
            if(types[4] == i){
                TypeIcon5_Y.GetComponent<Image>().sprite = typeImages[i];
            }
        }
    }

    

    public void Tower_Display_Panel(string ObjectName)
    {
        float max_hp = GameObject.Find(ObjectName).GetComponent<Tower>().max_hp;
        float hp = GameObject.Find(ObjectName).GetComponent<Tower>().hp;
        float attack_val = GameObject.Find(ObjectName).GetComponent<Tower>().attack_val;
        int slot_num = GameObject.Find(ObjectName).GetComponent<Tower>().slot_num;
        int level = GameObject.Find(ObjectName).GetComponent<Tower>().level;
        List<int> types = GameObject.Find(ObjectName).GetComponent<Tower>().types;
        Info.text = "타워 정보" + System.Environment.NewLine + "최대 내구도 : " + max_hp + System.Environment.NewLine + "현재 내구도 : " + hp + System.Environment.NewLine + "공격력 : " + attack_val + System.Environment.NewLine + "속성 수 : " + slot_num;
        Level.text = "LV : " + level.ToString();
        Name.text = ObjectName;
        Upgrade_Gold.text = (level*500+100).ToString();
        int repair_gold = Mathf.RoundToInt((1-(hp / max_hp)) * 10000);
        Repair_Gold.text = repair_gold.ToString();
        hpBar.value = (float) hp / (float) max_hp;

        if(level > 4)
        {
            TypeIcon1_N.SetActive(false);
            TypeIcon2_N.SetActive(true);
            TypeIcon3_N.SetActive(true);
            TypeIcon4_N.SetActive(true);
            TypeIcon5_N.SetActive(true);
        }
        if (level > 9)
        {
            TypeIcon1_N.SetActive(false);
            TypeIcon2_N.SetActive(false);
            TypeIcon3_N.SetActive(true);
            TypeIcon4_N.SetActive(true);
            TypeIcon5_N.SetActive(true);
        }
        if(level > 14)
        {
            TypeIcon1_N.SetActive(false);
            TypeIcon2_N.SetActive(false);
            TypeIcon3_N.SetActive(false);
            TypeIcon4_N.SetActive(true);
            TypeIcon5_N.SetActive(true);
        }
        if(level > 19)
        {
            TypeIcon1_N.SetActive(false);
            TypeIcon2_N.SetActive(false);
            TypeIcon3_N.SetActive(false);
            TypeIcon4_N.SetActive(false);
            TypeIcon5_N.SetActive(true);
        }
        if(level > 24){
            TypeIcon1_N.SetActive(false);
            TypeIcon2_N.SetActive(false);
            TypeIcon3_N.SetActive(false);
            TypeIcon4_N.SetActive(false);
            TypeIcon5_N.SetActive(false);
            Level.text += " (max)";
        }
        check_type(ObjectName);
        //check_inchant();
    }
    
    
    public void Fence_Display_Panel(string ObjectName)
    {
        float max_hp = GameObject.Find(ObjectName).GetComponent<Fence>().max_hp;
        float hp = GameObject.Find(ObjectName).GetComponent<Fence>().hp;
        int level = GameObject.Find(ObjectName).GetComponent<Fence>().level;
        Info.text = "펜스 정보" + System.Environment.NewLine + "최대 내구도 : " + max_hp + System.Environment.NewLine + "현재 내구도 : " + hp;
        Level.text = "LV : " + level.ToString();
        Name.text = ObjectName;
        hpBar.value = (float) hp / (float) max_hp;
        Upgrade_Gold.text = (level*300+100).ToString();
        int repair_gold = Mathf.RoundToInt((1-(hp / max_hp)) * 5000);
        Repair_Gold.text = repair_gold.ToString();
    }
    
    public void ResetBtn()
    {
        TypeIcon1_Y.GetComponent<Image>().sprite = WhiteImage;
        TypeIcon2_Y.GetComponent<Image>().sprite = WhiteImage;
        TypeIcon3_Y.GetComponent<Image>().sprite = WhiteImage;
        TypeIcon4_Y.GetComponent<Image>().sprite = WhiteImage;
        TypeIcon5_Y.GetComponent<Image>().sprite = WhiteImage;
        for(int i=0; i<5; i++){
            GameObject.Find(objectname).GetComponent<Tower>().types[i] = 0;
        }
    }
    public void select1()
    {
        GameObject.Find(objectname).GetComponent<Tower>().select_number = 1;
        TypePanel.SetActive(true);
    }

    public void select2()
    {
        GameObject.Find(objectname).GetComponent<Tower>().select_number = 2;
        TypePanel.SetActive(true);
    }

    public void select3()
    {
        GameObject.Find(objectname).GetComponent<Tower>().select_number = 3;
        TypePanel.SetActive(true);
    }

    public void select4()
    {
        GameObject.Find(objectname).GetComponent<Tower>().select_number = 4;
        TypePanel.SetActive(true);
    }

    public void select5()
    {
        GameObject.Find(objectname).GetComponent<Tower>().select_number = 5;
        TypePanel.SetActive(true);
    }

    public void selectFire()
    {
        if(GameObject.Find(objectname).GetComponent<Tower>().select_number == 1)
        {
            GameObject.Find(objectname).GetComponent<Tower>().types[0] = 1;
            //TypeIcon1.GetComponent<Image>().sprite = FireImage;
            TypePanel.SetActive(false);
        }
        else if (GameObject.Find(objectname).GetComponent<Tower>().select_number == 2)
        {
           // TypeIcon2.GetComponent<Image>().sprite = FireImage;
            GameObject.Find(objectname).GetComponent<Tower>().types[1] = 1;
            TypePanel.SetActive(false);
        }
        else if (GameObject.Find(objectname).GetComponent<Tower>().select_number == 3)
        {
          //  TypeIcon3.GetComponent<Image>().sprite = FireImage;
            GameObject.Find(objectname).GetComponent<Tower>().types[2] = 1;
            TypePanel.SetActive(false);
        }
        else if (GameObject.Find(objectname).GetComponent<Tower>().select_number == 4)
        {
          //  TypeIcon4.GetComponent<Image>().sprite = FireImage;
            GameObject.Find(objectname).GetComponent<Tower>().types[3] = 1;
            TypePanel.SetActive(false);
        }
        else if (GameObject.Find(objectname).GetComponent<Tower>().select_number == 5)
        {
          //  TypeIcon5.GetComponent<Image>().sprite = FireImage;
            GameObject.Find(objectname).GetComponent<Tower>().types[4] = 1;
            TypePanel.SetActive(false);
        }

        
    }


    public void selectLightning(){
        if(GameObject.Find(objectname).GetComponent<Tower>().select_number == 1)
        {
            GameObject.Find(objectname).GetComponent<Tower>().types[0] = 2;
            //TypeIcon1.GetComponent<Image>().sprite = FireImage;
            TypePanel.SetActive(false);
        }
        else if (GameObject.Find(objectname).GetComponent<Tower>().select_number == 2)
        {
           // TypeIcon2.GetComponent<Image>().sprite = FireImage;
            GameObject.Find(objectname).GetComponent<Tower>().types[1] = 2;
            TypePanel.SetActive(false);
        }
        else if (GameObject.Find(objectname).GetComponent<Tower>().select_number == 3)
        {
          //  TypeIcon3.GetComponent<Image>().sprite = FireImage;
            GameObject.Find(objectname).GetComponent<Tower>().types[2] = 2;
            TypePanel.SetActive(false);
        }
        else if (GameObject.Find(objectname).GetComponent<Tower>().select_number == 4)
        {
          //  TypeIcon4.GetComponent<Image>().sprite = FireImage;
            GameObject.Find(objectname).GetComponent<Tower>().types[3] = 2;
            TypePanel.SetActive(false);
        }
        else if (GameObject.Find(objectname).GetComponent<Tower>().select_number == 5)
        {
          //  TypeIcon5.GetComponent<Image>().sprite = FireImage;
            GameObject.Find(objectname).GetComponent<Tower>().types[4] = 2;
            TypePanel.SetActive(false);
        }
       // gameObject.GetComponent<TrailRenderer>().material = mat[2];
    }
    public void selectIce(){
        if(GameObject.Find(objectname).GetComponent<Tower>().select_number == 1)
        {
            GameObject.Find(objectname).GetComponent<Tower>().types[0] = 3;
            //TypeIcon1.GetComponent<Image>().sprite = FireImage;
            TypePanel.SetActive(false);
        }
        else if (GameObject.Find(objectname).GetComponent<Tower>().select_number == 2)
        {
           // TypeIcon2.GetComponent<Image>().sprite = FireImage;
            GameObject.Find(objectname).GetComponent<Tower>().types[1] = 3;
            TypePanel.SetActive(false);
        }
        else if (GameObject.Find(objectname).GetComponent<Tower>().select_number == 3)
        {
          //  TypeIcon3.GetComponent<Image>().sprite = FireImage;
            GameObject.Find(objectname).GetComponent<Tower>().types[2] = 3;
            TypePanel.SetActive(false);
        }
        else if (GameObject.Find(objectname).GetComponent<Tower>().select_number == 4)
        {
          //  TypeIcon4.GetComponent<Image>().sprite = FireImage;
            GameObject.Find(objectname).GetComponent<Tower>().types[3] = 3;
            TypePanel.SetActive(false);
        }
        else if (GameObject.Find(objectname).GetComponent<Tower>().select_number == 5)
        {
          //  TypeIcon5.GetComponent<Image>().sprite = FireImage;
            GameObject.Find(objectname).GetComponent<Tower>().types[4] = 3;
            TypePanel.SetActive(false);
        }
    }
    
    public void selectEarth(){
        if(GameObject.Find(objectname).GetComponent<Tower>().select_number == 1)
        {
            GameObject.Find(objectname).GetComponent<Tower>().types[0] = 4;
            //TypeIcon1.GetComponent<Image>().sprite = FireImage;
            TypePanel.SetActive(false);
        }
        else if (GameObject.Find(objectname).GetComponent<Tower>().select_number == 2)
        {
           // TypeIcon2.GetComponent<Image>().sprite = FireImage;
            GameObject.Find(objectname).GetComponent<Tower>().types[1] = 4;
            TypePanel.SetActive(false);
        }
        else if (GameObject.Find(objectname).GetComponent<Tower>().select_number == 3)
        {
          //  TypeIcon3.GetComponent<Image>().sprite = FireImage;
            GameObject.Find(objectname).GetComponent<Tower>().types[2] = 4;
            TypePanel.SetActive(false);
        }
        else if (GameObject.Find(objectname).GetComponent<Tower>().select_number == 4)
        {
          //  TypeIcon4.GetComponent<Image>().sprite = FireImage;
            GameObject.Find(objectname).GetComponent<Tower>().types[3] = 4;
            TypePanel.SetActive(false);
        }
        else if (GameObject.Find(objectname).GetComponent<Tower>().select_number == 5)
        {
          //  TypeIcon5.GetComponent<Image>().sprite = FireImage;
            GameObject.Find(objectname).GetComponent<Tower>().types[4] = 4;
            TypePanel.SetActive(false);
        }
    }
    
}

