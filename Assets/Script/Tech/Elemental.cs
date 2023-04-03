using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Elemental : MonoBehaviour
{
    public bool isFunction1 = false;
    public bool isFunction3 = false;
    public bool isFunction5 = false;
    public bool isFunction7 = false;
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
            function42 = 0, function43 = 0, function44 = 0, function45 = 0, function46 = 0, function47 = 0, function48 = 0, function49 = 0;

    //Tier.1
    //tower
    public float fire_tower_weight = 0; //Function 0 value
    public float lightning_tower_weight = 0; //Function 2 value
    public float ice_tower_weight = 0; //Function 4 value
    public float earth_tower_weight = 0; //Function 6 value
    public float fire_tower_damage = 0; //Function 1 value
    public float lightning_tower_atkSpeed = 0;  //Function 3 value
    public float ice_tower_armour; //Function 5 value
    public float earth_tower_MaxHp; //Function 7 value

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
    public float fire_duration      = 1.0f;
    public float lightning_duration = 1.0f;
    public float ice_duration       = 1.0f;
    public float earth_duration     = 1.0f;
    //public
    public float tower_Max;
    public float fence_Max;
    public float tower_atkRange;
    public float character_speed;
    public float character_atkRange;
    public float character_MoneyLuck;


    //Tier.1
    //tower
    public float fire_tower_critical = 0; //Function 26 value
    public float lightning_tower_critical = 0; //Function 27 value





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
        all_function.Add(Public_Increase_TowerRange);
        all_function.Add(Public_Increase_PlayerSpeed);
        all_function.Add(Public_Increase_WeaponRange);
        all_function.Add(Public_Increase_Money);
        all_function.Add(Fire_Tower_Critical);
        all_function.Add(Lightning_Tower_Critical);
        all_function.Add(Ice_Tower_frostbite);
        all_function.Add(Earth_Tower_Reflex);
        all_function.Add(Fire_Weapon_Critical);
        all_function.Add(Lightning_Weapon_Fierce);
        all_function.Add(Ice_Weapon_Icicle);
        all_function.Add(Earth_Weapon_Barrier);
        all_function.Add(Fire_Spread_One);
        all_function.Add(Lightning_Shock);
        all_function.Add(Ice_DefDecrease);
        all_function.Add(Earth_AtkDecrease);
        all_function.Add(Fire_Dot_DamageUp);
        all_function.Add(Lightning_Dot_DamageUp);
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
                all_function[int.Parse(property_memory[i].Substring(3,1))]();
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
        isFunction1 = true;
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
        if(function3 == 1) lightning_tower_atkSpeed += 1.0f;
        else if(function3 == 2) lightning_tower_atkSpeed += 1.0f;
        else if(function3 == 3) lightning_tower_atkSpeed += 1.0f;
        isFunction3 = true;
    }
    public void Ice_Tower_Weight() { //Function 4
        function4 += 1;
        if(function4 == 1) ice_tower_weight += 1.0f;
        else if(function4 == 2) ice_tower_weight += 1.0f;
        else if(function4 == 3) ice_tower_weight += 1.0f;
    }   
    public void Ice_Tower_Armour(){  //Function 5
        function5+=1;
        isFunction5 = true;
        if(function5 == 1) ice_tower_armour += 1;
        else if(function5 == 2) ice_tower_armour += 1;
        else if(function5 == 3) ice_tower_armour += 1;
    }
    public void Earth_Tower_Weight() { //Function 6
        function6+=1;
        if(function6 == 1) earth_tower_weight += 0.5f;
        else if(function6 == 2) earth_tower_weight += 0.5f;
        else if(function6 == 3) earth_tower_weight += 0.5f;
    }
    public void Earth_Tower_MaxHp(){ //Function 7
        function7+=1;
        isFunction7 = true;
        if(function7 == 1) earth_tower_MaxHp += 1;
        else if(function7 == 2) earth_tower_MaxHp += 1;
        else if(function7 == 3) earth_tower_MaxHp += 1;

    } 

    

    public void Fire_Weapon_weight() { //Function 8

    }
    public void Fire_Weapon_Damage(){  //Function 9
    }
    public void Lightning_Weapon_Weight() { //Function 10

    }
    public void Lightning_Weapon_AtkSpeed(){  //Function 11

    }
    public void Ice_Weapon_Weight() { //Function 12

    }   
    public void Ice_Weapon_Armour(){  //Function 13

    }
    public void Earth_Weapon_Weight() { //Function 14

    }

    public void Earth_Weapon_MaxHp(){ //Function 15

    } 

    public void Fire_Duration() { //Function 16

    }
    public void Lightning_Duration() { //Function 17
        
    }

    public void Ice_Duration(){ //Function 18

    }

    public void Earth_Duration(){ //Function 19
        
    }
    
    public void Public_Increase_Tower(){ //Function 20

    }

    public void Public_Increase_Fence(){ //Function 21
        
    }

    public void Public_Increase_TowerRange(){ //Function 22

    }

    public void Public_Increase_PlayerSpeed(){//Function 23

        
    }
    public void Public_Increase_WeaponRange(){ //Function 24


    }

    public void Public_Increase_Money(){ //Function 25


    }


    //Tier. 2
    public void Fire_Tower_Critical(){ //Function 26
        function26 +=1;
        if (function26 == 1) fire_tower_critical+=1;
        else if(function26 == 2) fire_tower_critical+=1;
        
    }

    public void Lightning_Tower_Critical(){ //Function 27
        function27+=1;
        if (function27 == 1) lightning_tower_critical+=1;
        else if(function27 == 2) lightning_tower_critical+=1;
    }

    public void Ice_Tower_frostbite(){ //Function 28

    }

    public void Earth_Tower_Reflex(){ //Function 29
 
    }

    public void Fire_Weapon_Critical(){ //Function 30

    }

    public void Lightning_Weapon_Fierce(){ //Function 31

    }

    public void Ice_Weapon_Icicle(){ //Function 32

    }
    public void Earth_Weapon_Barrier(){ //Function 33

    }

    public void Fire_Spread_One(){ //Function 34

    }

    public void Lightning_Shock(){ //Function 35

    }
    public void Ice_DefDecrease(){ //Function 36
    }
    public void Earth_AtkDecrease(){ //Function 37
        
    }
    
    public void Fire_Dot_DamageUp(){ //Function 38

    }
    public void Lightning_Dot_DamageUp(){ //Function 39

    }
    public void Ice_AtkSpeed_Down(){ //Function 40

    }
    public void Earth_Drain(){ //Function 41
        
    }
    
    //Tier. 3
    public void Fire_Tower_Eternal(){ //Function 42
        
    }
    public void Lightning_Tower_Shock_All(){ // Function 43

    }
    public void Ice_Tower_Excution(){// Function 44
        
    }
    public void Earth_Tower_All_Bind(){// Function 45

    }

    public void Fire_Weapon_Flamethrower(){// Function 46

    }

    public void Lightning_Weapon_Mjolnir(){// Function 47

    }
    public void Ice_Weapon_Blizzard(){// Function 48

    }
    public void Earth_Weapon_Unbreakable(){// Function 49

    }
}
