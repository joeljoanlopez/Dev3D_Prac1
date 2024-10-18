using UnityEngine;

public class ScoreController : MonoBehaviour {
    public float points = 0f;
    
    public void AddPoints(float amount) {
        points += amount;
    }
}