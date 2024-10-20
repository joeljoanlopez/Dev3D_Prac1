using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public string scene;
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(scene);
    }
}
