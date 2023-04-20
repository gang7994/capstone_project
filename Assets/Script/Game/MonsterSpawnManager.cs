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
                Vector3 spawnPosition = new Vector3(Random.Range(-50, 50), 0.5f, Random.Range(-50, 50));
                GameObject enemy = Instantiate(Monster, spawnPosition, Quaternion.identity);
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
        if ( day <= 5 )  wave = 0; 
        else if ( day <= 10) wave = 1;

        spawnMonsterNumber = monsterInfos[wave].spawnMonsterNumber[day-1];
        spawnOnceNumOfMonster = monsterInfos[wave].spawnOnceNumOfMonster[day-1];
        monsterName = "Monster/" + monsterInfos[wave].name;
        // monsterName = "Monster/BatElite";
        spawnDelay = 3f;

        Debug.Log($"{monsterName},{spawnMonsterNumber}, {spawnOnceNumOfMonster}");
    }

    private void SetSpawnData()
    {
        spawnList.JsonLoad();
        monsterInfos = spawnList.GetSpawnData();        
    }
}
