using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UImage = UnityEngine.UI.Image;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] TextMeshProUGUI velocityText;
    [SerializeField] TextMeshProUGUI lapText;
    [SerializeField] UImage boostBar;

    [SerializeField] Rigidbody car;
    [SerializeField] Boost boost;
    [SerializeField] CheckpointCheck checkpointCheck;

    bool has_won = false;
    float time = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        int minute = (int) time / 60;
        int secondes = (int) time % 60;
        timeText.text = $"Time : {minute} min {secondes}s";
        
        int velocity = (int) car.linearVelocity.magnitude;
        velocityText.text = $"{velocity} m/s";

        boostBar.fillAmount = boost.charge;

        lapText.text = $"Lap : {checkpointCheck.NumberOfLaps + 1} / {CheckpointCheck.MAX_LAPS}";

        if (checkpointCheck.NumberOfLaps == CheckpointCheck.MAX_LAPS && !has_won)
        {
            Win();
        }

    }

    void Win()
    {
        has_won = true;
        EventBus.WinEvent.Invoke(time);
    }
}
