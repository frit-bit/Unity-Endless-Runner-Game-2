using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Types;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MainMenu : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene(1);
    }
    public void quitGame()
    {
        Application.Quit();
        EditorApplication.isPlaying = false;
    }
}
