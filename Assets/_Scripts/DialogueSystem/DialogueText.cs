using UnityEngine;
using TMPro;
using System.Collections;
public class DialogueText : MonoBehaviour
{
    //simple texting thing up
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private DialogueS0 testDialogue;
    [SerializeField] private GameObject dialogueBox;
    //to change size pf text box by scean, go to canvas scaler in canva gameobj
    private TpyeWriterEffect TypeWriterEffect;
    private void Start()
    {
        TypeWriterEffect= GetComponent<TpyeWriterEffect>();
        closeDialogueBox();
        ShowDialogue(testDialogue);
        
    }

    public void ShowDialogue(DialogueS0 dialogueObj)
    {
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObj));
    }

    private IEnumerator StepThroughDialogue(DialogueS0 dialogueObj)
    {
        // like the wave manager we did, this loop go through each arry in the SO and run the function run
        foreach (string dialogue in dialogueObj.dialogue)
        {
            yield return TypeWriterEffect.Run(dialogue, textLabel);
            // it will paise until we press key space
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }
        closeDialogueBox();
    }

    private void closeDialogueBox()
    {
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
    }

}
