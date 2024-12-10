using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] TextMeshProUGUI velocityText;
    [SerializeField] Rigidbody car;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int minute = (int) Time.time / 60;
        int secondes = (int) Time.time % 60;
        timeText.text = $"Time : {minute} min {secondes}s";
        
        int velocity = (int) car.linearVelocity.magnitude;
        velocityText.text = $"{velocity} m/s";
    }
}
