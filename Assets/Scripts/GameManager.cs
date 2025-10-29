using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int CoinCount = 0;
    public TextMeshProUGUI CoinText;
    public TextMeshProUGUI SurvivalTimeText;
    private float SurvivalTime;
    public bool isAlive;

    [Header("Characters")]
    public GameObject Aj, Ninja, Leonard;

    public Animator myChracterAvatar;
   
   public void characterSelection()
    {
        CharacterSelection selection = FindAnyObjectByType<CharacterSelection>();
        if (selection.character == Characters.Aj)
        {
            myChracterAvatar.avatar = Aj.GetComponent<Animator>().avatar;
            DisableAllCharacters();
            Aj.SetActive(true);
        }
        if (selection.character == Characters.Ninja)
        {
            myChracterAvatar.avatar = Ninja.GetComponent<Animator>().avatar;
            DisableAllCharacters();
            Ninja.SetActive(true);
        }
        if (selection.character == Characters.Leonard)
        {
            myChracterAvatar.avatar = Leonard.GetComponent<Animator>().avatar;
            DisableAllCharacters();
            Leonard.SetActive(true);
        }
    }
    public void DisableAllCharacters()
    {
        Aj.SetActive(false);
        Ninja.SetActive(false);
        Leonard.SetActive(false);
    }
    private void Start()
    {
        characterSelection();
        MusicManager.instance.SwitchMusic(MusicManager.instance.backgroundClip, 0.75f);
    }
    public void CoinCollected()
    {
        CoinCount++;
        CoinText.text = "Coins : " + CoinCount.ToString();
    }
    private void Update()
    {
        if (isAlive)
        {
            SurvivalTime += Time.deltaTime;
            float rounded = Mathf.Round(SurvivalTime * 100) / 100f;
            SurvivalTimeText.text = "Survival Time: " + rounded.ToString();
        }
    }
}
