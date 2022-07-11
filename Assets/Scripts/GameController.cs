using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject defeatPanel;
    [SerializeField] private GameObject victoryPanel;

    private AudioSource audioSource;

    private void Awake()
    {
        TryGetComponent(out audioSource);
    }

    public void ActivateVictoryPanel()
    {
        victoryPanel.SetActive(true);
        Time.timeScale = 0;
        audioSource.Stop();
    }

    public void ActivateDefeatPanel()
    {
        defeatPanel.SetActive(true);
        Time.timeScale = 0;
        audioSource.Stop();
    }

    public void ReloadLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
