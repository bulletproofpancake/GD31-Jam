using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float currentHeath;
    public float maxHealth =100;

    public HealthBar healthbar;

    // Start is called before the first frame update
    void Start()
    {
        currentHeath = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHeath <= 0)
        {
            Destroy(gameObject);
            GameManager.instance.bossDead = true;
        }
    }

    public void TakeDamage(float damage)
    {
        currentHeath -= damage;
        Debug.Log("dmg taken " + damage);
        healthbar.SetHealh(currentHeath);
    }
}
