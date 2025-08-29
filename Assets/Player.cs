using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public PlayerInput playerInput;
    public Rigidbody2D rb;
    public float moveSpeed = 9f;

    private InputAction movementAction;


    public Rigidbody2D rb;

    [SerializeField] private DialogueText dialogueText;

    public DialogueText DialogueText => dialogueText;

    public IInterractable interractable { get; set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        movementAction = playerInput.actions.FindAction("Move");
    }

    private void OnEnable()
    {
        movementAction.Enable();
    }
    private void OnDisable()
    {
        movementAction.Disable();
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
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (interractable != null)
            {

                interractable.Interact(this);

            }
        }
    }
}