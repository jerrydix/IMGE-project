using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class HealthManager : MonoBehaviour
{
    public enum DamageType
    {
        Armor,
        Normal
    }
    //public static HealthManager Instance { get; set; }
    [HideInInspector] public int health;
    [HideInInspector] public int armor;
    [HideInInspector] public bool dead;

    [SerializeField] private Slider healthSlider;
    [SerializeField] private Slider armorSlider;

    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip[] hurtSounds;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        armor = 100;
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = health;
        armorSlider.value = armor;
    }

    public void Damage(int amount, DamageType type)
    {
        if (health > 0)
        {
            source.PlayOneShot(hurtSounds[Random.Range(0, hurtSounds.Length)]);
        }
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
