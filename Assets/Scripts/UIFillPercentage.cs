using UnityEngine.UI;
using UnityEngine;

public class UIFillPercentage : MonoBehaviour
{
    public Image image;
    public Text text;

    public void UpdateAmount(float amount, float maxAmount)
    {
        amount = Mathf.Clamp(amount, 0f, maxAmount);
        text.text = amount.ToString();
        image.fillAmount = amount / 100f;
    }
}