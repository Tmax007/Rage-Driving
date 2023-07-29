using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    [Range(1, 40)] 
    [SerializeField] float hopDistance;

    [Range(1, 20)]
    [SerializeField] float speed;

    public bool isRunning = false;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (isRunning)
        {
            Run();
        }
    }

    [ContextMenu("Hop")]
    public void Hop()
    {
        rb.AddForce(Vector3.right * hopDistance, ForceMode.Impulse);
    }

    private void Run()
    {
        rb.velocity = Vector3.right * speed;
    }

    public void MakeChickenRun()
    {
        isRunning = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Chicken has been hit");
        }
    }
}
