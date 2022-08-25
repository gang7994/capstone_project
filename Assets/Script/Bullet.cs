using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Start(){
        Invoke("DestroyBullet", 1);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * 1f);
    }

    void DestroyBullet(){
        Destroy(gameObject);
    }
}