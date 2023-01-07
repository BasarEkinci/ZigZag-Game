using System;
using Unity.Mathematics;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [Range(1, 20)] public float speed;

    private Vector3 direction;
    public GameObject particleSystem;

    public AudioSource sounds;
    public AudioClip diamondSound;


    private void Start()
    {
        sounds = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (direction == Vector3.forward)
                direction = Vector3.right;
            else
                direction = Vector3.forward;

            speed += 0.01f;
        }
        transform.position += speed * Time.deltaTime * direction;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Diamond"))
        {
            if (UIManager.isSoundsOpen)
                sounds.PlayOneShot(diamondSound);

            Destroy(other.gameObject);
            Instantiate(particleSystem, transform.position, quaternion.identity);
            GameManager.score++;
        }
    }
}
