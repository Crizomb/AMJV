using UnityEngine;

public class Rocket : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] Vector3 initVelocitity;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.linearVelocity += transform.rotation * initVelocitity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
