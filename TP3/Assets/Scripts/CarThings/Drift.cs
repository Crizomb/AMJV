using UnityEngine;

public class Drift : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] private float baseLateralFrictionCoeff = 5f;
    [SerializeField] private float lateralVelocityStartDriftThreshold = 10f;
    [SerializeField] private float lateralVelocityTotalDriftThreshold = 15f;

    [SerializeField] private TrailRenderer trailRendererLeft;
    [SerializeField] private TrailRenderer trailRendererRight;


    [SerializeField] RotateWithMouse moreRotateWhenDrift;

    [SerializeField] [Range(1, 5)] float RotateLerpSpeedMultipler;

    private float lateralFrictionCoeff;
    private float baseRotateLerpSpeed;
    private float newRotateLerpSpeed => baseRotateLerpSpeed * RotateLerpSpeedMultipler;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        baseRotateLerpSpeed = moreRotateWhenDrift.lerpSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

        Vector3 forwardVelocity = Vector3.Project(rb.linearVelocity, transform.forward);
        Vector3 lateralVelocity = rb.linearVelocity - forwardVelocity;

        // dynamicCoeff is equal to 1 when no drift is happening, and 0 when the drift is at its maximum
        float dynamicCoeff = Mathf.InverseLerp(lateralVelocityTotalDriftThreshold, lateralVelocityStartDriftThreshold, lateralVelocity.magnitude);
        trailRendererLeft.emitting = dynamicCoeff < 0.9f;
        trailRendererRight.emitting = dynamicCoeff < 0.9f;


        // When no drift -> lerpSpeed = baseRotateLerpSpeed, when drift -> lerpSpeed = newRotateLerpSpeed
        moreRotateWhenDrift.lerpSpeed = Mathf.Lerp(newRotateLerpSpeed, baseRotateLerpSpeed, dynamicCoeff);
        lateralFrictionCoeff = baseLateralFrictionCoeff * dynamicCoeff;
        print(dynamicCoeff);

        Vector3 lateralFrictionForce = -lateralVelocity * lateralFrictionCoeff;
        rb.AddForce(lateralFrictionForce, ForceMode.Acceleration);
    }

}
