using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_bullet : MonoBehaviour
{
    public float damage;
    public float bullet_speed;
    public float range;
    public int attack_type;
    public GameObject monster;
    Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * bullet_speed * Time.deltaTime);
    }
    public void fire(Vector3 dir)
    {
        direction = new Vector3(dir.x, 0, dir.z);
        Destroy(gameObject, range);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (monster.GetComponentInParent<Monster_old>().target != null)
        {
            if (other.gameObject.CompareTag(monster.GetComponentInParent<Monster_old>().target.gameObject.tag))
            {
                if (other.gameObject.CompareTag("Player"))
                {
                    Debug.Log("플레이어 어택 됨");
                    monster.GetComponentInParent<Monster_old>().AttackOn();
                    Destroy(gameObject);
                }
                if (other.gameObject.CompareTag("TowerAttack"))
                {
                    Debug.Log("타워 어택 됨");
                    monster.GetComponentInParent<Monster_old>().AttackOn();
                    Destroy(gameObject);
                }
                if (other.gameObject.CompareTag("base"))
                {
                    Debug.Log("베이스 어택 됨");
                    monster.GetComponentInParent<Monster_old>().AttackOn();
                    Destroy(gameObject);
                }
            }
        }
    }
}
