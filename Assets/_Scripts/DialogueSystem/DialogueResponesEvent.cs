using UnityEngine;
using System;
public class DialogueResponesEvent : MonoBehaviour
{
    [SerializeField] private DialogueSO dialogueObj;
    [SerializeField] private ResponesEvent[] events;
    public DialogueSO DialogueSO => dialogueObj;
    public ResponesEvent[] Events => events;

    public void OnValidate()
    {
        // doing a bunch of checking
        if (dialogueObj == null) return;
        if (dialogueObj.Responds == null) return;

        if (events != null && events.Length == dialogueObj.Responds.Length) return;
        if (events == null)
        {
            events = new ResponesEvent[dialogueObj.Responds.Length];
        }
        else
        {
            Array.Resize(ref events, dialogueObj.Responds.Length);
        }
        for (int i = 0; i < dialogueObj.Responds.Length; i++)
        { 
            Respond respones = dialogueObj.Responds[i];
            if (events[i] != null)
            {
                events[i].name = respones.RespondText;
                continue;
            }

            events[i] = new ResponesEvent() { name = respones.RespondText };
        }
    }
}

