using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIScript : MonoBehaviour
{
    public Text coinCount, gameOverText;
    public Button tryAgain, returnMenu;
    public void UpdateScore(int coinAmount)
    {
        coinCount.text = "Toplanan Altýn: " + coinAmount;
    }

    public void ShowGameOverButtons(bool control)
    {
        tryAgain.gameObject.SetActive(control);
        returnMenu.gameObject.SetActive(control);
        gameOverText.gameObject.SetActive(control); 
    }
}
