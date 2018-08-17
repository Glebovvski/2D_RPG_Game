using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessagingClientReceiver : MonoBehaviour {

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        MessagingManager.Instance.Subscribe(ThePlayerIsTryingToLeave);
    }
    
    void ThePlayerIsTryingToLeave()
    {
        var dialog = GetComponent<ConversationComponent>();
        if (dialog != null)
        {
            if(dialog.Conversations!=null && dialog.Conversations.Length > 0)
            {
                var conversation = dialog.Conversations[0];
                if (conversation != null)
                {
                    ConversationManager.Instance.StartConversation(conversation);
                }
            }
        }
    }
}
