using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit_judgement
{
    void Update()
    {
     void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.name == "goal point")
            {
                Console.Write("Game clear!");
            }
        }

    }
    
}
