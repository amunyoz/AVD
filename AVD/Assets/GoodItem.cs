using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodItem : MonoBehaviour
{

    public void PickItem() {

        GetComponent<Animator>().SetTrigger("Pick");

    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) PickItem();
    }
}
