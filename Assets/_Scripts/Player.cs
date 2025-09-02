using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public PlayerInput playerInput;
    public Rigidbody2D rb;
    public float moveSpeed = 9f;

    private InputAction movementAction;
    private InputAction interactAction;

    [SerializeField] private DialogueText dialogueText;

    public DialogueText DialogueText => dialogueText;

    public IInterractable interractable { get; set; } // Probably deprecate this in the future
    [NonSerialized] public List<Interactable> interactablesInRange = new List<Interactable>() { };
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        movementAction = playerInput.actions.FindAction("Move");
        interactAction = playerInput.actions.FindAction("Interact");

        interactAction.performed += Interact;
    }

    private void OnEnable()
    {

        movementAction.Enable();
        interactAction.Enable();
    }
    private void OnDisable()
    {
        movementAction.Disable();
        interactAction.Disable();
    }

    private void OnDestroy()
    {
        interactAction.performed -= Interact;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (movementAction.ReadValue<Vector2>() == Vector2.zero)
        //{
        //    entityMovement.rb.linearVelocity = Vector2.zero;
        //}
        rb.linearVelocity = movementAction.ReadValue<Vector2>() * moveSpeed;

    }

    private void Update()
    {
        
    }

    private void Interact(InputAction.CallbackContext context)
    {
        if (interractable != null)
        {
            interractable.Interact(this);
        }

        if (interactablesInRange.Count == 1)
        {
            interactablesInRange[0].Interact(this);
        }
        // Interact with the closest interactable if there are multiple in range
        else if (interactablesInRange.Count > 1)
        {
            Interactable closest = interactablesInRange[0];
            for (int i = 1; i < interactablesInRange.Count; i++)
            {
                if (interactablesInRange[i].GetDistance(gameObject) < closest.GetDistance(gameObject))
                {
                    closest = interactablesInRange[i];
                }
            }

            closest.Interact(this);
        }
    }
}