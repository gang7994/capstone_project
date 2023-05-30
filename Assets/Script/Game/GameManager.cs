using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;
using TMPro;

public class GameManager : MonoBehaviour
{
    MonsterSpawnManager spawnManager;
    DayManager dayManager;
    GameObject[] btns = new GameObject[4];
    GameObject monsterAmountText;
    GameObject monsterAmount;
    public GameObject moneyText1;
    public GameObject moneyText2;
    public int money = 1000;
    public TextAsset jsonFile;
    private RankingData rankingData;
    bool isGameover = false;

    private bool isNight = false;
    
    private AudioSource[] BGM;
    private AudioSource Day;
    private AudioSource Night;

    private int monsterNum = 0;
    private int day = 1;
    private int kill_count = 0;
    void Start()
    {
        spawnManager = GetComponent<MonsterSpawnManager>();
        dayManager = GameObject.Find("Day Bar").GetComponent<DayManager>();
        btns = GameObject.FindGameObjectsWithTag("Button");
        monsterAmountText = GameObject.Find("MonsterAmountText");
        monsterAmount = GameObject.Find("MonsterAmount");
        monsterAmountText.SetActive(false);
        Resumed();

        string jsonText = jsonFile.text;
        rankingData = JsonUtility.FromJson<RankingData>(jsonText);
        BGM = gameObject.GetComponents<AudioSource>();
        Day = BGM[0];
        Night = BGM[1];
    }

    void Update(){
        moneyText1.GetComponent<TextMeshProUGUI>().text = money.ToString();
        moneyText2.GetComponent<TextMeshProUGUI>().text = money.ToString();
    }

    void SetIsNight(bool isNight){
        this.isNight = isNight;

        if (this.isNight == true) {
            NightEvent();
            Day.Stop();
            Night.Play();
        }
        else {
            DayEvent();
            Night.Stop();
            Day.Play();
        }
    }

    private void DayEvent()
    {
        day += 1;
        Debug.Log("now day is " + day);
        if(GameObject.Find("MainCharacter").GetComponent<Player>().Health > 90)
        {
            GameObject.Find("MainCharacter").GetComponent<Player>().Health = 100;
        }
        else
        {
            GameObject.Find("MainCharacter").GetComponent<Player>().Health += 10;
        }
        if (GameObject.Find("Baker_house").GetComponent<Base>().hp > 900)
        {
            GameObject.Find("Baker_house").GetComponent<Base>().hp = 1000;
        }
        else
        {
            GameObject.Find("Baker_house").GetComponent<Base>().hp += 100;
        }
        UIEnable(true);
    }

    private void NightEvent()
    {        
        UIEnable(false);
        MonsterSpawn();
    }

    private void MonsterSpawn(){    
        spawnManager.StartCoroutine("SpawnManage", day);
    }

    private void UIEnable(bool isEnable){
        for (int i = 0; i < btns.Length; i++) btns[i].SetActive(isEnable);
        monsterAmountText.SetActive(!isEnable);
    }

    private void CheckIsClear(){
        bool isClaer;

        if (this.monsterNum <= 0) isClaer = true;
        else isClaer = false;

        dayManager.SendMessage("SetIsClear", isClaer);
    }
    public void KillCount(int i){
        kill_count += i;
    }

    public void ChangeMonsterNumText(int monsterNumber){
        this.monsterNum += monsterNumber;
        monsterAmount.GetComponent<TextMeshProUGUI>().text = this.monsterNum.ToString();

        if (this.monsterNum <= 0) CheckIsClear();
    }
    
    public void GameOver(){
        // need implementation
        if(!isGameover) {
            AddRankingData(day,kill_count);
            isGameover = true;
        }
    }

    public void Exit(){
        Application.Quit();
    }

    private void Resumed() {
        Time.timeScale = 1f;
    }

    public int GetDay(){
        return day;
    }


    private void SaveRankingData()
    {
        string jsonData = JsonUtility.ToJson(rankingData);
        File.WriteAllText("Assets/Resources/RankList.json", jsonData);
    }

    public void AddRankingData(int survivalDays, int monstersKilled)
    {
        RankingEntry playerData = new RankingEntry
        {
            survivalDays = survivalDays,
            monstersKilled = monstersKilled
        };

        rankingData.ranking.Add(playerData);
        SaveRankingData();
    }
}
