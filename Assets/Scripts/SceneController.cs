using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public SceneAsset sceneAsset;
    private string sceneName;
    private void OnValidate()
    {
        if (sceneAsset != null)
        {
            sceneName = sceneAsset.name;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!string.IsNullOrEmpty(sceneName))
        {

            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("Scene name is not set, maybe you need to assign a scene in the editor");
        }
    }
}
