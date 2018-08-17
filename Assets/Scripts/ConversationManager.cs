using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationManager : Singleton<ConversationManager> {

	protected ConversationManager() { }

    bool talking = false;

    ConversationEntry currentConversationLine;

    int fontSpacing = 7;

    int conversationTextWidth;

    int dialogHeight = 70;

    public int displayTextureOffset = 70;

    Rect scaledTextureRect;

    private string currentText="";

    private float delay = 0.05f;

    IEnumerator DisplayConversation(Conversation conversation)
    {
        talking = true;
        foreach (var conversationLine in conversation.ConversationLines)
        {
            currentConversationLine = conversationLine;
            conversationTextWidth = currentConversationLine.ConversationText.Length * fontSpacing;
            scaledTextureRect = new Rect(currentConversationLine.DisplayPic.textureRect.x / currentConversationLine.DisplayPic.texture.width,
                currentConversationLine.DisplayPic.textureRect.y / currentConversationLine.DisplayPic.texture.height,
                currentConversationLine.DisplayPic.textureRect.width / currentConversationLine.DisplayPic.texture.width,
                currentConversationLine.DisplayPic.textureRect.height / currentConversationLine.DisplayPic.texture.height);
            for (int i = 0; i <= currentConversationLine.ConversationText.Length; i++)
            {
                currentText = currentConversationLine.ConversationText.Substring(0, i);
                if (i >= conversationLine.ConversationText.Length)
                    delay = 1f;
                yield return new WaitForSeconds(delay);
            }
            delay = 0.05f;   
            
        }
        talking = false;
        yield return null;
    }

    IEnumerator LetterByLetter(string strComplete)
    {
        for (int i = 0; i < strComplete.Length; i++)
        {
            currentText = strComplete.Substring(0, i);
            
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void OnGUI()
    {
        if (talking)
        {
            GUI.BeginGroup(new Rect(Screen.width / 2 - conversationTextWidth / 2, 50, conversationTextWidth +displayTextureOffset + 10, dialogHeight));

            GUI.Box(new Rect(0, 0, conversationTextWidth +displayTextureOffset + 10, dialogHeight),"");

            GUI.Label(new Rect(displayTextureOffset, 10, conversationTextWidth + 30, 20), currentConversationLine.SpeakingCharacterName);
            GUI.Label(new Rect(displayTextureOffset, 30, conversationTextWidth + 30, 20), currentText);
            //GUI.Label(new Rect(displayTextureOffset, 30, conversationTextWidth + 30, 20), currentConversationLine.ConversationText);
            //StartCoroutine(LetterByLetter(currentConversationLine.ConversationText));


            GUI.DrawTextureWithTexCoords(new Rect(10, 10, 50, 50), currentConversationLine.DisplayPic.texture, scaledTextureRect);

            GUI.EndGroup();
        }
    }

    public void StartConversation(Conversation conversation)
    {
        if (!talking)
        {
            StartCoroutine(DisplayConversation(conversation));
        }
    }
}
