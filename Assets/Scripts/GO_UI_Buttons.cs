using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GO_UI_Buttons : MonoBehaviour
{
    public void replay()
    {
        SceneManager.LoadScene(1);
        MusicManager.instance.SwitchMusic(MusicManager.instance.backgroundClip, .75f);
    }
    public void backToMenu()
    {
        SceneManager.LoadScene(0);
        MusicManager.instance.SwitchMusic(MusicManager.instance.menuClip, 0.75f);
    }
}
