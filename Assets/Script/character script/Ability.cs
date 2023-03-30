using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Fire_Weight_W()
    {
        Player.GetComponent<Player>().fire_weight += 0.5f;
    }

    void Fire_S_Time_W()
    {
        Player.GetComponent<Player>().fire_duration += 1.0f;
    }
    void Fire_S_Damage_W()
    {
        Player.GetComponent<Player>().fire_Atk += 1.0f;
    }

    void Fire_Damage_W()
    {
        Player.GetComponent<Player>().fire_DamageNum += 1.0f;
    }

    void Lightning_Weight_W()
    {
        Player.GetComponent<Player>().lightning_weight += 0.5f;
    }

    void Lightning_S_Time_W()
    {
        Player.GetComponent<Player>().lightning_duration += 1.0f;
    }

    void Lightning_S_Damage_W()
    {
        Player.GetComponent<Player>().lightning_Atk += 1.0f;
    }

    void Lightning_AS_W()
    {
        Player.GetComponent<Player>().lightning_AtkSpeed += 1.0f;
    }

    void Ice_Weight_W()
    {
        Player.GetComponent<Player>().ice_weight += 0.5f;
    }

    void Ice_S_Time_W()
    {
        Player.GetComponent<Player>().ice_duration += 1.0f;
    }

    void Ice_S_Exhaust_W()
    {
        Player.GetComponent<Player>().ice_exhaust += 1.0f;
    }

    void Ice_Armour_W()
    {
        Player.GetComponent<Player>().Character_armour += 1.0f;
    }

    void Earth_Weight_W()
    {
        Player.GetComponent<Player>().earth_weight += 0.5f;
    }

    void Earth_S_Time()
    {
        Player.GetComponent<Player>().earth_duration += 1.0f;
    }

    void Earth_Heal_W()
    {
        Player.GetComponent<Player>().Character_heal += 1.0f;
    }

    void Earth_MaxHp_W()
    {
        Player.GetComponent<Player>().Character_MaxHp += 1;
    }
}
