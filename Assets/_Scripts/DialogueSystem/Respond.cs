using System;
using System.Runtime.CompilerServices;
using UnityEngine;
// Idea: make a serialize file for respond class
[Serializable]
public class Respond
{
    [SerializeField] private string respondText;
    [SerializeField] private DialogueSO dialogueObj;
    // getter
    public string RespondText => respondText;
    public DialogueSO DialogueObj => dialogueObj;
}
