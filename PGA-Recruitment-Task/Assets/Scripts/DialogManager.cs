using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public GameObject dialogBox;

    public TMP_Text mainText;
    public TMP_Text button1Text;
    public TMP_Text button2Text;
    public TMP_Text mergedButtonText;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;

    public void ShowDialogBox(string _mainText, int buttonAmount, string _button1Text, string _button2Text = "")
    {
        dialogBox.SetActive(true);
        mainText.text = _mainText;
        if (buttonAmount == 1)
        {
            button1.SetActive(false);
            button2.SetActive(false);
            button3.SetActive(true);
            mergedButtonText.text = _button1Text;
        }
        else if (buttonAmount == 2)
        {
            button1.SetActive(true);
            button2.SetActive(true);
            button3.SetActive(false);
            button1Text.text = _button1Text;
            button2Text.text = _button2Text;
        }
    }
}
