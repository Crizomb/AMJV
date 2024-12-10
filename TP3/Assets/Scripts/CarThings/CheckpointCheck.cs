using UnityEngine;

public class CheckpointCheck : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public const int MAX_LAPS = 3;
    [HideInInspector] public int NumberOfLaps { get; private set; } = 0;

    private int currentCheckPointIndex = 0;
    private int numberOfCheckpoints;
    void Start()
    {
        numberOfCheckpoints = Object.FindObjectsByType<Checkpoint>(FindObjectsSortMode.None).Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        print("Collision");
        if (!collision.gameObject.TryGetComponent(out Checkpoint checkpoint)) return;

        if (checkpoint.Index == currentCheckPointIndex) currentCheckPointIndex++;

        if (currentCheckPointIndex == numberOfCheckpoints)
        {
            currentCheckPointIndex = 0;
            NumberOfLaps++;
        }

    }
}
