using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Globalization;

public class PressButtonGame : MonoBehaviour
{
    [SerializeField] MiniGameManager miniGameManager;
    [SerializeField] Button button;
    [SerializeField] TextMeshProUGUI buttonNumber;

    private int number = 0;
    private bool gameHasStarted = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnEnable()
    {
        if(!gameHasStarted)
        { 
            miniGameManager = gameObject.GetComponentInParent<MiniGameManager>();
            button = gameObject.GetComponentInChildren<Button>();
            buttonNumber = transform.Find("NumberPressed").GetComponent<TextMeshProUGUI>();
            buttonNumber.text = number.ToString();
            ResetScore();
            gameHasStarted = true;
        }
        else
        {
            ResetScore();
        }
        
    }

    public void IncreaseNumber()
    {
        number++;
        UpdateNumber();
        CheckWin();
    }

    private void UpdateNumber()
    {
        buttonNumber.text = number.ToString();
    }

    private void CheckWin()
    {
        if (number >= 10)
        {
            miniGameManager.TurnOffGame();
        }
    }

    public void ResetScore()
    {
        number = 0;
        UpdateNumber();
    }
}
