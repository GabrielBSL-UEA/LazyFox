using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SceneControler (string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void QuitaGameplay()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }

}
