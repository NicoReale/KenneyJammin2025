using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehaviour : MonoBehaviour
{
    [Header("Teletransporte")]
    public Transform leftTarget;
    public Transform rightTarget;
    public float teleportDuration = 1f;

    [Header("Salto")]
    public float jumpForce = 7f;               
    public LayerMask groundLayer;              
    public Transform groundCheck;               
    public float groundCheckRadius = 1f;
    private float originalX;

    private Vector3 originalPosition;
    private bool isTeleporting = false;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!isTeleporting)
        {

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                StartCoroutine(TeleportTo(leftTarget.position));
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                StartCoroutine(TeleportTo(rightTarget.position));
            }
        }
        {             
            if (Input.GetKeyDown(KeyCode.UpArrow) && IsGrounded())
            {
                transform.position = new Vector3(transform.position.x,transform.position.y + jumpForce, transform.position.z);                              
            }
        }
    }

    private IEnumerator TeleportTo(Vector3 targetPosition)
    {
        isTeleporting = true;

        originalX = transform.position.x;

        transform.position = new Vector3(targetPosition.x, transform.position.y, transform.position.z);

        yield return new WaitForSeconds(teleportDuration);

        transform.position = new Vector3(originalX, transform.position.y, transform.position.z);

        isTeleporting = false;
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }
}