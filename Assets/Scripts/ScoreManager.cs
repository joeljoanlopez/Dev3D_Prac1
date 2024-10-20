using UnityEngine;
using UnityEngine.InputSystem;

public class ScoreManager : MonoBehaviour
{
    public UIFillPercentage scoreBar;
    public float winScore = 1000f;

    private bool gameOver;
    private bool isSeen;

    private PlayerInput playerInput;
    private float score;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        score = 0;
        isSeen = false;
    }

    private void Update()
    {
        this.enabled = isSeen;

        score = Mathf.Clamp(score, 0f, winScore);
        scoreBar.UpdateAmount(score, winScore);

        if (isScoreReached())
        {
            gameOver = true;
            Debug.Log("YOU WIN! Press T to restart");
        }

        if (gameOver && playerInput.actions["Restart"].WasPressedThisFrame()) Restart();
    }

    private void Restart()
    {
        score = 0f;
    }

    public void AddScore(float amount)
    {
        if (isSeen)
        {
            score += amount;
        }
    }

    public bool isScoreReached()
    {
        return score >= winScore;
    }

    public void ShowScore()
    {
        isSeen = true;
    }

    public void HideScore()
    {
        isSeen = false;
    }
}