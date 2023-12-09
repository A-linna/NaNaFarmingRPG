using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIInventoryTextBox : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMeshTop1;
    [SerializeField] private TextMeshProUGUI textMeshTop2;
    [SerializeField] private TextMeshProUGUI textMeshTop3;
    [SerializeField] private TextMeshProUGUI textMeshBottom1;
    [SerializeField] private TextMeshProUGUI textMeshBottom2;
    [SerializeField] private TextMeshProUGUI textMeshBottom3;

    public void SetTextBoxTex(String textTop1, String textTop2, String textTop3,
                    String textBottom1, String textBottom2, String textBottom3)
    {
        textMeshTop1.text = textTop1;
        textMeshTop2.text = textTop2;
        textMeshTop3.text = textTop3;
        textMeshBottom1.text = textBottom1;
        textMeshBottom2.text = textBottom2;
        textMeshBottom3.text = textBottom3;

    }

}
