using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
    public int maxHealth, curHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (curHealth < 0) {
            gameOver();
        }
    }

    void gameOver()
    {

    }
}
