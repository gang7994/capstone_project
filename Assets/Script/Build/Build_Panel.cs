using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class Build_Panel : MonoBehaviour
{
    public GameObject Panel;

    public GameObject TypeIcon1, TypeIcon2, TypeIcon3, TypeIcon4, TypeIcon5;
    public Sprite FireImage, LightImage, IceImage, EarthImage, WhiteImage;

    public Sprite[] typeImages = new Sprite[5]; 

    private Text Info;
    private Text Level;

    private Text Name;

    public Material[] mat = new Material[5]; 


    public string objectname;

    public GameObject TypePanel;

    // Start is called before the first frame update
    void Start()
    {
        Info = GameObject.Find("Info_Text").GetComponent<Text>();
        Level = GameObject.Find("Level_Text").GetComponent<Text>();
        Name = GameObject.Find("Name_Text").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        objectname = GameObject.Find("BuildMod_UI").GetComponent<Build_Manager>().objectname;
        if (objectname.Contains("tower")){
            Tower_Display_Panel(objectname);
        }
        else if (objectname.Contains("fence")){
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
        TypeIcon1.SetActive(false);
        TypeIcon2.SetActive(false);
        TypeIcon3.SetActive(false);
        TypeIcon4.SetActive(false);
        TypeIcon5.SetActive(false);
    }
    public void LevelUp_Click()
    {
        if (objectname.Contains("tower"))
        {
            if (GameObject.Find(objectname).GetComponent<Tower>().level<25){
                GameObject.Find(objectname).GetComponent<Tower>().level+=1;
            }
        }
        else if (objectname.Contains("fence"))
        {
            GameObject.Find(objectname).GetComponent<Fence>().level+=1;
        }
    }

    public void check_type(string ObjectName){
        int[] types = GameObject.Find(ObjectName).GetComponent<Tower>().types;
        for (int i=0; i<5; i++){
            if(types[0] == i){
                TypeIcon1.GetComponent<Image>().sprite = typeImages[i];
            }
            if(types[1] == i){
                TypeIcon2.GetComponent<Image>().sprite = typeImages[i];
            }
            if(types[2] == i){
                TypeIcon3.GetComponent<Image>().sprite = typeImages[i];
            }
            if(types[3] == i){
                TypeIcon4.GetComponent<Image>().sprite = typeImages[i];
            }
            if(types[4] == i){
                TypeIcon5.GetComponent<Image>().sprite = typeImages[i];
            }
        }
    }

    

    public void Tower_Display_Panel(string ObjectName)
    {
        int durability = GameObject.Find(ObjectName).GetComponent<Tower>().durability;
        int attack_val = GameObject.Find(ObjectName).GetComponent<Tower>().attack_val;
        int slot_num = GameObject.Find(ObjectName).GetComponent<Tower>().slot_num;
        int level = GameObject.Find(ObjectName).GetComponent<Tower>().level;
        int[] types = GameObject.Find(ObjectName).GetComponent<Tower>().types;
        Info.text = "Durability : " + durability + System.Environment.NewLine + "atk : " + attack_val + System.Environment.NewLine + "slot: " + slot_num;
        Level.text = level.ToString();
        Name.text = ObjectName;

        if(level > 4)
        {
            TypeIcon1.SetActive(true);
        }
        if (level > 9)
        {
            TypeIcon2.SetActive(true);
        }
        if(level > 14)
        {
            TypeIcon3.SetActive(true);
        }
        if(level > 19)
        {
            TypeIcon4.SetActive(true);
        }
        if(level > 24){
            TypeIcon5.SetActive(true);
            Level.text += " (max)";
        }
        check_type(ObjectName);
        //check_inchant();
    }
    
    
    public void Fence_Display_Panel(string ObjectName)
    {
        int durability = GameObject.Find(ObjectName).GetComponent<Fence>().durability;
        int level = GameObject.Find(ObjectName).GetComponent<Fence>().level;
        Info.text = "������ : " + durability;
        Level.text = level.ToString();
    }
    
    public void ResetBtn()
    {
        TypeIcon1.GetComponent<Image>().sprite = WhiteImage;
        TypeIcon2.GetComponent<Image>().sprite = WhiteImage;
        TypeIcon3.GetComponent<Image>().sprite = WhiteImage;
        TypeIcon4.GetComponent<Image>().sprite = WhiteImage;
        TypeIcon5.GetComponent<Image>().sprite = WhiteImage;
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
    /*
    public void check_inchant(){
        if(GameObject.Find(objectname).GetComponent<Tower>().types[0] == 1){
            TypeIcon1.GetComponent<Image>().sprite = FireImage;
        }
        else if(GameObject.Find(objectname).GetComponent<Tower>().types[0] == 2){
            TypeIcon1.GetComponent<Image>().sprite = LightImage;
        }
        else if(GameObject.Find(objectname).GetComponent<Tower>().types[0] == 3){
            TypeIcon1.GetComponent<Image>().sprite = IceImage;
        }
        else if(GameObject.Find(objectname).GetComponent<Tower>().types[0] == 4){
            TypeIcon1.GetComponent<Image>().sprite = EarthImage;
        }
        else if(GameObject.Find(objectname).GetComponent<Tower>().types[0] == 0){
            TypeIcon1.GetComponent<Image>().sprite = WhiteImage;
        }

        if(GameObject.Find(objectname).GetComponent<Tower>().types[1] == 1){
            TypeIcon1.GetComponent<Image>().sprite = FireImage;
        }
        else if(GameObject.Find(objectname).GetComponent<Tower>().types[1] == 2){
            TypeIcon1.GetComponent<Image>().sprite = LightImage;
        }
        else if(GameObject.Find(objectname).GetComponent<Tower>().types[1] == 3){
            TypeIcon1.GetComponent<Image>().sprite = IceImage;
        }
        else if(GameObject.Find(objectname).GetComponent<Tower>().types[1] == 4){
            TypeIcon1.GetComponent<Image>().sprite = EarthImage;
        }
        else if(GameObject.Find(objectname).GetComponent<Tower>().types[1] == 0){
            TypeIcon1.GetComponent<Image>().sprite = WhiteImage;
        }

        if(GameObject.Find(objectname).GetComponent<Tower>().types[2] == 1){
            TypeIcon1.GetComponent<Image>().sprite = FireImage;
        }
        else if(GameObject.Find(objectname).GetComponent<Tower>().types[2] == 2){
            TypeIcon1.GetComponent<Image>().sprite = LightImage;
        }
        else if(GameObject.Find(objectname).GetComponent<Tower>().types[2] == 3){
            TypeIcon1.GetComponent<Image>().sprite = IceImage;
        }
        else if(GameObject.Find(objectname).GetComponent<Tower>().types[2] == 4){
            TypeIcon1.GetComponent<Image>().sprite = EarthImage;
        }
        else if(GameObject.Find(objectname).GetComponent<Tower>().types[2] == 0){
            TypeIcon1.GetComponent<Image>().sprite = WhiteImage;
        }

        if(GameObject.Find(objectname).GetComponent<Tower>().types[3] == 1){
            TypeIcon1.GetComponent<Image>().sprite = FireImage;
        }
        else if(GameObject.Find(objectname).GetComponent<Tower>().types[3] == 2){
            TypeIcon1.GetComponent<Image>().sprite = LightImage;
        }
        else if(GameObject.Find(objectname).GetComponent<Tower>().types[3] == 3){
            TypeIcon1.GetComponent<Image>().sprite = IceImage;
        }
        else if(GameObject.Find(objectname).GetComponent<Tower>().types[3] == 4){
            TypeIcon1.GetComponent<Image>().sprite = EarthImage;
        }
        else if(GameObject.Find(objectname).GetComponent<Tower>().types[3] == 0){
            TypeIcon1.GetComponent<Image>().sprite = WhiteImage;
        }

        if(GameObject.Find(objectname).GetComponent<Tower>().types[4] == 1){
            TypeIcon1.GetComponent<Image>().sprite = FireImage;
        }
        else if(GameObject.Find(objectname).GetComponent<Tower>().types[4] == 2){
            TypeIcon1.GetComponent<Image>().sprite = LightImage;
        }
        else if(GameObject.Find(objectname).GetComponent<Tower>().types[4] == 3){
            TypeIcon1.GetComponent<Image>().sprite = IceImage;
        }
        else if(GameObject.Find(objectname).GetComponent<Tower>().types[4] == 4){
            TypeIcon1.GetComponent<Image>().sprite = EarthImage;
        }
        else if(GameObject.Find(objectname).GetComponent<Tower>().types[4] == 0){
            TypeIcon1.GetComponent<Image>().sprite = WhiteImage;
        }
    }
    */
    
}

