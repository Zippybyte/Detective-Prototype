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

    
    private List<GameObject> tempResponseButton = new List<GameObject>();
    private void Start()
    {
        dialogueText = GetComponent<DialogueText>();   
    }
    public void ShowResponses(Respond[] responses)
    {
        float responseBoxHeight = 0;

        foreach(Respond response in responses)
        {
            GameObject respondButton = Instantiate(respondButtonTemplate.gameObject, respondContainer);
            respondButton.SetActive(true);
            respondButton.GetComponent<TMP_Text>().text = response.RespondText;
            respondButton.GetComponent<Button>().onClick.AddListener(() => OnPickedResponse(response));
            tempResponseButton.Add(respondButton);
            responseBoxHeight += respondButtonTemplate.sizeDelta.y;
            
        }

        repsonseBox.sizeDelta = new Vector2(repsonseBox.sizeDelta.x, responseBoxHeight);
        repsonseBox.gameObject.SetActive(true);

    }
    public void OnPickedResponse(Respond response)
    {
        repsonseBox.gameObject.SetActive(false);
        foreach (GameObject button in  tempResponseButton)
        {
            Destroy(button);
        }
        dialogueText.ShowDialogue(response.DialogueObj);
    }
}
