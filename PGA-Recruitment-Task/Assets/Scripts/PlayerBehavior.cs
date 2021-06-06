using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float rotationSpeed = 45.0f;
    public Rigidbody rb;
    public CapsuleCollider col;
    public Camera cam;

    public GameBehavior gameManager;

    private float _hMovementInput = 0.0f;
    private float _vMovementInput = 0.0f;
    private float _xRotationInput = 0.0f;
    private float _yRotationInput = 0.0f;
    private float _yRotation = 0.0f;

    private void Update()
    {
        //update position and roration of player only if game is not on pause
        if (!gameManager.IsGameOnPause())
        {
            Vector3 movement = transform.right * _hMovementInput + transform.forward * _vMovementInput;
            Vector3 rotation = Vector3.up * _xRotationInput * rotationSpeed * Time.fixedDeltaTime;
            Quaternion angleRot = Quaternion.Euler(rotation);

            _yRotation -= _yRotationInput;
            _yRotation = Mathf.Clamp(_yRotation, -90, 90);
            cam.transform.localRotation = Quaternion.Euler(_yRotation, 0f, 0f);

            rb.MovePosition(this.transform.position + movement * Time.fixedDeltaTime * moveSpeed);
            rb.MoveRotation(rb.rotation * angleRot);
        }
    }

    //on wasd event movement function
    public void Move(InputAction.CallbackContext context)
    {
        if (Keyboard.current.wKey.wasPressedThisFrame || Keyboard.current.wKey.wasReleasedThisFrame)
        {
            _vMovementInput = context.ReadValue<Vector2>().y;
        }
        if (Keyboard.current.sKey.wasPressedThisFrame || Keyboard.current.sKey.wasReleasedThisFrame)
        {
            _vMovementInput = context.ReadValue<Vector2>().y;
        }
        if (Keyboard.current.aKey.wasPressedThisFrame || Keyboard.current.aKey.wasReleasedThisFrame)
        {
            _hMovementInput = context.ReadValue<Vector2>().x;
        }
        if (Keyboard.current.dKey.wasPressedThisFrame || Keyboard.current.dKey.wasReleasedThisFrame)
        {
            _hMovementInput = context.ReadValue<Vector2>().x;
        }
    }
    //on mouse delta event function
    public void Look(InputAction.CallbackContext context)
    {
        _xRotationInput = context.ReadValue<Vector2>().x;
        _yRotationInput = context.ReadValue<Vector2>().y;
    }

    //on Q and E rotation event function
    public void Rotate(InputAction.CallbackContext context)
    {
        if (Keyboard.current.qKey.wasPressedThisFrame || Keyboard.current.qKey.wasReleasedThisFrame)
        {
            _xRotationInput = context.ReadValue<float>();
        }
        if (Keyboard.current.eKey.wasPressedThisFrame || Keyboard.current.eKey.wasReleasedThisFrame)
        {
            _xRotationInput = context.ReadValue<float>();
        }
    }

    //on LMB clicl event function
    public void Click(InputAction.CallbackContext context)
    {
        if (!gameManager.IsGameOnPause())
        {
            gameManager.CastRay(true);
        }
    }

    public void ResetPlayer()
    {
        cam.transform.rotation = Quaternion.identity;
        gameObject.transform.position = new Vector3(0,1.5f, 0);
        gameObject.transform.rotation = Quaternion.Euler(0,-90, 0);
    }
}
