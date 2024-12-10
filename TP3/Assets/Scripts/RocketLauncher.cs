using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
    [SerializeField] GameObject rocketPrefab;
    [SerializeField] Transform spawnTransform;
    [SerializeField] Rigidbody car;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject rocket = GameObject.Instantiate(rocketPrefab);
            rocket.transform.position = spawnTransform.position;
            rocket.transform.forward = transform.forward;
            Rigidbody rb = rocket.GetComponent<Rigidbody>();
            rb.linearVelocity = car.linearVelocity;
        }
    }
}
