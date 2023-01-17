using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class Build_Panel : MonoBehaviour
{
    public GameObject Panel;
    public GameObject Build_Panel_Exit;

    private Text Info;
    private Text Level;

    public string objectname;

    // Start is called before the first frame update
    void Start()
    {
        
        Info = GameObject.Find("Info_Text").GetComponent<Text>();
        Level = GameObject.Find("Level_Text").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        objectname = GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().objectname;
        if (objectname == "tower1" || objectname == "tower2" || objectname == "tower3"){
            Tower_Display_Panel(objectname);
        }
        else if (objectname == "fence1" || objectname == "fence2" || objectname == "fence3"){
            Fence_Display_Panel(objectname);
        }
    }

    public void Building_Panel_Click()
    {
        Panel.SetActive(true);
    }
    public void Building_Panel_Exit_Click()
    {
        Panel.SetActive(false);
    }
    public void LevelUp_Click()
    {
        if (objectname == "tower1" || objectname == "tower2" || objectname == "tower3"){
            GameObject.Find(objectname).GetComponent<Tower>().level+=1;
        }
        else if (objectname == "fence1" || objectname == "fence2" || objectname == "fence3"){
            GameObject.Find(objectname).GetComponent<Fence>().level+=1;
        }
        print("��ȭ");
    }

    public void Tower_Display_Panel(string ObjectName)
    {
        int durability = GameObject.Find(ObjectName).GetComponent<Tower>().durability;
        int attack_val = GameObject.Find(ObjectName).GetComponent<Tower>().attack_val;
        int slot_num = GameObject.Find(ObjectName).GetComponent<Tower>().slot_num;
        int level = GameObject.Find(ObjectName).GetComponent<Tower>().level;
        Info.text = "������ : " + durability + "\n���ݷ� : " + attack_val + "\n���԰��� : " + slot_num;
        Level.text = level.ToString();
    }
    
    
    public void Fence_Display_Panel(string ObjectName)
    {
        int durability = GameObject.Find(ObjectName).GetComponent<Fence>().durability;
        int level = GameObject.Find(ObjectName).GetComponent<Fence>().level;
        Info.text = "������ : " + durability;
        Level.text = level.ToString();
    }
    
    
}

