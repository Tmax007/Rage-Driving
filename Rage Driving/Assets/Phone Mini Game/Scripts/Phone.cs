using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour
{
    public MiniGameManager minigame;
    public GameObject phoneBackground;

    public bool gameOnScreen = false;

    void Start()
    {
        minigame = minigame.GetComponent<MiniGameManager>();
        phoneBackground = GameObject.Find("PhoneBackground");
        DeactivatePhone();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivatePhone()
    {
        gameOnScreen = true;
        minigame.gameObject.SetActive(gameOnScreen);
        phoneBackground.SetActive(gameOnScreen);

    }

    public void DeactivatePhone()
    {
        gameOnScreen = false;
        minigame.gameObject.SetActive(gameOnScreen);
        phoneBackground.SetActive(gameOnScreen);
    }

    public void ActivateAndDeactivateGame()
    {
        gameOnScreen = !gameOnScreen;
        minigame.gameObject.SetActive(gameOnScreen);
        phoneBackground.SetActive(gameOnScreen);
    }
}
