using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private int hitPoints = 2;
    [SerializeField] private bool isDestroyed = false;
    [SerializeField] private int currencyWorth = 50;
    public void TakeDamage(int damage)
    {
        hitPoints -= damage;
        if (hitPoints <= 0 && !isDestroyed)
        {
            EnemySpawner.onEnemyDestroy.Invoke();
            LevelManager.main.IncreaseCurrency(currencyWorth);  
            isDestroyed = true;
            Destroy(gameObject);
        }
    }
}
