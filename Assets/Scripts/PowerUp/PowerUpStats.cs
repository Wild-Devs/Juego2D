using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpStats : MonoBehaviour
{

    public float attack;
    public int deffense;
    public float maxHealth;
    public float health;
    public float speed;

    public float getAttack() {

        return attack;

    }

    public float getMaxHealth() {

        return maxHealth;    

    }

    public float getHealth() {

        return health;

    }

    public float getSpeed() {

        return speed;    

    }

    public int getDeffense() {

        return deffense;

    }


}
