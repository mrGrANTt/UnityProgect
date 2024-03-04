using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
public class Health : MonoBehaviour
{
    public GameObject deathScreen;
    //Значение здоровья
    public int health;
    //Максимальное значение здоровья
    public int maxHealth;
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite empyteHeart;
    public bool isInvincible = false;
    public float invincibilityDuration = 2f;
    private float invincibilityTimer = 0f;
    //Функция получения урона
    public void TakeHit(int damage)
    {
        if (!isInvincible)
        {
            health -= damage;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                StartCoroutine(Invincibility());
            }
        }
    }
    private IEnumerator Invincibility()
    {
        isInvincible = true;
        invincibilityTimer = invincibilityDuration;

        while (invincibilityTimer > 0)
        {
            // Toggle the visibility of the character here (e.g., change sprite or apply transparency)
            yield return new WaitForSeconds(0.1f); // Adjust the interval to your preference
            invincibilityTimer -= 0.1f; // Decrease the timer
        }

        // Reset the character's visibility and invincibility flag
        isInvincible = false;

        // Add any additional logic after the invincibility period ends
    }

    //Функция прибавления здоровья
    public void SetHealth(int bonusHealth)
    {
        health += bonusHealth;

        //Если здоровье, после пополнения, больше максимального значения - здоровье будет равно максимальному значению.
        if (health > maxHealth)
        {
            health = maxHealth;
        }            
    }
    private void FixedUpdate()
    {
        if(health > numOfHearts)
        {
            health = numOfHearts;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < Mathf.RoundToInt(health))
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = empyteHeart;
            }
            if(i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
            if(health <= 1)
            {
                if (!deathScreen.activeSelf)
                {
                    deathScreen.SetActive(true);
                    GetComponent<go>().speed = 0;
                }
            }
        }
    }

    internal void TakeDamage(float damageAmount)
    {
        throw new NotImplementedException();
    }
    public float speed = 5f;
    public float repelForce = 10f;

    private void Update()
    {
        // Управление персонажем
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, vertical, 0f) * speed * Time.deltaTime;
        transform.Translate(movement);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // Проверка на столкновение с шипом
        if (collision.gameObject.CompareTag("Spike"))
        {
            RepelFromSpike(collision.transform.position);
        }
    }

    private void RepelFromSpike(Vector2 spikePosition)
    {
        // Отталкивание от шипа
        Vector2 repelDirection = (transform.position - (Vector3)spikePosition).normalized;
        transform.position = (Vector2)transform.position + repelDirection * repelForce * Time.deltaTime;
    }

}