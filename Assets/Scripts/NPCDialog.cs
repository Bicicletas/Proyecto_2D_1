using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class NPCDialog : MonoBehaviour
{
    public string npcName;
    
    [TextArea]
    public string[] npcDialogLines;

    private DialogManager dialogManager;

    private bool isPlayerInDialogZone;

    private void Start()
    {
        dialogManager = FindObjectOfType<DialogManager>();
    }

    private void Update()
    {
        if(isPlayerInDialogZone && Input.GetMouseButton(1))
        {
            dialogManager.ShowDialog(DialogPlusNPCName());
        }
    }

    private string[] DialogPlusNPCName()
    {
        string[] finalDialog = new string[npcDialogLines.Length];

        for (int i = 0; i < npcDialogLines.Length; i++)
        {
            if (npcName != null)
            {
                finalDialog[i] = $"{npcName}\n\n{npcDialogLines[i]}";
            }
            else
            {
                finalDialog[i] = npcDialogLines[i];
            }
        }

        return finalDialog;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("Player"))
        {
            isPlayerInDialogZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("Player"))
        {
            isPlayerInDialogZone = false;
        }
    }
}
