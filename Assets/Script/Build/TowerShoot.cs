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
        Debug.Log("총알파괴");
    }

    public void selectFire(){
        int n = GameObject.Find("tower").GetComponent<Tower>().num_of_inchant;
        if(n<=4){
            ranShoot[n] = mat[0];
            GameObject.Find("tower").GetComponent<Tower>().num_of_inchant += 1;
        }
       // gameObject.GetComponent<TrailRenderer>().material = mat[0];

    }

    public void selectIce(){
        int n = GameObject.Find("tower").GetComponent<Tower>().num_of_inchant;
        if(n<=4){
            ranShoot[n] = mat[2];
            GameObject.Find("tower").GetComponent<Tower>().num_of_inchant += 1;
        }
       // gameObject.GetComponent<TrailRenderer>().material = mat[2];
    }
    public void selectEarth(){
        int n = GameObject.Find("tower").GetComponent<Tower>().num_of_inchant;
        if(n<=4){
            ranShoot[n] = mat[1];
            GameObject.Find("tower").GetComponent<Tower>().num_of_inchant += 1;
        }
      //  gameObject.GetComponent<TrailRenderer>().material = mat[1];
    }
    public void selectPoison(){
        int n = GameObject.Find("tower").GetComponent<Tower>().num_of_inchant;
        if(n<=4){
            ranShoot[n] = mat[4];
            GameObject.Find("tower").GetComponent<Tower>().num_of_inchant += 1;
        }
      //  gameObject.GetComponent<TrailRenderer>().material = mat[4];
    }
    public void selectLightning(){
        int n = GameObject.Find("tower").GetComponent<Tower>().num_of_inchant;
        if(n<=4){
            ranShoot[n] = mat[3];
            GameObject.Find("tower").GetComponent<Tower>().num_of_inchant += 1;
        }
      //  gameObject.GetComponent<TrailRenderer>().material = mat[3];
    }
    
}