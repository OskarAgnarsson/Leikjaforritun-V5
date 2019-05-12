using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public GameObject winScreen;
    public GameObject deathScreen;

    private PlayerHealth playerHP;

    private void Start()
    {
        playerHP = GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CaveEntrance"))
        {
            StartCoroutine(Next());
        }
    }

    private void Update()
    {
        if (playerHP.hp <= 0)
        {
            StartCoroutine(Dead());
        }
    }

    IEnumerator Next()
    {
        winScreen.SetActive(true);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    IEnumerator Dead()
    {
        deathScreen.SetActive(true);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
