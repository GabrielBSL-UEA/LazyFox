using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryTrigger : MonoBehaviour
{
    [SerializeField] private GameController gameController;
    public string VictoryScene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //gameController.ActivateVictoryPanel();
            SceneManager.LoadScene(VictoryScene);

        }
    }
}
