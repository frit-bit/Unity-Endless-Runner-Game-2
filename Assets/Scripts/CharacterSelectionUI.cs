using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

public class CharacterSelectionUI : MonoBehaviour
{

    public void Aj()
    {
      FindAnyObjectByType<CharacterSelection>().character   = Characters.Aj;
        LoadLevel();
    }
    public void Leonard()
    {
        FindAnyObjectByType<CharacterSelection>().character = Characters.Leonard;
        LoadLevel();
    }
    public void Ninja()
    {
        FindAnyObjectByType<CharacterSelection>().character = Characters.Ninja;
        LoadLevel();
    }
    public void LoadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
