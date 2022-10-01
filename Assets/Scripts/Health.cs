using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct HealthData
{
    public int oldHealth;
    public int newHealth;

    public HealthData(int oldHealth, int newHealth)
    {
        this.oldHealth = oldHealth;
        this.newHealth = newHealth;
    }
}

public class Health : MonoBehaviour
{
    public readonly int MAX_HEALTH_VALUE = 100;
    public readonly int MIN_HEALTH_VALUE = 0;

    private int _currentHealth;

    public int Currenthealth => _currentHealth;

    public event Action<HealthData> HealthChangeEvent;
    public event Action DeathEvent;

    public void Awake()
    {
        _currentHealth = MAX_HEALTH_VALUE;
    }

    public void DecreaseHealth(int points)
    {
        if (_currentHealth == MIN_HEALTH_VALUE)
            return;

        int oldHealthValue = _currentHealth;
        _currentHealth -= points;

        HealthData healthData = new HealthData(oldHealthValue, _currentHealth);

        if (_currentHealth <= MIN_HEALTH_VALUE)
        {
            _currentHealth = MIN_HEALTH_VALUE;
            healthData.newHealth = MIN_HEALTH_VALUE;
            DeathEvent?.Invoke();
        }

        HealthChangeEvent?.Invoke(healthData);

    }

    public void IncreaseHealth(int points)
    {
        if (_currentHealth == MAX_HEALTH_VALUE)
            return;

        int oldHealthValue = _currentHealth;
        _currentHealth += points;

        HealthData healthData = new HealthData(oldHealthValue, _currentHealth);

        if (_currentHealth >= MAX_HEALTH_VALUE)
        {
            _currentHealth = MAX_HEALTH_VALUE;

            healthData.newHealth = MAX_HEALTH_VALUE;
        }

        HealthChangeEvent?.Invoke(healthData);
    }
}
