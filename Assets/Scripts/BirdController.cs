using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BirdController : MonoBehaviour
{
    public float jumpForce;
    public Rigidbody2D rb;
    private int score;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverPanel;

    private void Start()
    {
        Time.timeScale = 1;
        gameOverPanel.SetActive(false); // Game Over panelini başlangıçta gizli yap
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Score")
        {
            score++;
            scoreText.text = score.ToString();
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Death")
        {
            Debug.Log("Game Over triggered");
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }
    }

    public void Restart()
    {
        Debug.Log("Restart triggered");
        Time.timeScale = 1; // Oyunun tekrar normal hızda başlaması için
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

