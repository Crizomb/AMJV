using UnityEngine;

public class CarMove : MonoBehaviour
{
    public float speedModifier = 1.0f;
    [SerializeField] float forwardMoveForce;
    [SerializeField] float backwardMoveForce;

    Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            rb.AddForce(transform.forward * forwardMoveForce * speedModifier);
        }
        if (Input.GetMouseButton(1))
        {
            rb.AddForce(-transform.forward * backwardMoveForce * speedModifier);
        }

    }

}
