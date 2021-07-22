using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    [Header("Attributes")]
    public float startSpeed = 10f; // enemy start speed
    public float MaxHP = 100; // Max Hp of the enemy
    public float HP = 100; // health of the enemy
    public int MGain = 50; // gold gain when enemy is destroyed
    [HideInInspector] // hidden in inspector
    public float speed; // speed of the enemy after its modified

    public GameObject HP_Canvas;
    public Slider slider;


    void Start()
    {
        speed = startSpeed;

        slider.value = CalculateHealth();
    }


    public void DamageTaken(float amount) // damage to enemy is takes the damage amount from health amount
    {
        HP -= amount;

        slider.value = CalculateHealth();

        if (HP <= 0)
        {
            Kill(); // when enemies health is 0 it executes kill method
        }
    }
    public void Slow(float amount)
    {
        speed = startSpeed * (1f - amount);
    }

    void Kill() // kill method destroys the enemy and gild gold to the player
    {

        Currency.Gold += MGain;

        WaveSpawner.EnemiesLeft--;
        Destroy(gameObject);
    }

    float CalculateHealth()
    {
        return HP / MaxHP;
    }

}
