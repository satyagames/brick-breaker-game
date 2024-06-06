using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NameSaver : MonoBehaviour
{
    public TMP_InputField nameField;

    public void EnterName()
    {
        DataStuff.Instance.userName = nameField.text;
        DataStuff.Instance.SaveJason();
    }

}
