using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComtroller : MonoBehaviour
{
    private bool pause = false;
    public GameObject lance;
    [SerializeField] private MoveSettings _settings = null;

    private Vector3 _moveDirection;
    private CharacterController _controller;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if(!pause)
            DefaultMovement();
    }

    private void FixedUpdate()
    {
        if (!pause)
            _controller.Move(_moveDirection * Time.deltaTime);
    }

    private void DefaultMovement()
    {
        if (_controller.isGrounded)
        {
            Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            if (input.x != 0 && input.y != 0)
            {
                input *= 0.777f;
            }

            _moveDirection.x = input.x * _settings.speed;
            _moveDirection.z = input.y * _settings.speed;
            _moveDirection.y = -_settings.antiBump;

            _moveDirection = transform.TransformDirection(_moveDirection);

            if (Input.GetKey(KeyCode.Space))
            {
                Jump();
            }

            //dash function here
        }
        else
        {
            _moveDirection.y -= _settings.gravity * Time.deltaTime;
        }
    }

    private void Jump()
    {
        _moveDirection.y += _settings.jumpForce;
    }

    public void pausePlayer(float doorTime)
    {
        
        
        StartCoroutine(cutDoor(doorTime));
    }
    IEnumerator cutDoor(float doorTime)
    {
        yield return new WaitForSeconds(.5f);
        pause = true;
        yield return new WaitForSeconds(2.2f);
        lance.SetActive(false);
        yield return new WaitForSeconds(doorTime);
        pause = false;
        lance.SetActive(true);

    }
}
