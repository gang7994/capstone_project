using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
class MonsterInfo {
    public List<int> round;
    public List<string> name;
    public SpawnInfo spawnMonsterNumber;
    public List<int> spawnOnceNumOfMonster;
}
[Serializable]
class SpawnData {
    public List<MonsterInfo> Body;
}
[Serializable]
class SpawnInfo {
    public List<int> number1;
    public List<int> number2;
    public List<int> number3;
    public List<int> number4;
}
class SpawnList : MonoBehaviour
{
    private List<MonsterInfo> monsterInfos;
    private SpawnData data;
    
    public void JsonLoad()
    {
        var loadedJson = Resources.Load<TextAsset>("roundSpawn");
        data = JsonUtility.FromJson<SpawnData>(loadedJson.ToString());
        monsterInfos = data.Body;
    }
    
    public List<MonsterInfo> GetSpawnData()
    {
        return data.Body;
    }
}
