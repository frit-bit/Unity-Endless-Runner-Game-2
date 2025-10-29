using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    public Characters character;
    public static CharacterSelection instance;
    public Button AjButton;
    public Button LeonardButton;
    public Button NinjaButton;

    private void Awake()
    {
        // Singleton pattern — ensures only one script exists
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // destroy duplicate
            return;
        }

        instance = this;
        DontDestroyOnLoad(this);
        AjButton.onClick.AddListener(Aj);
        LeonardButton.onClick.AddListener(Leonard);
        NinjaButton.onClick.AddListener(Ninja);
    }
    public void Aj()
    {
        character = Characters.Aj;
        LoadLevel();
    }
    public void Leonard()
    {
        character = Characters.Leonard;
        LoadLevel();
    }
    public void Ninja()
    {
        character = Characters.Ninja;
        LoadLevel();
    }
    public void LoadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
public enum Characters
{
    Aj,
    Leonard,
    Ninja
}