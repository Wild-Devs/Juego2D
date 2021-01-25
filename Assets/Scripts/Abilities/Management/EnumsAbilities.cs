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

    public enum PosicionesEquipo {
        cabeza,
        torso,
        brazos,
        piernas
    }

    public enum Equipables {
        Tronco,
        ArmaduraHierro
    }

    public static string[] equipablesCabeza = { "Ejemplo" };
    public static string[] equipablesTorso = {"Tronco", "ArmaduraHierro"};
    public static string[] equipablesBrazos = { "Ejemplo" };
    public static string[] equipablesPiernas = { "Ejemplo" };
    public static string[] nombresSpritesItems = { "TroncoSpriteItem", "ArmaduraHierroSpriteItem" };
}
