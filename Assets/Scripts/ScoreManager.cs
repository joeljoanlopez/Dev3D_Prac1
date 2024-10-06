using UnityEngine;
using UnityEngine.InputSystem;

public class ScoreManager : MonoBehaviour
{
    public UIFillPercentage scoreBar;
    public float winScore = 1000f;
    private float score = 0f;
    private bool gameOver = false;

#if UNITY_EDITOR
    private PlayerInput playerInput;
#endif

    private void Start()
    {
        scoreBar.UpdateAmount(score, winScore);

#if UNITY_EDITOR
        playerInput = GetComponent<PlayerInput>();
#endif
    }

    private void Update()
    {
        score = Mathf.Clamp(score, 0f, winScore);

        if (score >= winScore)
        {
            gameOver = true;
            Debug.Log("YOU WIN! Press T to restart");
        }

        if (gameOver && playerInput.actions["Restart"].WasPressedThisFrame())
        {
            Restart();
        }

#if UNITY_EDITOR
        if (playerInput.actions["AddScore"].WasPressedThisFrame()){
            AddScore(10f);
        }
#endif
    }

    private void Restart()
    {
        score = 0f;
    }

    public void AddScore(float amount)
    {
        score += amount;
        scoreBar.UpdateAmount(score, winScore);
    }

}