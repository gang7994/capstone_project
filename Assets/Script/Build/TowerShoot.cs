using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TowerShoot : MonoBehaviour
{
    float timer;

    public float coolTime = 0.5f;
    public Material[] mat = new Material[5]; 

    public Material[] ranShoot = new Material[5];
   
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Monster")
        {
            DestroyBullet();
        }
    }

    void Update(){
        timer += Time.deltaTime;
        
        
        transform.Translate(Vector3.forward * 0.1f);
    }

    void DestroyBullet(){
        Destroy(gameObject);
    }

    
    
}