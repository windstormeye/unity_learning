using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private PlayerController player;
    public bool gameOver;
    private Door doorExit;

    public List<Enemy> enemies = new List<Enemy>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        player = FindObjectOfType<PlayerController>();
        doorExit = FindObjectOfType<Door>();
    }

    private void Update()
    {
        gameOver = player.isDead;
        UIManager.instance.GameOverUI(gameOver);
    }

    public void IsEnemy(Enemy enemy)
    {
        enemies.Add(enemy);
    }

    public void EnemyDead(Enemy enemy)
    {
        enemies.Remove(enemy);
        if (enemies.Count == 0)
        {
            doorExit.OpenDoor();
            SaveData();
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        PlayerPrefs.DeleteKey("PlayerHealth");
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public float LoadHealth()
    {
        if (!PlayerPrefs.HasKey("PlayerHealth"))
        {
            PlayerPrefs.SetFloat("PlayerHealth", 3f);
        }

        float currentHealth = PlayerPrefs.GetFloat("PlayerHealth");
        return currentHealth;
    }

    public void SaveData()
    {
        PlayerPrefs.SetFloat("PlayerHealth", player.health);
        PlayerPrefs.Save();
    }
}
