using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public enum DamageType
    {
        Armor,
        Normal
    }
    public static HealthManager Instance { get; set; }
    [HideInInspector] public int health;
    [HideInInspector] public int armor;
    [HideInInspector] public bool dead;

    // Start is called before the first frame update
    void Awake()
    {
        health = 100;
        armor = 100;
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int amount, DamageType type)
    {
        switch (type)
        {
            case DamageType.Armor:
            {
                armor -= amount;
                if (armor < 0)
                {
                    health += armor;
                    armor = 0;
                }
                break;
            }
            case DamageType.Normal:
            {
                health -= amount;
                break;
            }
        }
        if (health > 0) return;
        dead = true;
        health = 0;
    }

    public void Heal(int amount, DamageType type)
    {
        switch (type)
        {
            case DamageType.Armor:
            {
                armor += amount;
                if (armor >= 100) armor = 100;
                break;
            }
            case DamageType.Normal:
            {
                health += amount;
                if (health >= 100) health = 100;
                break;
            }
        }
    }
}
