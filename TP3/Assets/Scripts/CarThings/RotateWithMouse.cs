using UnityEngine;

public class RotateWithMouse : MonoBehaviour
{
    [SerializeField] LayerMask layerToIgnore;
    [SerializeField] Transform targetTransform;
    [SerializeField]
    [Range(0f, 1f)]
    float lerpSpeed = 0.1f;
    
    Rigidbody rb;
    Camera cam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Ray _ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(_ray, out RaycastHit hitInfo, float.MaxValue, ~layerToIgnore))
        {
            Vector3 point = hitInfo.point;
            Vector3 dir = (point - transform.position).normalized;
            dir.y = 0f;
            targetTransform.forward = Vector3.Lerp(targetTransform.forward, dir, lerpSpeed);

        }
    }
}
