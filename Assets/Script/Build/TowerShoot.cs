using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TowerShoot : MonoBehaviour
{
    float timer;
    public GameObject target;


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

        Vector3 direction = target.transform.position - transform.position; //tower.cs���� �Ѿ�� Ÿ�� ���� �� ��ġ���� ���
        transform.Translate(direction.normalized * 10f * Time.deltaTime, Space.World); //������Ʈ�� ���� �̵��ϴ� ���� ��ġ�� �ǽð����� ����
    }

    void DestroyBullet(){
        Destroy(gameObject, 1f*Time.deltaTime);
    }

    
    
}