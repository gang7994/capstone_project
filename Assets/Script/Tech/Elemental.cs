using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elemental : MonoBehaviour
{
    //1단계
    //속성 지속시간
    public float fire_duration      = 1.0f;
    public float lightning_duration = 1.0f;
    public float ice_duration       = 1.0f;
    public float earth_duration     = 1.0f;

    //속성 당 타워 수치
    public float fire_tower_damage;
    public float lightning_tower_atkSpeed;
    public float ice_tower_armour;
    public float earth_tower_MaxHp;

    //속성 타워 확률
    public float fire_tower_weight;
    public float lightning_tower_weight;
    public float ice_tower_weight;
    public float earth_tower_weight;

    //속성 당 캐릭터 수치
    public float fire_character_damage;
    public float lightning_character_atkSpeed;
    public float ice_character_armour;
    public float earth_character_MaxHp;

    //속성 캐릭터 확률
    public float fire_character_weight;
    public float lightning_character_weight;
    public float ice_character_weight;
    public float earth_character_weight;

    //공용 타워
    public float tower_Max;
    public float fence_Max;
    public float tower_atkRange;

    //공용 캐릭터
    public float character_speed;
    public float character_atkRange;
    public float character_MoneyLuck;


    //2단계
    //


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
