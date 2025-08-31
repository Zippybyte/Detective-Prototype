using UnityEngine;
using TMPro;
using UnityEngine.UI;
using NUnit.Framework;
using System.Collections.Generic;
public class RepsondHandler: MonoBehaviour 
{
    //damm the tutorial guy, he copy this some where on his damm note
    [SerializeField] private RectTransform repsonseBox;
    [SerializeField] private RectTransform respondButtonTemplate;
    [SerializeField] private RectTransform respondContainer;

    private DialogueText dialogueText;
    private ResponesEvent[] responesEvents;
    
    private List<GameObject> tempResponseButton = new List<GameObject>();
    private void Start()
    {
        dialogueText = GetComponent<DialogueText>();   
    }

    public void AddResponseEvent(ResponesEvent[] responesEvents)
    {
        this.responesEvents = responesEvents;
    }
    public void ShowResponses(Respond[] responses)
    {
        float responseBoxHeight = 0;
        //change the loop into for loop to addrease the RespondEvent
        for (int i = 0; i < responses.Length; i++) 
        {
            Respond response = responses[i];
            int responesIndex = i;

            GameObject respondButton = Instantiate(respondButtonTemplate.gameObject, respondContainer);
            respondButton.SetActive(true);
            respondButton.GetComponent<TMP_Text>().text = response.RespondText;
            respondButton.GetComponent<Button>().onClick.AddListener(() => OnPickedResponse(response,responesIndex));
            tempResponseButton.Add(respondButton);
            responseBoxHeight += respondButtonTemplate.sizeDelta.y;
            
        }

        repsonseBox.sizeDelta = new Vector2(repsonseBox.sizeDelta.x, responseBoxHeight);
        repsonseBox.gameObject.SetActive(true);

    }
    // add a new parameter for event
    public void OnPickedResponse(Respond response, int responseIndex)
    {
        repsonseBox.gameObject.SetActive(false);
        foreach (GameObject button in  tempResponseButton)
        {
            Destroy(button);
        }
        // we check if there is an event on that respond
        if (responesEvents != null && responseIndex <= responesEvents.Length)
        {
            responesEvents[responseIndex].OnPickedResponse?.Invoke();
        }
        responesEvents = null;
        if (response.DialogueObj)
        {
            dialogueText.ShowDialogue(response.DialogueObj);
        }
        else
        {
            dialogueText.closeDialogueBox();
        }
    }
}
    