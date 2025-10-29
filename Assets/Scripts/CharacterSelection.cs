using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    public Characters character;
     public static CharacterSelection instance;
   

    private void Awake()
    {
        // Singleton pattern — ensures only one MusicManager exists
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // destroy duplicate
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
}
public enum Characters
{
    Aj,
    Leonard,
    Ninja
}