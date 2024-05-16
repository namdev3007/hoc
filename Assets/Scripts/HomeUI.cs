using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HomeUI : MonoBehaviour
{
    private CoinsManager coinsManager;
    private HealthManager healthManager;

    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI livesText;

<<<<<<< HEAD
    [Header("Shop UI")]
    public GameObject shopUI;
    public GameObject wheelUI;
    public GameObject gitfUI;

=======
>>>>>>> f2069d3f76518f4d4adbbc6ac554bec9a59f2b8d
    private void Awake()
    {
        coinsManager = Object.FindFirstObjectByType<CoinsManager>();
        healthManager = Object.FindFirstObjectByType<HealthManager>();
    }

    private void Update()
    {
        UpdateCoins();
        UpdateLives();
    }

    private void UpdateCoins()
    {
        coinsText.text = coinsManager.coinCount.ToString();
    }

    private void UpdateLives()
    {
        livesText.text = healthManager.lives.ToString();
    }
<<<<<<< HEAD

    public void TurnOnShop()
    {
        shopUI.SetActive(true);
    }

    public void TurnOffShop()
    {
        shopUI.SetActive(false);
    } 
    public void TurnOnGift()
    {
        gitfUI.SetActive(true);
    }
    public void TurnOnWheel()
    {
        wheelUI.SetActive(true);
    }
=======
>>>>>>> f2069d3f76518f4d4adbbc6ac554bec9a59f2b8d
}
