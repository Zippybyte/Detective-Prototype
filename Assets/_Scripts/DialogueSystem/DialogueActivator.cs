using UnityEngine;

public class DialogueActivator : MonoBehaviour, IInterractable
{
    [SerializeField] DialogueSO dialogueObj;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") &&  other.TryGetComponent(out Player player))
        {
            Debug.Log("Inside");
            player.interractable = this;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent(out Player player))
        {
            if (player.interractable is DialogueActivator dialogueActivator && dialogueActivator == this)
            {
                player.interractable = null;
            }
        }
    }
    public void Interact(Player player)
    {
        player.DialogueText.ShowDialogue(dialogueObj);
    }

}
