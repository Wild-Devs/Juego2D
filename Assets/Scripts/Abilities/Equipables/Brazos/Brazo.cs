using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Brazo : HabilidadesConAccion {
    public bool isFacingDerecha;
    public float dmg;

    public void SeguirAlRaton() {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.gameObject.transform.position;
        difference.Normalize();

        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        float rotation = Mathf.Abs(rotationZ);

        if (isFacingDerecha && rotation < 90) {
            this.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
        }
        if (!isFacingDerecha && rotation > 90) {
            this.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
        }
    }

    public bool ControlarBotones() {
        if (!isFacingDerecha) {
            return Input.GetButton("AccionBrazoIzquierdo");
        } else {
            return Input.GetButton("AccionBrazoDerecho");
        }
    }
}
