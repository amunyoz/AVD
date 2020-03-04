using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullets3d : MonoBehaviour
{
    // Start is called before the first frame update
    public float frequency = 1f;
    public GameObject Bullet3d;
    public Transform[] BulletPositions;
    public Animator[] GunsAnimators;
    void Start()
    {
        StartCoroutine(Fire());
    }
    private int i=0;
    IEnumerator   Fire()
    {
        GunsAnimators[i].SetTrigger("Fire");

        Instantiate(Bullet3d, BulletPositions[i].position, BulletPositions[i].rotation);
        i++;
        if (i >= BulletPositions.Length) i = 0;
        yield return new WaitForSeconds(frequency);
            
        StartCoroutine(Fire());
    }
    private void OnDisable()
    {
        StopAllCoroutines();
    }

}
