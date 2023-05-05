using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        if (collision.CompareTag("MonsterAttack"))
        {

            /**DestroyBullet();**/
        }
    }

    void Update(){
        Vector3 direction = target.transform.position - transform.position; 
        transform.Translate(direction.normalized * 10f * Time.deltaTime, Space.World);
    }

    public void DestroyBullet(){
        try {
            towerScript.ReturnObject(this.gameObject);
        }
        catch (System.NullReferenceException ex) {
            Destroy(this.gameObject);
        }
        
    }

}