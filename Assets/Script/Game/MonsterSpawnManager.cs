using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnManager : MonoBehaviour
{
    public Transform player;
    public GameObject Monster; //prefab으로 받는 형태, 나중에 리스트나 표로 받아와야 함
    private GameManager gameManager;
    private SpawnList spawnList;
    private bool enableSpwan = false;
    private int spawnMonsterNumber; //나중엔 리스트나 표로 몬스터 수도 받아와야 함
    private int spawnOnceNumOfMonster; //한번에 스폰할 몬스터 갯수
    private float spawnDelay;
    
    void Start()
    {
        GameObject mainCamera = GameObject.Find("Main Camera");
        gameManager = mainCamera.GetComponent<GameManager>();
        spawnList = mainCamera.GetComponent<SpawnList>();
        SetSpawnData(); 
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public IEnumerator SpawnManage(){
        int spawnNumber = spawnMonsterNumber / spawnOnceNumOfMonster;
        enableSpwan = true;

        for (int i = 0; i < spawnNumber; i++){
            yield return new WaitForSeconds(spawnDelay);
            SpawnMonster();
        }

        enableSpwan = false;
        yield break;
    }

    private void SetSpawnData()
    {
        spawnList.JsonLoad();

        spawnMonsterNumber = spawnList.data.spawnMonsterNumber[0];
        spawnOnceNumOfMonster = spawnList.data.spawnOnceNumOfMonster[0];
        Debug.Log($"{spawnMonsterNumber}, {spawnOnceNumOfMonster}");
        
        spawnDelay = 3f;
    }
}
