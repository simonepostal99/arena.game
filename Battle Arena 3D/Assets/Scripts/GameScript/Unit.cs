using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour{

    //Attributi generici per ogni unità
    [SerializeField] private string unitName;
    [SerializeField] private float level;
    [SerializeField] private float maxHealth, currentHealth;
    [SerializeField] private float speedMovement;
    [SerializeField] private float basicDamage, attackRange;
    [SerializeField] private Object dress;
    [SerializeField] private Object weapon;
    [SerializeField] private UnitType unitType;
    //Se 1=destra se 2=sinistra
    [SerializeField] private int team;

    //get set unitName
    public string getUnitName()
    {
        return unitName;
    }
    public void setUnitName(string unitName)
    {
        this.unitName = unitName;
    }

    //get set level
    public float getLevel()
    {
        return level;
    }
    public void setLevel(float level)
    {
        this.level = level;
    }

    //get set maxHealth
    public float getMaxHealth()
    {
        return maxHealth;
    }
    public void setMaxHealth(float maxHealth)
    {
        this.maxHealth = maxHealth;
    }

    //get set currentHealth
    public float getCurrentHealth()
    {
        return currentHealth;
    }
    public void setHealth(float currentHealth)
    {
        this.currentHealth = currentHealth;
    }

    //get set speedMovement
    public float getSpeedMovement()
    {
        return speedMovement;
    }
    public void setSpeedMovement(float speedMovement)
    {
        this.speedMovement = speedMovement;
    }

    //get set attackDamage
    public float getAttackRange()
    {
        return attackRange;
    }
    public void setAttackRange(float attackRange)
    {
        this.attackRange = attackRange;
    }

    //get set basicDamage
    public float getBasicDamage()
    {
        return basicDamage;
    }
    public void setBasicDamage(float basicDamage)
    {
        this.basicDamage = basicDamage;
    }

    //get set dress
    public Object getDress()
    {
        return dress;
    }
    public void setDress(Object dress)
    {
        this.dress = dress;
    }

    //get set weapon
    public Object getWeapon()
    {
        return weapon;
    }
    public void setWeapon(Object weapon)
    {
        this.weapon = weapon;
    }

    //get set unitType
    public UnitType getUnitType()
    {
        return unitType;
    }

    //get team
    public int getTeam()
    {
        return team;
    }

}

public enum UnitType
{
    gladiator,
    archer,
    witch,
    monster
}


