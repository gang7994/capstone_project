using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Elemental : MonoBehaviour
{
    public bool isFunction10 = false;
    public bool isFunction11 = false;

    //Function Count
    public int function0 = 0, function1 = 0, function2 = 0, function3 = 0, function4 = 0, function5 = 0, 
            function6 = 0, function7 = 0, function8 = 0, function9 = 0, function10 = 0, function11 = 0, 
            function12 = 0, function13 = 0, function14 = 0, function15 = 0, function16 = 0, function17 = 0, 
            function18 = 0, function19 = 0, function20 = 0, function21 = 0, function22 = 0, function23 = 0, 
            function24 = 0, function25 = 0, function26 = 0, function27 = 0, function28 = 0, function29 = 0, 
            function30 = 0, function31 = 0, function32 = 0, function33 = 0, function34 = 0, function35 = 0, 
            function36 = 0, function37 = 0, function38 = 0, function39 = 0, function40 = 0, function41 = 0, 
            function42 = 0, function43 = 0, function44 = 0, function45 = 0, function46 = 0, function47 = 0, 
            function48 = 0, function49 = 0, function50 = 0, function51 = 0;

    //Tier.1
    //tower
    public float fire_tower_weight = 0;         //Function 0 value
    public float fire_tower_damage = 0;         //Function 1 value
    public float lightning_tower_weight = 0;    //Function 2 value
    public float lightning_tower_atkSpeed = 0;  //Function 3 value
    public float ice_tower_weight = 0;          //Function 4 value
    public float ice_tower_armour = 0;              //Function 5 value
    public float earth_tower_weight = 0;        //Function 6 value
    public float earth_tower_MaxHp = 0;             //Function 7 value

    //weapon
    public float fire_character_damage;
    public float lightning_character_atkSpeed;
    public float ice_character_armour;
    public float earth_character_MaxHp;
    public float fire_character_weight;
    public float lightning_character_weight;
    public float ice_character_weight;
    public float earth_character_weight;
    //property
    public float fire_duration      = 3.0f;
    public float lightning_duration = 3.0f;
    public float ice_duration       = 3.0f;
    public float earth_duration     = 3.0f;
    //public
    public int tower_max = 3;
    public int fence_max = 5;
    public int tower_target = 3;
    public float tower_atkRange = 30.0f;
    public float character_speed = 5.0f;
    public float character_BulletSpeed = 20.0f;
    public float character_atkRange = 0.5f;
    public float character_moneyLuck = 1.0f;


    //Tier.2
    //tower
    public int fire_tower_critical = 0; //Function 28 value
    public int lightning_tower_critical = 0; //Function 29 value
    public int ice_tower_frostbite = 0; //Funtion 30 value
    public float earth_tower_reflex = 0; //Function 31 value

    //weapon
    public int fire_weapon_critical = 0; //Function 32 value
    public int lightning_fierce = 0; // Function 33 value
    public int icicle_damage = 0; // Function 34 value
    public float earth_weapon_armour = 0f; //Function 35 value

    //property
    public int fire_spread_one = 0; //Function 36 value
    public float earth_atkDecrease = 0; //Function 39 value
    public float fire_dot_damage = 1.0f; //Function 40 value

    public float lightning_shock = 0;
    public float lightning_damage = 0;
    public float ice_def_decrease = 0;
    public float ice_atk_decrease = 0;

    public float earth_drain = 0; //Function 43 value

    //Tier.3
    //tower
    public bool fire_tower_eternal = false; //Function 44 value

    //weapon
    public bool earth_tower_all_bind = false; //Function 47 value
    public bool fire_weapon_flamethrower = false; //Function 48 value
    public bool lightning_tower_shock = false;
    public bool earth_weapon_unbreakable = false; //Function 51 value


    public static List<string> property_memory = new List<string>();

    public List<bool> property_memory_run = new List<bool>(); 

    public List<Action> all_function = new List<Action>();


    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 118;i++) property_memory_run.Add(false);

        all_function.Add(Fire_Tower_Weight);
        all_function.Add(Fire_Tower_Damage);
        all_function.Add(Lightning_Tower_Weight);
        all_function.Add(Lightning_Tower_AtkSpeed);
        all_function.Add(Ice_Tower_Weight);
        all_function.Add(Ice_Tower_Armour);
        all_function.Add(Earth_Tower_Weight);
        all_function.Add(Earth_Tower_MaxHp);
        all_function.Add(Fire_Weapon_weight);
        all_function.Add(Fire_Weapon_Damage);
        all_function.Add(Lightning_Weapon_Weight);
        all_function.Add(Lightning_Weapon_AtkSpeed);
        all_function.Add(Ice_Weapon_Weight);
        all_function.Add(Ice_Weapon_Armour);
        all_function.Add(Earth_Weapon_Weight);
        all_function.Add(Earth_Weapon_MaxHp);
        all_function.Add(Fire_Duration);
        all_function.Add(Lightning_Duration);
        all_function.Add(Ice_Duration);
        all_function.Add(Earth_Duration);
        all_function.Add(Public_Increase_Tower);
        all_function.Add(Public_Increase_Fence);
        all_function.Add(Public_Increase_Target);
        all_function.Add(Public_Increase_TowerRange);
        all_function.Add(Public_Increase_PlayerSpeed);
        all_function.Add(Public_Increase_BulletSpeed);
        all_function.Add(Public_Increase_TowerRange);
        all_function.Add(Public_Increase_Money);
        all_function.Add(Fire_Tower_Critical);
        all_function.Add(Lightning_Tower_Critical);
        all_function.Add(Ice_Tower_frostbite);
        all_function.Add(Earth_Tower_Reflex);
        all_function.Add(Fire_Weapon_Critical);
        all_function.Add(Lightning_Weapon_Fierce);
        all_function.Add(Ice_Weapon_Icicle);
        all_function.Add(Earth_Weapon_Armour);
        all_function.Add(Fire_Spread_One);
        all_function.Add(Lightning_Shock);
        all_function.Add(Ice_DefDecrease);
        all_function.Add(Earth_AtkDecrease);
        all_function.Add(Fire_Dot_DamageUp);
        all_function.Add(Lightning_DamageUp);
        all_function.Add(Ice_AtkSpeed_Down);
        all_function.Add(Earth_Drain);
        all_function.Add(Fire_Tower_Eternal);
        all_function.Add(Lightning_Tower_Shock_All);
        all_function.Add(Ice_Tower_Excution);
        all_function.Add(Earth_Tower_All_Bind);
        all_function.Add(Fire_Weapon_Flamethrower);
        all_function.Add(Lightning_Weapon_Mjolnir);
        all_function.Add(Ice_Weapon_Blizzard);
        all_function.Add(Earth_Weapon_Unbreakable);

    }

    // Update is called once per frame
    void Update()
    {
        Apply_Characteristic();
    }
    
    public void Apply_Characteristic(){
        for(int i = 0; i<property_memory.Count;i++){
            if(!property_memory_run[i]) {
                all_function[int.Parse(property_memory[i].Substring(3))]();
                property_memory_run[i] = true;
            }
        }
    }
    public void Fire_Tower_Weight() { //Function 0
        function0 += 1;
        if(function0 == 1) fire_tower_weight += 0.5f;
        else if(function0 == 2) fire_tower_weight += 0.5f;
        else if(function0 == 3) fire_tower_weight += 0.5f;
    }
    public void Fire_Tower_Damage(){  //Function 1
        function1 += 1;
        if(function1 == 1) fire_tower_damage += 1.0f;
        else if(function1 == 2) fire_tower_damage += 1.0f;
        else if(function1 == 3) fire_tower_damage += 1.0f;
    }
    public void Lightning_Tower_Weight() { //Function 2
        function2 += 1;
        if(function2 == 1) lightning_tower_weight += 0.5f;
        else if(function2 == 2) lightning_tower_weight += 0.5f;
        else if(function2 == 3) lightning_tower_weight += 0.5f;
    }
    public void Lightning_Tower_AtkSpeed(){  //Function 3
        function3 += 1;
        if(function3 == 1) lightning_tower_atkSpeed += 0.5f;
        else if(function3 == 2) lightning_tower_atkSpeed += 0.5f;
        else if(function3 == 3) lightning_tower_atkSpeed += 0.5f;
    }
    public void Ice_Tower_Weight() { //Function 4
        function4 += 1;
        if(function4 == 1) ice_tower_weight += 0.5f;
        else if(function4 == 2) ice_tower_weight += 0.5f;
        else if(function4 == 3) ice_tower_weight += 0.5f;
    }   
    public void Ice_Tower_Armour(){  //Function 5
        function5+=1;
        if(function5 == 1) ice_tower_armour += 1.0f;
        else if(function5 == 2) ice_tower_armour += 1.0f;
        else if(function5 == 3) ice_tower_armour += 1.0f;
    }
    public void Earth_Tower_Weight() { //Function 6
        function6+=1;
        if(function6 == 1) earth_tower_weight += 0.5f;
        else if(function6 == 2) earth_tower_weight += 0.5f;
        else if(function6 == 3) earth_tower_weight += 0.5f;
    }
    public void Earth_Tower_MaxHp(){ //Function 7
        function7+=1;
        if(function7 == 1) earth_tower_MaxHp += 1.0f;
        else if(function7 == 2) earth_tower_MaxHp += 1.0f;
        else if(function7 == 3) earth_tower_MaxHp += 1.0f;

    } 

    

    public void Fire_Weapon_weight() { //Function 8
        function8 += 1;
        if (function8 == 1) fire_character_weight += 0.5f;
        else if (function8 == 2) fire_character_weight += 0.5f;
        else if (function8 == 3) fire_character_weight += 0.5f;
    }
    public void Fire_Weapon_Damage(){  //Function 9
        function9 += 1;
        if (function9 == 1) fire_character_damage += 1.0f;
        else if (function9 == 2) fire_character_damage += 1.0f;
        else if (function9 == 3) fire_character_damage += 1.0f;
    }
    public void Lightning_Weapon_Weight() { //Function 10
        function10 += 1;
        if (function10 == 1) lightning_character_weight += 0.5f;
        else if (function10 == 2) lightning_character_weight += 0.5f;
        else if (function10 == 3) lightning_character_weight += 0.5f;
    }
    public void Lightning_Weapon_AtkSpeed(){  //Function 11
        function11 += 1;
        if (function11 == 1) lightning_character_atkSpeed += 0.1f;
        else if (function11 == 2) lightning_character_atkSpeed += 0.1f;
        else if (function11 == 3) lightning_character_atkSpeed += 0.1f;
    }
    public void Ice_Weapon_Weight() { //Function 12
        function12 += 1;
        if (function12 == 1) ice_character_weight += 0.5f;
        else if (function12 == 2) ice_character_weight += 0.5f;
        else if (function12 == 3) ice_character_weight += 0.5f;
    }   
    public void Ice_Weapon_Armour(){  //Function 13
        function13 += 1;
        if (function13 == 1) ice_character_armour += 1;
        else if (function13 == 2) ice_character_armour += 1;
        else if (function13 == 3) ice_character_armour += 1;
    }
    public void Earth_Weapon_Weight() { //Function 14
        function14 += 1;
        if (function14 == 1) earth_character_weight += 0.5f;
        else if (function14 == 2) earth_character_weight += 0.5f;
        else if (function14 == 3) earth_character_weight += 0.5f;
    }

    public void Earth_Weapon_MaxHp(){ //Function 15
        function15 += 1;
        if (function15 == 1) earth_character_MaxHp += 1;
        else if (function15 == 2) earth_character_MaxHp += 1;
        else if (function15 == 3) earth_character_MaxHp += 1;
    } 

    public void Fire_Duration() { //Function 16
        function16 += 1;
        if (function16 == 1) fire_duration += 1.0f;
        else if (function16 == 2) fire_duration += 1.0f;
        else if (function16 == 3) fire_duration += 1.0f;
    }
    public void Lightning_Duration() { //Function 17
        function17 += 1;
        if (function17 == 1) lightning_duration += 1.0f;
        else if (function17 == 2) lightning_duration += 1.0f;
        else if (function17 == 3) lightning_duration += 1.0f;
    }

    public void Ice_Duration(){ //Function 18
        function18 += 1;
        if (function18 == 1) ice_duration += 1.0f;
        else if (function18 == 2) ice_duration += 1.0f;
        else if (function18 == 3) ice_duration += 1.0f;
    }

    public void Earth_Duration(){ //Function 19
        function19 += 1;
        if (function19 == 1) earth_duration += 1.0f;
        else if (function19 == 2) earth_duration += 1.0f;
        else if (function19 == 3) earth_duration += 1.0f;
    }
    
    
    //Public//
    public void Public_Increase_Tower(){ //Function 20
        function20++;
        if(function20 == 1) {
            tower_max += 1;
        }
        else if(function20 == 2) {
            tower_max += 2;
        }
        else if(function20 == 3) {
            tower_max += 3;
        }

    }

    public void Public_Increase_Fence(){ //Function 21
        function21++;
        if(function21 == 1) {
            fence_max += 1;
        }
        else if(function21 == 2) {
            fence_max += 2;
        }
        else if(function21 == 3) {
            fence_max += 4;
        }
    }

    public void Public_Increase_Target(){  // Function 22
        function22++;
        if(function22 == 1) {
            tower_target += 1;
        }
        else if(function22 == 2) {
            tower_target += 2;
        }
        else if(function22 == 3) {
            tower_target += 3;
        }
    }


    public void Public_Increase_TowerRange(){ //Function 23
        function23++;
        if(function23 == 1) {
            tower_atkRange += 5.0f;
        }
        else if(function23 == 2) {
            tower_atkRange += 5.0f;
        }
        else if(function23 == 3) {
            tower_atkRange += 5.0f;
        }
    }

    public void Public_Increase_PlayerSpeed(){//Function 24
        function24++;
        if(function24 == 1) {
            character_speed += 1.0f;
        }
        else if(function24 == 2) {
            character_speed += 1.0f;
        }
        else if(function24 == 3) {
            character_speed += 1.0f;
        }
    }
    public void Public_Increase_BulletSpeed(){ //Function 25
        function25++;
        if(function25 == 1) {
            character_BulletSpeed += 5.0f;
        }
        else if(function25 == 2) {
            character_BulletSpeed += 5.0f;
        }
        else if(function25 == 3) {
            character_BulletSpeed += 5.0f;
        }

    }


    public void Public_Increase_AttackRange(){ //Function 26
        function26++;
        if(function26 == 1) {
            character_atkRange += 0.1f;
        }
        else if(function26 == 2) {
            character_atkRange += 0.1f;
        }
        else if(function26 == 3) {
            character_atkRange += 0.2f;
        }
    }

    public void Public_Increase_Money(){ //Function 27
        function27++;
        if(function27 == 1) {
            character_moneyLuck += 0.05f;
        }
        else if(function27 == 2) {
            character_moneyLuck += 0.05f;
        }
        else if(function27 == 3) {
            character_moneyLuck += 0.05f;
        }

    }

    //Tier. 2
    public void Fire_Tower_Critical(){ //Function 28
        function28 +=1;
        if (function28 == 1) fire_tower_critical+=1;
        else if(function28 == 2) fire_tower_critical+=1;
        
    }

    public void Lightning_Tower_Critical(){ //Function 29
        function29+=1;
        if (function29 == 1) lightning_tower_critical+=1;
        else if(function29 == 2) lightning_tower_critical+=1;
    }

    public void Ice_Tower_frostbite(){ //Function 30
        function30 += 1;
        if (function30 == 1) ice_tower_frostbite += 1;
        else if(function30 == 2) ice_tower_frostbite += 1;
    }

    public void Earth_Tower_Reflex(){ //Function 31
        function31+=1;
        if (function31 == 1) earth_tower_reflex+=1.0f;
        else if(function31 == 2) earth_tower_reflex+=1.0f;
    }

    public void Fire_Weapon_Critical(){ //Function 32
        function32 +=1;
        if (function32 == 1) fire_weapon_critical+=1;
        else if(function32 == 2) fire_weapon_critical+=1;
    }

    public void Lightning_Weapon_Fierce(){ //Function 33
        function33 += 1;
        if (function33 == 1) lightning_fierce += 1;
        if (function33 == 2) lightning_fierce += 1;
    }

    public void Ice_Weapon_Icicle(){ //Function 34
        function34 += 1;
        if (function34 == 1) icicle_damage += 20;
        else if(function34 == 2) icicle_damage += 20;
    }
    public void Earth_Weapon_Armour(){ //Function 35
        function35 += 1;
        if (function35 == 1) earth_weapon_armour += 0.1f;
        if (function35 == 2) earth_weapon_armour += 0.5f;
    }

    public void Fire_Spread_One(){ //Function 36
        function36 +=1;
        if (function36 == 1) fire_spread_one+=1;
        else if(function36 == 2) fire_spread_one+=1;
    }

    public void Lightning_Shock(){ //Function 37
        function37 += 1;
        if (function37 == 1) lightning_shock += 1.0f;
        else if(function37 == 2) lightning_shock += 1.0f;
    }
    public void Ice_DefDecrease(){ //Function 38
        function38 += 1;
        if (function38 == 1) ice_def_decrease += 0.1f;
        else if(function38 == 2) ice_def_decrease += 0.1f;
    }
    public void Earth_AtkDecrease(){ //Function 39
        function39 += 1;
        if (function39 == 1) earth_atkDecrease += 0.1f;
        else if(function39 == 2) earth_atkDecrease += 0.5f;
    }
    
    public void Fire_Dot_DamageUp(){ //Function 40
        function40 +=1;
        if (function40 == 1) fire_dot_damage+=1.0f;
        else if(function40 == 2) fire_dot_damage+=1.0f;
    }
    public void Lightning_DamageUp(){ //Function 41
        function41 += 1;
        if(function41 == 1) lightning_damage += 0.1f;
        else if (function41 == 2) lightning_damage += 0.1f;
    }
    public void Ice_AtkSpeed_Down(){ //Function 42
        function42 += 1;
        if(function42 == 1) ice_atk_decrease += 1.0f;
        else if(function42 == 2) ice_atk_decrease += 1.0f;
    }
    public void Earth_Drain(){ //Function 43
        function43 += 1;
        if(function43 == 1) earth_drain += 1.0f;
        else if (function43 == 2) earth_drain += 1.0f;
    }
    
    //Tier. 3
    public void Fire_Tower_Eternal(){ //Function 44
        fire_tower_eternal = true;
    }
    public void Lightning_Tower_Shock_All(){ // Function 45
        lightning_tower_shock = true;
    }
    public void Ice_Tower_Excution(){// Function 46
        
    }
    public void Earth_Tower_All_Bind(){// Function 47
        earth_tower_all_bind = true;
    }

    public void Fire_Weapon_Flamethrower(){// Function 48
        fire_weapon_flamethrower = true;
    }

    public void Lightning_Weapon_Mjolnir(){// Function 49

    }
    public void Ice_Weapon_Blizzard(){// Function 51

    }
    public void Earth_Weapon_Unbreakable(){// Function 51
        earth_weapon_unbreakable = true;
    }
}
