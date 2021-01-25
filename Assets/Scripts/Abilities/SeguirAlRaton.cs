using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirAlRaton : MonoBehaviour {
    public bool isFacingDerecha;

    void Update() {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();

        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        float rotation = Mathf.Abs(rotationZ);

        Debug.Log(rotation);
        if (isFacingDerecha && rotation < 90) {
            transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
        }
        if (!isFacingDerecha && rotation > 90) {
            transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
        }
    }
}
