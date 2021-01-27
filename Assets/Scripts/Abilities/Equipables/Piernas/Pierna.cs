using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pierna : HabilidadesConAccion
{
    public bool isDerecha;

    public bool ControlarBotonesAcciones()
    {
        if (!isDerecha)
        {
            return Input.GetButton("AccionBrazoIzquierdo");
        }
        else
        {
            return Input.GetButton("AccionBrazoDerecho");
        }
    }

    //public bool ControlarSiCamina() {}
}
