using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnManager : MonoBehaviour
{
    public Transform player;
    public GameObject Monster;
    private GameManager gameManager;
    private SpawnList spawnList;
    private List<MonsterInfo> monsterInfos;
    private MonsterInfo monsterInform;
    private bool enableSpwan = false;
    private List<int> spawnMonsterNumber; //최종 몬스터 수
    private List<string> monsterName = new List<string>();
    private float spawnDelay;
    public GameObject house;
    public List<Transform> spawnSpots;
    public int day_temp;
    
    void Start()
    {
        GameObject mainCamera = GameObject.Find("Main Camera");
        gameManager = mainCamera.GetComponent<GameManager>();
        spawnList = mainCamera.GetComponent<SpawnList>();
        SetSpawnData(); 
    }

    private void SpawnMonster(int num)
    {   
        if (enableSpwan){
            for (int i = 0; i < spawnMonsterNumber[num]; i++){
                Vector3 spawnPosition = RandomSpawn();
                GameObject enemy = Instantiate(Monster, spawnPosition, Quaternion.identity);               
                enemy.GetComponent<Monster_old>().house = house;
            }
        }
    }

    public IEnumerator SpawnManage(int day){
        SetSpawn(day);
        int i = 0;
        foreach (string monName in monsterName) {
            Monster = Resources.Load<GameObject>(monName);
            int spawnNumber = monsterName.Count;
            enableSpwan = true;
            Monster.GetComponent<Monster_old>().maxHealth = Monster.GetComponent<Monster_old>().maxHealth * (1 + day / 10);
            Monster.GetComponent<Monster_old>().curHealth = Monster.GetComponent<Monster_old>().curHealth * (1 + day / 10);
            yield return new WaitForSeconds(spawnDelay);
            SpawnMonster(i);
            
            spawnDelay = 10f;
            i++;
        }
        enableSpwan = false;
        yield break;
    }

    private void SetSpawn(int day)
    {
        bool isBossRound = SetSpawnMonsterNumber(day);
        monsterName = new List<string>();
        
        foreach (string monName in monsterInform.name){
            monsterName.Add("Monster/" + monName);
        }
        if (isBossRound) {
            if (day == 5) monsterName.Add("Monster_Boss/SpiderBoss");
            else if (day == 10) monsterName.Add("Monster_Boss/GhostBoss");
        }
    
        spawnDelay = 3f;

        int monsterSum = 0;
        foreach (int value in spawnMonsterNumber){
            monsterSum += value;
        }
        gameManager.SendMessage("ChangeMonsterNumText", monsterSum);
    }

    private void SetSpawnData()
    {
        spawnList.JsonLoad();
        monsterInfos = spawnList.GetSpawnData();        
    }

    private Vector3 RandomSpawn()
    {
        int n = Random.Range(0, spawnSpots.Count);
        return spawnSpots[n].transform.position;
    }

    private bool SetSpawnMonsterNumber(int day)
    {
        int wave = 0;
        int arrayNum = 0;
        bool isBossRound = false;

        switch (day) {
            case int n when (n < 5) : 
                wave = 0;
                arrayNum = (n - 1) % 5;
                break;
            case 5 : 
                wave = 1; 
                isBossRound = true;
                arrayNum = 0;
                break;
            case int n when (n < 10) :
                wave = 2;
                arrayNum = (n - 1) % 5; 
                break;
            case 10 : 
                wave = 3; 
                isBossRound = true; 
                arrayNum = 0;
                break;
        }

        monsterInform = monsterInfos[wave];
        
        switch (arrayNum){
            case 0:
                spawnMonsterNumber = monsterInform.spawnMonsterNumber.number1;
                break;
            case 1:
                spawnMonsterNumber = monsterInform.spawnMonsterNumber.number2;
                break;
            case 2:
                spawnMonsterNumber = monsterInform.spawnMonsterNumber.number3;
                break;
            case 3:
                spawnMonsterNumber = monsterInform.spawnMonsterNumber.number4;
                break;
        }

        return isBossRound;
    }
}
