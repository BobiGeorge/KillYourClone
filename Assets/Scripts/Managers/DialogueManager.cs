using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueBox;
    public TMP_Text nameBox;
    public TMP_Text textBox;
    public Image imageBox;

    private string[,] dialogue;
    private int dialoguePosition;
    private Dictionary<string, Sprite> characterImages = new Dictionary<string, Sprite>();

    public UnityEvent dialogueEnd;

    public void AddCharacterImage(string name, Sprite image)
    {
        characterImages.Add(name, image);

        
    }

    public void LoadSceneDialogue(string[,] dialogue)
    {
        this.dialogue = dialogue;
    }

    public void DisplayDialogue()
    {
        if (dialoguePosition == dialogue.GetLength(0))
        {
            dialogueEnd.Invoke();
            return;
        }

        nameBox.text = dialogue[dialoguePosition, 0];
        textBox.text = dialogue[dialoguePosition, 1];
        //imageBox = characterImages[dialogue[dialoguePosition, 0]];
        imageBox.sprite = characterImages[dialogue[dialoguePosition, 0]];
        dialoguePosition += 1;

    }

    public void DisplayDialogueBox()
    {
        dialogueBox.SetActive(true);
    }

    public void HideDialogueBox()
    {
        dialogueBox.SetActive(false);
    }
}
