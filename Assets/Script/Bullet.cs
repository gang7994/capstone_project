using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    float stack;
    Vector3 direction;
    public float speed;
    bool isFire;
    void Start(){
        //Invoke("DestroyBullet", 1);
        stack = 1.0f;
        transform.position += new Vector3(0, 0.5f, 0);
    }
    public void fire(Vector3 dir,bool gun)
    {
        direction = new Vector3(dir.x, 0, dir.z);
        isFire = true;
        if (gun)
        {
            Destroy(gameObject, 5f);
        }
        else
        {
            Destroy(gameObject, 1f);
        }
        
    }

 


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Monster")
        {
            
            Destroy(other.gameObject);
            DestroyBullet();

        }
    }

    void Update()
    {
        if (isFire)
        {
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    void DestroyBullet(){
        Destroy(gameObject);
    }
}
