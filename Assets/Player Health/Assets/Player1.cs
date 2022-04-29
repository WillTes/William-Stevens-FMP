using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{

	public int maxHealth = 100;
	public int currentHealth = 100;

	public HealthBar healthBar;

	// Start is called before the first frame update
	void Start()
	{
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
	}

	void Update()
	{
		if (currentHealth < 0)
		{
			Destroy(gameObject);
			Debug.Log("Dead");
		}
	}

	private void OnCollisionEnter(Collision collision)
	{

		if (collision.gameObject.tag == "Bullet")
		{
			Destroy(collision.gameObject);
			TakeDamage(20);
			Debug.Log("Collision Detected");
		}

		if (collision.gameObject.tag == "Bullet 2")
		{
			Destroy(collision.gameObject);
			TakeDamage(40);
			Debug.Log("Collision Detected");
		}

		if (collision.gameObject.tag == "Bullet 3")
		{
			Destroy(collision.gameObject);
			TakeDamage(50);
			Debug.Log("Collision Detected");
		}

	}

	void TakeDamage(int damage)
	{
		currentHealth -= damage;

		healthBar.SetHealth(currentHealth);
	}
}

