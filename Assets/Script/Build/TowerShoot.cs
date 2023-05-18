using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class TowerShoot : MonoBehaviour
{
    public GameObject target;
    public Tower towerScript;

    public float towerAtk;
    public string property_type;




    
    public Material[] mat = new Material[5]; 

    public Material[] ranShoot = new Material[5];


   
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Map"))
        {
            Destroy(this.gameObject);
        }
    }
    
    void Update(){
        
        try {
            Vector3 direction = target.transform.position - transform.position; 
            transform.Translate(direction.normalized * 15f * Time.deltaTime, Space.World);
        }
        catch (Exception ex) {
            Destroy(this.gameObject);
        }/*
        if(target.GetComponent<Monster_old>().isChase==false) {
            Destroy(this.gameObject);
            print("삭제");
        }
        */
    }

    public void DestroyBullet(){
        try {
            towerScript.ReturnObject(this.gameObject);
            print("리턴");
        }
        catch (System.NullReferenceException ex) {
            Destroy(this.gameObject);
        }
        
    }

}