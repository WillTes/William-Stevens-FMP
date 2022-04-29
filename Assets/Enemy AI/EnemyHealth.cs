using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    public float Ehealth;
    public float maxEHealth;
    public GameObject explosionPrefab;
    public GameObject healthBarUI;
    public Slider slider;
    public GameObject enemy;

    private void Start()
    {
        Ehealth = maxEHealth;
        slider.value = calculateEHealth();

    }


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            TakeDamage(20);
            Debug.Log("Enemy Collision Detected");
        }
        
        if (collision.gameObject.tag == "Bullet 2")
        {
            Destroy(collision.gameObject);
            TakeDamage(40);
            Debug.Log("Enemy Collision Detected");
        }

        if (collision.gameObject.tag == "Bullet 3")
        {
            Destroy(collision.gameObject);
            TakeDamage(50);
            Debug.Log("Enemy Collision Detected");
        }
    }

        void TakeDamage(int damage)
    {
        Ehealth -= damage;
    }

    private void Update()
    {
        slider.value = calculateEHealth();
        if (Ehealth < maxEHealth)
        {
            healthBarUI.SetActive(true);
        }
        if (Ehealth <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Enemy Is Dead");
            Explosion();
            Vector3 oldPos = transform.position;
            Vector2 oldrotation = transform.position;
            Instantiate(enemy, oldPos, Quaternion.identity);


        }
        if (Ehealth > maxEHealth)
        {
            Ehealth = maxEHealth;
        }
    }
    float calculateEHealth()
    {
        return Ehealth / maxEHealth;
    }

    void Explosion()
    {

        Instantiate(explosionPrefab, transform.position, transform.rotation);
    }


}