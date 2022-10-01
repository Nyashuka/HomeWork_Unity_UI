using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private Text _healthText;

    [SerializeField] private Health _orkHeath;

    [SerializeField] private GameObject _deathScreen;

    private void Start()
    {
        _healthSlider.maxValue = _orkHeath.MAX_HEALTH_VALUE;
        _healthSlider.minValue = _orkHeath.MIN_HEALTH_VALUE;
        _healthSlider.value = _orkHeath.Currenthealth;

        _healthText.text = _orkHeath.Currenthealth == _orkHeath.MAX_HEALTH_VALUE ? "MAX" : _orkHeath.Currenthealth.ToString();

        _orkHeath.HealthChangeEvent += UpdateHealthUI;
        _orkHeath.DeathEvent += ShowDeathScreen;
    }

    private void UpdateHealthUI(HealthData healthData)
    {
        _healthSlider.value = healthData.newHealth;

        if (healthData.newHealth == _orkHeath.MAX_HEALTH_VALUE)
        {
            _healthText.text = "MAX";
            return;
        }

        _healthText.text = healthData.newHealth.ToString(); 
    }


    private void ShowDeathScreen()
    {
        _deathScreen.SetActive(true);
    }

}

