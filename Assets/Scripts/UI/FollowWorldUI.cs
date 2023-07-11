using UnityEngine;
using Zenject;

public class FollowWorldUI : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector2 offset;

    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        Vector2 possition = _camera.WorldToScreenPoint((Vector2)target.position + offset);

        if ((Vector2)transform.position != possition)
            transform.position = possition;
    }
}
