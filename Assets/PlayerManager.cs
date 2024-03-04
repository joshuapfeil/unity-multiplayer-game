using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IGameManager
{
    public ManagerStatus status { get; private set; }

    public int health { get; private set; }
    [SerializeField] private int maxHealth;

    [SerializeField] private TMP_Text victoryText;

    [SerializeField] public TMP_Text healthText;

    public string playerName;


    public void Startup()
    {
        
        Debug.Log("Player manager starting...");
        health = maxHealth;
        healthText.text = playerName + " Health: " + health;
        status = ManagerStatus.Started;
        
    }

    public void ChangeHealth(int value)
    {
        health += value;
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        else if (health < 0)
        {
            health = 0;
        }

        healthText.text = playerName + " Health: " + health;
        
        if (health == 0)
        {
            if (playerName == "White")
            {
                victoryText.text = "Blue Wins! Blue had" + Managers.BlueInventory.GetItemCount("item") + " items!";
            }
            else
            {
                victoryText.text = "White Wins! White had" + Managers.WhiteInventory.GetItemCount("item") + " items!";
            }
            
        }
    }
}