/// Script to make the player name text component always face the camera

using UnityEngine;

public class PlayerName : MonoBehaviour
{
    private Transform _camTransform;

    private void Start()
    {
        _camTransform = Camera.main.transform;
    }

    private void LateUpdate()
    {
        transform.LookAt(transform.position + _camTransform.rotation * Vector3.forward, _camTransform.rotation * Vector3.up);
    }
}
