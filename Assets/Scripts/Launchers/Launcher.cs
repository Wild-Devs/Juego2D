using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{

    public GameObject arrow;
    public float cooldownTime;
    private float nextFireTime;
    public Animator animator;
    
    void Start()
    {
        nextFireTime = 0f;
    }

    
    void Update()
    {
        if(Time.time >= nextFireTime){

            animator.Play("launcher");

            Object.Instantiate(arrow, this.gameObject.transform.position, Quaternion.identity);

            nextFireTime += cooldownTime;
        }
    }
}
