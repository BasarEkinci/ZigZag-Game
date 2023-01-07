using System.Collections;
using UnityEngine;

public class PieceManager : MonoBehaviour
{
    private bool isBallTouched;
    private Rigidbody pieceRb;
    public bool isRBounded;
    public bool isLBounded;

    private void Start()
    {
        pieceRb = GetComponent<Rigidbody>();
    }

    private void OnCollisionExit(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.CompareTag("Ball")  && GameManager.isGameStarted == true)
        {
            StartCoroutine(PieceActions());
        }
    }
    
    //to stay on screen
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("LeftBound"))
        {
            isLBounded = true;
        }
        else if(other.gameObject.CompareTag("RightBound"))
        {
            isRBounded = true;
        }
        else
        {
            isRBounded = false;
            isLBounded = false;
        }
    }

    IEnumerator PieceActions()
    {
        yield return new WaitForSecondsRealtime(2f);
        pieceRb.isKinematic = false;
        pieceRb.useGravity = true;
        Destroy(this.gameObject,3.1f);
    }
}