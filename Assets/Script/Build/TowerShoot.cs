using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TowerShoot : MonoBehaviour
{
    public GameObject target;
    public int type;

    public float towerAtk;
    public string property_type;
    public float propertyAtk;
    public float property_duration;
    public float property_exhaust;

    public float fireAtk = 1.0f;
    public float lightningAtk = 1.0f;
    public float iceAtk = 0f; //attack speed decrease
    public float earthAtk = 0f; // tower durability recover

    public float fire_duration = 1.0f;
    public float lightning_duration = 1.0f;
    public float ice_duration = 1.0f;
    public float earth_duration = 1.0f;

    public float fire_exhaust = 0f;
    public float lightning_exhaust = 0f;
    public float ice_exhaust = 1.0f;
    public float earth_exhaust = 0f;
    
    public Material[] mat = new Material[5]; 

    public Material[] ranShoot = new Material[5];


   
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "MonsterAttack")
        {

            print("발사체 정보 " + towerAtk +"/"+ property_type +"/"+propertyAtk+"/"+ property_duration +"/"+ property_exhaust);
            DestroyBullet();
        }
    }

    void Update(){
        Vector3 direction = target.transform.position - transform.position; 
        transform.Translate(direction.normalized * 10f * Time.deltaTime, Space.World);
    }

    void DestroyBullet(){
        Destroy(gameObject, 1f*Time.deltaTime);
    }

}