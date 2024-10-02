using UnityEngine;

public class Target : MonoBehaviour
{

    public bool canDie = true;
    public float health = 50f;
    public float points = 10f;

    public void TakeDamage(float amount, GameObject source)
    {
        if (health <= 0f && canDie)
        {
            health -= amount;
            Die();
        }

        ScoreController scoreController = source.GetComponent<ScoreController>();
        if (scoreController != null)
        {
            scoreController.AddPoints(points);
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}