using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealthUI : MonoBehaviour
{
    public TMP_Text healthText;//declaring a TMP text variable
      
    void Update()
    {
        //assigning and converting the health int to string to the TMP Text UI object
        healthText.text = GameManager.Gamemanager.playerHealth.Health.ToString();
    }
}
