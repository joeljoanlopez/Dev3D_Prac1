using UnityEngine.UI;
using UnityEngine;

public class UIFillPercentage : MonoBehaviour
{
    public Image image;

    public void UpdateAmount(float amount)
    {
        image.fillAmount = amount;
    }
}