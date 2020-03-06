﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretActivator : MonoBehaviour
{   
   
    public LayerMask layermask;
    public float speed = 10f;
    public Rigidbody RB;
    public GameObject TurretPrefab;
    


    // Start is called before the first frame update
    void Start()
    {
        
        RB.AddForce(transform.forward * speed, ForceMode.Impulse);
        Destroy(gameObject, 3f);
    }

    public void Die()
    {
        
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
      
        Debug.Log(collision.gameObject.name);
        if (layermask == (layermask | (1 << collision.gameObject.layer)))
        {//if the ball collides with ground then the turret is created
         // INSTANTIATE IN THE POINT OF COLLISION!!that's why we need to check collisions and not just Triggers. We parent the gameobject to the parent of the ball in order to recieve broadcasted future messages
            Instantiate(TurretPrefab, collision.contacts[0].point, Quaternion.identity,transform.parent);
            Die();
           
        }
        else
        { //the ball touches any other layer 
            GetComponent<Animator>().SetTrigger("Failure");
        }
        RB.Sleep();//avoid more interactions
    }
}
