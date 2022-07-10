using System.Collections;
using System.Collections.Generic;
using PixelCrushers.DialogueSystem;
using UnityEngine;

public class StartDialogue : MonoBehaviour
{
    // Start is called before the first frame update
    [ConversationPopup] public string conversation;
    public Transform actor;
    public Transform conversant;
    
    public void StartMyConversation()
    {
        DialogueManager.StartConversation(conversation, actor, conversant);
    }
}
