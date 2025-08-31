using UnityEngine;

public class DialogueActivator : MonoBehaviour, IInterractable
{
    [SerializeField] DialogueSO dialogueObj;

    private bool shouldDisappear = false;



    public void MarkForDisappearance()
    {
        shouldDisappear = true;
    }

    // Called by DialogueText.onDialogueFinished
    public void TryDisappear()
    {
        if (shouldDisappear)
        {
            gameObject.SetActive(false); // or Destroy(gameObject) if permanent
        }
    }
    public void UpdateDialogueObj(DialogueSO dialogueObj)
    {
        this.dialogueObj = dialogueObj;
    }
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
        foreach (DialogueResponesEvent responesEvent in GetComponents<DialogueResponesEvent>())
        {
            if (responesEvent.DialogueSO == dialogueObj)
            {
                player.DialogueText.AddResponesEvent(responesEvent.Events);
                break;
            }
        }

        player.DialogueText.ShowDialogue(dialogueObj);
    }

}
