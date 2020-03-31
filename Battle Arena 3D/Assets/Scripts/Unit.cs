using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour{

    [SerializeField] private string unitName;
    [SerializeField] private UnitType unitType;
    [SerializeField] private float maxHealth;
    [SerializeField] private float health;
    [SerializeField] private int level; 

    public string GetUnitName()
    {
        return unitName;
    }

    public UnitType GetUnitType()
    {
        return unitType;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }

    public float GetHealth()
    {
        return health;
    }

    public int GetLevel()
    {
        return level;
    }

    public abstract void Attack();

}

public enum UnitType
{
    tank,
    range,
    wizard,
    monster
}
