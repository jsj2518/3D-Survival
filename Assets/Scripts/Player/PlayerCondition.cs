using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IDamagable
{
    void TakePhysicalDamage(float damage);
}

public class PlayerCondition : MonoBehaviour, IDamagable
{
    public UICondition uiCondition;

    private Condition health { get { return uiCondition.health; } }
    private Condition hunger { get { return uiCondition.hunger; } }
    private Condition stamina { get { return uiCondition.stamina; } }

    public float noHungerHealthDecay;

    public event Action OnTakeDamage;

    private void Update()
    {
        hunger.Add(hunger.passiveValue * Time.deltaTime);
        stamina.Add(stamina.passiveValue * Time.deltaTime);

        if (hunger.curValue <= 0f)
        {
            health.Subtract(noHungerHealthDecay * Time.deltaTime);
        }

        if (health.curValue <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("You Died");
    }


    public void Heal(float amount)
    {
        health.Add(amount);
    }

    public void Eat(float amount)
    {
        hunger.Add(amount);
    }

    public void TakePhysicalDamage(float damage)
    {
        health.Subtract(damage);
        OnTakeDamage?.Invoke();
    }

    public bool UseStamina(float amount)
    {
        if (stamina.curValue - amount < 0f)
        {
            return false;
        }

        stamina.Subtract(amount);
        return true;
    }
}
