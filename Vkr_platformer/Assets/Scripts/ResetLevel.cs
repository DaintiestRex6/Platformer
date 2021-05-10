using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResetLevel : MonoBehaviour
{
    public Player player;
    public Text coinText;
    public Image[] hearts;
    public Sprite isLife, nonLife;
    public GameObject PauseScreen;
    public GameObject WinScreen;
    public GameObject LoseScreen;
    public void ReloadLvl()
    {
        Time.timeScale = 1f;
        player.enabled = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Update()
    {
        coinText.text = player.GetCoins().ToString();
        for(int i = 0; i < hearts.Length; i++)
        {
            if (player.GetHearts() > i)
                hearts[i].sprite = isLife;
            else
                hearts[i].sprite = nonLife;
        }
    }
    public void PauseOn()
    {
        Time.timeScale = 0f;
        player.enabled = false;
        PauseScreen.SetActive(true);
    }
    public void PauseOff()
    {
        Time.timeScale = 1f;
        player.enabled = true;
        PauseScreen.SetActive(false);
    }
    public void Win()
    {
        Time.timeScale = 0f;
        player.enabled = false;
        WinScreen.SetActive(true);
    }
    public void Lose()
    {
        Time.timeScale = 0f;
        player.enabled = false;
        LoseScreen.SetActive(true);
    }
    public void MenuLvl()
    {
        Time.timeScale = 1f;
        player.enabled = true;
        SceneManager.LoadScene("Menu");
    }
    public void NextLvl()
    {
        Time.timeScale = 1f;
        player.enabled = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
