using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShoot : MonoBehaviour
{
    

   
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Monster")
        {
            DestroyBullet();
            print("tlqkf");
        }
    }

    void Update(){
        transform.Translate(Vector3.forward * 0.05f);
    }

    void DestroyBullet(){
        Destroy(gameObject);
        Debug.Log("총알파괴");
    }
}
