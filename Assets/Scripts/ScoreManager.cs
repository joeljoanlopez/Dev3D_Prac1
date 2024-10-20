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
        score = Mathf.Clamp(score, 0f, winScore);
        scoreBar.UpdateAmount(score, winScore);

        if (score >= winScore)
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
        score += amount;
    }

    public bool isScoreReached()
    {
        return score >= winScore;
    }
}