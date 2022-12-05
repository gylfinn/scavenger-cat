using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField]private PlayerHealth playerHealth;
    [SerializeField]private Image totalHealthBar;
    [SerializeField]private Image currentHealthBar;
    void Start()
    {
        totalHealthBar.fillAmount = playerHealth.currentHealth / 10;
    }
    void Update()
    {
        currentHealthBar.fillAmount = playerHealth.currentHealth / 10;
    }
}
