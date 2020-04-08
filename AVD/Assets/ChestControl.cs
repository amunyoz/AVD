using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[RequireComponent(typeof(PlayableDirector))]
[RequireComponent(typeof(Collider))]
public class ChestControl : MonoBehaviour
{
    // Start is called before the first frame update
    
    public void Play()
    {
 //we play the director of the chest to orbit and open the treasure
            GetComponent<PlayableDirector>().Play();
   
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
             Play();
        }
    }
}
