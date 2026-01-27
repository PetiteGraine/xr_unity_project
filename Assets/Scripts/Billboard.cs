using UnityEngine;

public sealed class Billboard : MonoBehaviour
{
    private Transform _mainCameraTransform;

    void Start()
    {
        if (Camera.main != null)
        {
            _mainCameraTransform = Camera.main.transform;
        }
    }

    void LateUpdate()
    {
        if (_mainCameraTransform == null) return;

        transform.LookAt(transform.position + _mainCameraTransform.rotation * Vector3.forward,
                         _mainCameraTransform.rotation * Vector3.up);
    }
}