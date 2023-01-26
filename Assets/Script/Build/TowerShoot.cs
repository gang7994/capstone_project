using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShoot : MonoBehaviour
{
    public Material[] mat = new Material[5]; 
   
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

    public void selectFire(){
        gameObject.GetComponent<TrailRenderer>().material = mat[0];
    }

    public void selectIce(){
        gameObject.GetComponent<TrailRenderer>().material = mat[1];
    }
    public void selectEarth(){
        gameObject.GetComponent<TrailRenderer>().material = mat[2];
    }
    public void selectPoison(){
        gameObject.GetComponent<TrailRenderer>().material = mat[3];
    }
    public void selectLightning(){
        gameObject.GetComponent<TrailRenderer>().material = mat[4];
    }
    
}
