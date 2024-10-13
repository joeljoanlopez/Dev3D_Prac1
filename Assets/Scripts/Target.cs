using UnityEngine;

public class Target : MonoBehaviour
{
    public bool canDie = true;
    public float health = 50f;
    public float points = 10f;

    public void TakeDamage(float amount, GameObject source)
    {
        var scoreManager = source.GetComponent<ScoreManager>();
        if (scoreManager != null)
        {
            scoreManager.AddScore(points);
        }


        if (health <= 0f && canDie)
        {
            health -= amount;
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}