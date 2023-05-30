using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
class MonsterInfo {
    public List<int> round;
    public List<string> name;
    public List<int> spawnMonsterNumber;
    public List<int> spawnOnceNumOfMonster;
}
[Serializable]
class SpawnData {
    public List<MonsterInfo> Body;
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
