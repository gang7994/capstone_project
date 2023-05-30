using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
    public int maxHealth, curHealth;

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
