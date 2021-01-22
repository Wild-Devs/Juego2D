using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumsAbilities : MonoBehaviour {
    public enum SlotsInventory {
        cabeza,
        torso,
        brazoIzquierdo,
        brazoDerecho,
        piernaIzquierda,
        piernaDerecha
    }

    public enum Equipables {
        Tronco
    }

    public static string[] equipablesCabeza = { "Ejemplo" };
    public static string[] equipablesTorso = {"Tronco"};
    public static string[] equipablesBrazos = { "Ejemplo" };
    public static string[] equipablesPiernas = { "Ejemplo" };
}
