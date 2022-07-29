using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonEvents : MonoBehaviour
{
    [Header("TMPro components")]
    public TextMeshProUGUI Info_text;
    [Header("GameObjects")]
    public GameObject Button_play;
    public GameObject Button_exit, Button_info, Button_back;
    public void Info_Click()
    {
        Button_play.SetActive(false);
        Button_exit.SetActive(false);
        Button_info.SetActive(false);

        Button_back.SetActive(true);
        Info_text.gameObject.SetActive(true);
    }
    public void Back_Click()
    {
        Button_play.SetActive(true);
        Button_exit.SetActive(true);
        Button_info.SetActive(true);

        Button_back.SetActive(false);
        Info_text.gameObject.SetActive(false);
    }

    public void Exit_Click()
    {
        Application.Quit();
    }
}
