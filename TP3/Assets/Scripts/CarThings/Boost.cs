using UnityEngine;

public class Boost : MonoBehaviour
{
    [SerializeField] Rigidbody _rb;
    [SerializeField] float boostForce;
    [SerializeField] float boostRefillTime;

    [HideInInspector]
    public float charge { get; private set; } // Beetwen 0 and 1

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        charge = Mathf.Clamp(charge + Time.deltaTime / boostRefillTime, 0, 1.0f);
        // Middle click and 0.99f because I'm affraid of floating point comparison
        if (Input.GetMouseButton(2) && charge >= 0.99f)
        {
            _rb.AddForce(boostForce * _rb.transform.forward, ForceMode.Impulse);
            charge = 0;
        }
    }
}
