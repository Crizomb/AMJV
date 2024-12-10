using UnityEngine;

public class Boost : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float boostMultiplier;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Middle click
        if (Input.GetMouseButton(2))
        {
            rb.linearVelocity *= boostMultiplier;
        }
    }
}
