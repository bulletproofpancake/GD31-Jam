using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemies;

    public int damage;

    public HealthBar healthbar;
    public float maxHealth = 100f;
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    private void FixedUpdate()
    {

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            GameManager.instance.playerDead = true;
        }
        
        if(timeBtwAttack <= 0)
        {
            if(Input.GetKey(KeyCode.Z))
            {
                FindObjectOfType<Audio>().Play("melee");
                Collider[] enemiesToDamage = Physics.OverlapSphere(attackPos.position, attackRange, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
                }
            }
            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
    
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log("dmg taken " + damage);
        healthbar.SetHealh(currentHealth);
    }

}
