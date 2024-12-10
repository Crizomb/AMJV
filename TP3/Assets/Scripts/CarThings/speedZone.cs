using UnityEngine;

public class speedZone : MonoBehaviour
{
    [SerializeField] float speedBoost = 2.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Can e be optimized with layers
    private void OnTriggerEnter(Collider other)
    {
        CarMove car = other.GetComponent<CarMove>();
        if (car != null)
        {
            car.speedModifier = speedBoost;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        CarMove car = other.GetComponent<CarMove>();
        if (car != null)
        {
            car.speedModifier = 1.0f;
        }
    }
}
