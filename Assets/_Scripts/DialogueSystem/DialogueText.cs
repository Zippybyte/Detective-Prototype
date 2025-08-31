using UnityEngine;
using TMPro;
using System.Collections;
using static UnityEngine.Rendering.DebugUI;
public class DialogueText : MonoBehaviour
{
    //simple texting thing up
    [SerializeField] private TMP_Text textLabel;
    //[SerializeField] private DialogueSO testDialogue;
    [SerializeField] private GameObject dialogueBox;
    //to change size pf text box by scean, go to canvas scaler in canva gameobj
    private TpyeWriterEffect TypeWriterEffect;
    private RepsondHandler repsondHandler;

    public bool isOpen {  get; private set; }   
    private void Start()
    {
        TypeWriterEffect= GetComponent<TpyeWriterEffect>();
        repsondHandler = GetComponent<RepsondHandler>();
        closeDialogueBox();
        
        
    }

    public void ShowDialogue(DialogueSO dialogueObj)
    {
        isOpen = true;  
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObj));
    }

    private IEnumerator StepThroughDialogue(DialogueSO dialogueObj)
    {
        // like the wave manager we did, this loop go through each arry in the SO and run the function run
        /*foreach (string dialogue in dialogueObj.Dialogue)
        {
            yield return TypeWriterEffect.Run(dialogue, textLabel);
            // it will paise until we press key space
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }*/
        for (int i = 0; i < dialogueObj.Dialogue.Length; i++)
        {
            string dialogue = dialogueObj.Dialogue[i];

            yield return RunTypingEffect(dialogue); 
            /*yield return TypeWriterEffect.Run(dialogue, textLabel);*/
            //TypeWriter is void 
            textLabel.text = dialogue;

            if (i == dialogueObj.Dialogue.Length - 1 && dialogueObj.HasResponses) break;

            yield return null;
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }
        if (dialogueObj.HasResponses)
        {
            repsondHandler.ShowResponses(dialogueObj.Responds);

        }
        else {
            closeDialogueBox();

        }
        
    }

    private IEnumerator RunTypingEffect(string dialogue)
    {
        TypeWriterEffect.Run(dialogue, textLabel);
        
        while (TypeWriterEffect.IsRunning)
        {
            yield return null;
            if(Input.GetKeyDown(KeyCode.Space))
            {
                TypeWriterEffect.Stop(); 
            }
        }

    }

    private void closeDialogueBox()
    {
        isOpen= false;
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
    }

}
