using UnityEngine;

public class DialogueActivator : Interactable
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
    
    public override void Interact(Player player)
    {
        base.Interact(player);

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
