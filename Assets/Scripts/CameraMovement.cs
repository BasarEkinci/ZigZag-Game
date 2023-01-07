using System;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float speed;
    [SerializeField] private BallMovement ballM;

    private void Update()
    {
        speed = ballM.speed / 2;
        
        if (GameManager.isGameStarted)
        {
            transform.position += speed * Time.deltaTime * new Vector3(1,0,1);
        }
    }
}
