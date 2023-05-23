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
    private bool enableSpwan = false;
    private int spawnMonsterNumber; //최종 몬스터 수
    private int spawnOnceNumOfMonster; //한번에 스폰할 몬스터 갯수
    private List<string> monsterName = new List<string>();
    private float spawnDelay;
    public GameObject house;
    
    void Start()
    {
        GameObject mainCamera = GameObject.Find("Main Camera");
        gameManager = mainCamera.GetComponent<GameManager>();
        spawnList = mainCamera.GetComponent<SpawnList>();
        SetSpawnData(); 
    }

    private void SpawnMonster()
    {   
        if (enableSpwan){
            for (int i = 0; i < spawnOnceNumOfMonster; i++){
                Vector3 spawnPosition = new Vector3(Random.Range(-30, 30), 0.5f, Random.Range(-30, 30));
                GameObject enemy = Instantiate(Monster, spawnPosition, Quaternion.identity);
                enemy.GetComponent<Monster_old>().house = house;
                gameManager.SendMessage("ChangeMonsterNumText", 1);
            }
        }
    }

    public IEnumerator SpawnManage(int day){
        SetSpawn(day);
        
        foreach (string monName in monsterName) {
            Monster = Resources.Load<GameObject>(monName);
            int spawnNumber = spawnMonsterNumber / spawnOnceNumOfMonster;
            enableSpwan = true;

            for (int i = 0; i < spawnNumber; i++){
                yield return new WaitForSeconds(spawnDelay);
                SpawnMonster();
            }
        }
        enableSpwan = false;
        yield break;
    }

    private void SetSpawn(int day)
    {
        int wave = 0;
        int arrayNum = 0;
        bool isBossRound = false;

        switch (day) {
            case 1 :
                wave = 0;
                break;
            case int n when (n < 5) : 
                wave = 1;
                arrayNum = (n - 2) % 5;
                break;
            case 5 : 
                wave = 2; 
                isBossRound = true;
                break;
            case int n when (n < 10) :
                wave = 3;
                arrayNum = (n - 1) % 5; 
                break;
            case 10 : 
                wave = 4; 
                isBossRound = true; 
                break;
        }

        MonsterInfo monsterInform = monsterInfos[wave];
        monsterName = new List<string>();

        //로직 수정 필요
        if (!isBossRound) 
            foreach (string monName in monsterInform.name){
                monsterName.Add("Monster/" + monName);
            }
        else 
            monsterName.Add("Monster_Boss/" + monsterInform.name);

        spawnMonsterNumber = monsterInform.spawnMonsterNumber[arrayNum];
        spawnOnceNumOfMonster = monsterInform.spawnOnceNumOfMonster[arrayNum]; 
        spawnDelay = 3f;

        Debug.Log($"{monsterName[0]},{spawnMonsterNumber}, {spawnOnceNumOfMonster}");
    }

    private void SetSpawnData()
    {
        spawnList.JsonLoad();
        monsterInfos = spawnList.GetSpawnData();        
    }
}
