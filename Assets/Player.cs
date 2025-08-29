using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public PlayerInput playerInput;
    public EntityMovement entityMovement;
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
        entityMovement.Move(movementAction.ReadValue<Vector2>());
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