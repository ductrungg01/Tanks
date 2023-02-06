using System;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraControl : MonoBehaviour
{
    #region Fields
    public float _DampTime = 0.2f;                 
    public float _ScreenEdgeBuffer = 4f;           
    public float _MinSize = 6.5f;                  
    private Transform _PlayerTransform; 
    
    private Camera _Camera;                        
    private float _ZoomSpeed;                      
    private Vector3 _MoveVelocity;                 
    private Vector3 _DesiredPosition;              
    #endregion

    private void Awake()
    {
        _Camera = GetComponentInChildren<Camera>();
    }

    private void Start()
    {
        _PlayerTransform = GameManager.Instance._Player.transform;
    }

    private void FixedUpdate()
    {
        Move();
        Zoom();
    }
    
    private void Move()
    {
        FindAveragePosition();

        transform.position = Vector3.SmoothDamp(transform.position, _DesiredPosition, ref _MoveVelocity, _DampTime);
    }
    
    private void FindAveragePosition()
    {
        _PlayerTransform = GameManager.Instance._Player.transform;
        Vector3 averagePos = _PlayerTransform.position;
        
        averagePos.y = transform.position.y;

        _DesiredPosition = averagePos;
    }

    private void Zoom()
    {
        float requiredSize = FindRequiredSize();
        requiredSize = 20;
        _Camera.orthographicSize = Mathf.SmoothDamp(_Camera.orthographicSize, requiredSize, ref _ZoomSpeed, _DampTime);
    }

    private float FindRequiredSize()
    {
        Vector3 desiredLocalPos = transform.InverseTransformPoint(_DesiredPosition);

        float size = 0f;
        
        Vector3 targetLocalPos = transform.InverseTransformPoint(_PlayerTransform.position);

        Vector3 desiredPosToTarget = targetLocalPos - desiredLocalPos;

        size = Mathf.Max (size, Mathf.Abs (desiredPosToTarget.y));

        size = Mathf.Max (size, Mathf.Abs (desiredPosToTarget.x) / _Camera.aspect);

        size += _ScreenEdgeBuffer;

        size = Mathf.Max(size, _MinSize);

        return size;
    }
    
    public void SetStartPositionAndSize()
    {
        FindAveragePosition();

        transform.position = _DesiredPosition;

        _Camera.orthographicSize = FindRequiredSize();
    }
}