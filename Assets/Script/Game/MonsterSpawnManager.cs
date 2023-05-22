using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnManager : MonoBehaviour
{
    public Transform player;
    public GameObject Monster; //prefab으로 받는 형태, 나중에 리스트나 표로 받아와야 함
    private GameManager gameManager;
    private SpawnList spawnList;
    private List<MonsterInfo> monsterInfos;
    private bool enableSpwan = false;
    private int spawnMonsterNumber; //최종 몬스터 수
    private int spawnOnceNumOfMonster; //한번에 스폰할 몬스터 갯수
    private string monsterName;
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
        Monster = Resources.Load<GameObject>(monsterName);
        int spawnNumber = spawnMonsterNumber / spawnOnceNumOfMonster;
        enableSpwan = true;

        for (int i = 0; i < spawnNumber; i++){
            yield return new WaitForSeconds(spawnDelay);
            SpawnMonster();
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
            case int n when (n < 5) : 
                wave = 0;
                arrayNum = (n - 1) % 5;
                break;
            case 5 : 
                wave = 1; 
                isBossRound = true;
                break;
            case int n when (n < 10) :
                wave = 2;
                arrayNum = (n - 1) % 5; 
                break;
            case 10 : 
                wave = 3; 
                isBossRound = true; 
                break;
        }

        MonsterInfo monsterInform = monsterInfos[wave];

        //로직 수정 필요
        if (!isBossRound) 
            monsterName = "Monster/" + monsterInform.name;
        else 
            monsterName = "Monster_Boss/" + monsterInform.name;

        spawnMonsterNumber = monsterInform.spawnMonsterNumber[arrayNum];
        spawnOnceNumOfMonster = monsterInform.spawnOnceNumOfMonster[arrayNum]; 
        spawnDelay = 3f;

        Debug.Log($"{monsterName},{spawnMonsterNumber}, {spawnOnceNumOfMonster}");
    }

    private void SetSpawnData()
    {
        spawnList.JsonLoad();
        monsterInfos = spawnList.GetSpawnData();        
    }
}
