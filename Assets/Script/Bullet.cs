using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    void Start(){
        //Invoke("DestroyBullet", 1);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Map")
            DestroyBullet();
        else if (collision.gameObject.tag == "Monster")
            DestroyBullet();
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Map")
            DestroyBullet();
        else if (other.gameObject.tag == "Monster")
            DestroyBullet();
    }

    void Update()
    {
        transform.Translate(Vector3.forward * 1.0f);
    }

    void DestroyBullet(){
        Destroy(gameObject);
    }
}
