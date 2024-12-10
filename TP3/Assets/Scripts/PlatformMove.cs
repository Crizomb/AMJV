using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    [SerializeField] Transform start;
    [SerializeField] Transform end;
    [SerializeField]
    [Range(0.5f, 10f)]
    float loop_time;

    float t;
    float direction = 1.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        t += Time.fixedDeltaTime * direction;
        transform.position = Vector3.Lerp(start.position, end.position, t / loop_time);
        if (t  > loop_time)
        {
            direction *= -1;
        }
        if (t < 0)
        {
            direction = 1;
        }
    }


}
