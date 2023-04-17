using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
class MonsterData {
    public string name;
    public List<int> round;
    public List<int> spawnMonsterNumber;
    public List<int> spawnOnceNumOfMonster;
}
class SpawnList : MonoBehaviour
{
    public MonsterData data;
    
    // Start is called before the first frame update
    void Start()
    {
        JsonLoad();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void JsonLoad()
    {
        var loadedJson = Resources.Load<TextAsset>("roundSpawn");
        data = JsonUtility.FromJson<MonsterData>(loadedJson.ToString());
        Debug.Log($"{data.name}, {data.round[1]}, {data.spawnMonsterNumber[0]}");
    }
}
