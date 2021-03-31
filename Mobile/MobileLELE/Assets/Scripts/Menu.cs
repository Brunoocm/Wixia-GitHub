using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Proximo(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void PauseMenu()
    {
        Time.timeScale = 0f;
    }

    public void ResumeMenu()
    {
        Time.timeScale = 1f;
    }
    public void Sair()
    {
        Application.Quit();
    }

    public void Comecar()
    {
        SceneManager.LoadScene("Wixia");
    }
}
