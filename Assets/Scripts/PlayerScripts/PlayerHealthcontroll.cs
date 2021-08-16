using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthcontroll : MonoBehaviour
{
    public static PlayerHealthcontroll instance;
    public int maxHealth, currentHealth;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        UIController.instance.healthSlider.maxValue = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void DamagePlayer(int damageCount)
    {
        currentHealth -= damageCount;
        if (currentHealth <= 0)
        {
            // gameObject.SetActive(false);
            SceneManager.LoadScene(1);
        }
        UIController.instance.healthSlider.value = currentHealth;
        UIController.instance.healthText.text = "Health: " + currentHealth.ToString();
    }


}