using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
    public GameObject dialogPanel;

    public TextMeshProUGUI dialogText;

    public bool isDialogActive;

    [TextArea]
    public string[] dialogLines;

    public int currnetDialogLine;

    private void Start()
    {
        HideDialog();    
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isDialogActive)
        {
            currnetDialogLine++;
            if(currnetDialogLine >= dialogLines.Length)
            {
                HideDialog();
            }
            else
            {
                dialogText.text = dialogLines[currnetDialogLine];
            }
        }
    }

    public void ShowDialog(string[] s)
    {
        currnetDialogLine = 0;

        dialogLines = s;

        isDialogActive = true;

        dialogPanel.SetActive(isDialogActive);

        dialogText.text = dialogLines[currnetDialogLine];
    }

    public void HideDialog()
    {
        isDialogActive = false;

        dialogPanel.SetActive(isDialogActive);
    }
}
