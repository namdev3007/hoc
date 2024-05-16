using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static Cinemachine.DocumentationSortingAttribute;

public class HealthManager : MonoBehaviour
{
    public int startingLives = 1;
    public int lives = 1;
    public int health = 3;



    public void Start()
    {
        if (!PlayerPrefs.HasKey("Lives"))
        {
            lives = startingLives;
            SaveLives();
        }
        else
        {
            lives = PlayerPrefs.GetInt("Lives");
        }
    }

    public void SaveLives()
    {
        PlayerPrefs.SetInt("Lives", lives);
        PlayerPrefs.Save();
    }
}
