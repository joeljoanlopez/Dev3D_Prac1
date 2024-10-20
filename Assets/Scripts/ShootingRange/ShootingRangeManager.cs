using UnityEngine;

public class ShootingRangeManager : MonoBehaviour
{
    public GameObject scoreBar;
    private void OnTriggerEnter(Collider other)
    {
        scoreBar.SetActive(true);
        other.GetComponent<ScoreManager>().enabled = true;
    }

    private void OnTriggerExit(Collider other)
    {
        other.GetComponent<ScoreManager>().enabled = false;
        scoreBar.SetActive(false);
    }
}