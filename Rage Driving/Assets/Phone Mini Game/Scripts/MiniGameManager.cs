using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameManager : MonoBehaviour
{
    public PressButtonGame pbgGame;
    private Phone phone;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    private void OnEnable()
    {
        pbgGame = gameObject.GetComponentInChildren<PressButtonGame>();
        phone = gameObject.GetComponentInParent<Phone>();
    }

    public void TurnOffGame()
    {
        phone.DeactivatePhone();
    }

}
