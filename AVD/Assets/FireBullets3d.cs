using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullets3d : MonoBehaviour
{
    // Start is called before the first frame update
    public float frequency = 1f;
    public float TimeToDie = 3f;
    public GameObject Bullet3d;
    public Transform[] BulletPositions;
    public Animator[] GunsAnimators;
    public Animator MainTurretAnimator;
    void Start()
    {

        StartCoroutine(Disappear());
        StartCoroutine(Fire());

    }
    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(TimeToDie);
        MainTurretAnimator.SetTrigger("die");
        yield return null;
    }
    public void KillTurret()
    {
        StopAllCoroutines();
        MainTurretAnimator.SetTrigger("die");
    }
    public void Die()
    {
        Destroy(gameObject);
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
