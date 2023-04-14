using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Monster; //prefab으로 받는 형태, 나중에 리스트나 표로 받아와야 함
    public bool enableSpwan = false;
    int numberOfMonster; //나중엔 리스트나 표로 몬스터 수도 받아와야 함
    public Transform player;
    void Start()
    {
        numberOfMonster = 30;
        SpawnManage();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnMonster()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-50, 50), 0.5f, Random.Range(-50, 50));
        if (enableSpwan){
            GameObject enemy = Instantiate(Monster, spawnPosition, Quaternion.identity);
        }
    }

    public void SpawnManage(){
        for (int i = 0; i < numberOfMonster; i++){
            SpawnMonster();
        }
    }
}
