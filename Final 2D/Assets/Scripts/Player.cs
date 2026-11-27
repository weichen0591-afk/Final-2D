using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _kickLeft;
    [SerializeField] private GameObject _kickRight;
    [SerializeField] private GameController _gameController;
    // Add member variables to store references to this GameObject's 
    //      Rigidbody, Animator, and SpriteRenderer.
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _speed;
    [SerializeField] private float _jump;

    private bool _facingLeft;
    private bool _isGrounded;

    // ------------------------------------------------------------------------
    // Add a built-in UNITY METHOD that runs EVERY FRAME.
    private void Update()
    {
        // Detect input to move player left/right, jump, and kick
        _rigidbody.linearVelocity = new Vector2(
            Input.GetAxis("Horizontal") * _speed,
            _rigidbody.linearVelocity.y
        );

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (_isGrounded)
            {
                _isGrounded = false;
                _rigidbody.linearVelocity = new Vector2(
                    _rigidbody.linearVelocity.x,
                    _jump
                );
            }
        }
        // Change character facing with SpriteRenderer.flipX value
        if (_rigidbody.linearVelocity.x < 0.0f)
        {
            _facingLeft = true;
            _spriteRenderer.flipX = true;
        }
        else if (_rigidbody.linearVelocity.x > 0.0f)
        {
            _facingLeft = false;
            _spriteRenderer.flipX = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Kick();
        }
        // Set animation parameters 
        if (Mathf.Abs(_rigidbody.linearVelocity.x) > 0.0f)
        {
            _animator.SetBool("walking", true);
        }
        else
        {
             _animator.SetBool("walking", false);
        }
        
        if (_isGrounded)
        {
            _animator.SetBool("jumping", false);
        }
        else
        {
            _animator.SetBool("jumping", true);
        }
    }

    // ------------------------------------------------------------------------
    private void Kick()
    {
        // Set animation parameter.
        _animator.SetTrigger("kick");

        // Either activate left or right kick based on character facing
        if (_facingLeft)
        {
            _kickLeft.SetActive(true);
        }
        else
        {
            _kickRight.SetActive(true);
        }
    }

    // ------------------------------------------------------------------------
    // Use a built-in Unity method to detect COLLISION.
    // Use this to avoid allowing the Player to double jump- they should
    //      collide with an object with the Ground tag before being able to
    //      jump again.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            if (collision.GetContact(0).normal.y > 0.5f)
            {
                _isGrounded = true;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            for (int i = 0; i < collision.contactCount; i++)
            {
                if (collision.GetContact(i).normal.y > 0.5f)
                {
                    if (_rigidbody.linearVelocity.y <= 0.0f)
                    {
                        _isGrounded = true;
                    }
                }
            }
        }
    }
    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _isGrounded = false;
        }
    }
}
