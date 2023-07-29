using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenEvent : MonoBehaviour
{
    private Chicken chicken;

    // Start is called before the first frame update
    void Start()
    {
        chicken = gameObject.GetComponentInParent<Chicken>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            chicken.MakeChickenRun();
        }
    }
}
