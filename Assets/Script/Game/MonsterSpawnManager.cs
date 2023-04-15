using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnManager : MonoBehaviour
{
    public Transform player;
    public GameObject Monster; //prefab으로 받는 형태, 나중에 리스트나 표로 받아와야 함
    private bool enableSpwan = false;
    private int spawnMonsterNumber; //나중엔 리스트나 표로 몬스터 수도 받아와야 함
    private int spawnOnceNumOfMonster; //한번에 스폰할 몬스터 갯수
    private float spawnDelay;
    public int nowMonsterNumber = 0;
    
    void Start()
    {
        spawnMonsterNumber = 30;
        spawnOnceNumOfMonster = 10;
        spawnDelay = 3f;
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
                nowMonsterNumber += 1;
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
}
