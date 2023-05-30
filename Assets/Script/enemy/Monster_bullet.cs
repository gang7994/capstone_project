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
        if(attack_type == 2 || attack_type == 1)
        {
            transform.Translate(0, 1, 0);
        }

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
        if (attack_type == 1)
        {
            if (monster != null)
            {
                if (other.gameObject.CompareTag("Player"))
                {
                    other.GetComponent<Player>().boss_slow_on = true;
                    Destroy(gameObject);
                }
            }
        }else if (attack_type == 2)
        {
            if (monster != null)
            {
                if (monster.GetComponentInParent<Monster_old>().target != null)
                {
                    if (other.gameObject.CompareTag(monster.GetComponentInParent<Monster_old>().target.gameObject.tag))
                    {
                        if (other.gameObject.CompareTag("Player"))
                        {
                            monster.GetComponentInParent<Monster_old>().AttackOn();
                            Destroy(gameObject);
                        }
                    }
                }
            }
        }
        else
        {
            if (monster != null)
            {
                if (monster.GetComponentInParent<Monster_old>().target != null)
                {
                    if (other.gameObject.CompareTag(monster.GetComponentInParent<Monster_old>().target.gameObject.tag))
                    {
                        if (other.gameObject.CompareTag("Player"))
                        {
                            monster.GetComponentInParent<Monster_old>().AttackOn();
                            Destroy(gameObject);
                        }
                        if (other.gameObject.CompareTag("TowerAttack"))
                        {
                            monster.GetComponentInParent<Monster_old>().AttackOn();
                            Destroy(gameObject);
                        }
                        if (other.gameObject.CompareTag("FenceAttack"))
                        {
                            monster.GetComponentInParent<Monster_old>().AttackOn();
                            Destroy(gameObject);
                        }
                        if (other.gameObject.CompareTag("base"))
                        {
                            monster.GetComponentInParent<Monster_old>().AttackOn();
                            Destroy(gameObject);
                        }
                    }
                }
            }
        }
        
    }
}
