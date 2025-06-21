using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class hit_judgement : MonoBehaviour
{
    private Vector3 initialPosition;
    private Vector3 currentPosition;
    private Vector3 initialRot;

    void Start()
    {
        initialPosition = transform.position;
        initialRot = transform.eulerAngles;



    }
    void Update()
    {
    }
    void OnCollisionEnter(Collision collision)
    {
        string layername = LayerMask.LayerToName(collision.gameObject.layer);
        {
            switch (layername)
            {
                case "goal point":
                    Debug.Log("Game clear!");
                    StartCoroutine(ResetAfterDelay(3f));
                    break;

                case "sponge":
                    Debug.Log("Game over...");
                    StartCoroutine(ResetAfterDelay(3f));
                    break;

                case "secret":
                    Debug.Log("Excellent!!");
                    StartCoroutine(ResetAfterDelay(3f));
                    break;
            }
        }
    }


        private IEnumerator ResetAfterDelay(float delay)
        {

        yield return new WaitForSeconds(delay);

        ResetPositionImmediately();
        }

        private void ResetPositionImmediately()
        { 
             transform.position = initialPosition;

             transform.eulerAngles = initialRot;
        }

             
        

    

}