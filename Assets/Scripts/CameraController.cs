using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [System.Serializable] 
    public class Bounds
    {
        public float left;
        public float right;
        public float down;
    }

    public Transform playerTransform;
    public Transform cameraTransform;
    public Bounds bounds = new Bounds(); 

    void Update ()
    {
        float _playerX = playerTransform.position.x;
        float _playerY = playerTransform.position.y;

        float _newCameraPosX = playerTransform.position.x;
        float _newCameraPosY = playerTransform.position.y;

        if (_playerX <= bounds.left)
        {
            _newCameraPosX = bounds.left;
        }

        if (_playerX >= bounds.right)
        {
            _newCameraPosX = bounds.right;
        }

        if (_playerY <= bounds.down)
        {
            _newCameraPosY = bounds.down;
        }

        cameraTransform.position = new Vector3
        (
            _newCameraPosX,
            _newCameraPosY,
            cameraTransform.position.z
        );
    }
}
