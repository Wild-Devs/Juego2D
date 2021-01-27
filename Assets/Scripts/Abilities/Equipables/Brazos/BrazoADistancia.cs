using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrazoADistancia : Brazo
{
    public GameObject proyectil;
    private float nextFireTime;

    void Start()
    {
        nextFireTime = 0f;

    }

    void Update()
    {
        SeguirAlRaton();
        if (Time.time >= nextFireTime && ControlarBotones())
        {
            accion();
            nextFireTime = cooldown + Time.time;
        }
    }

    public override void accion()
    {
        Instantiate(proyectil, this.gameObject.transform.position, this.gameObject.transform.rotation);
        Debug.Log("Dispara");
    }
}
