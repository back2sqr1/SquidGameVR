using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public string sceneName;
    void Start()
    {
        sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // switch to the Passthrough scene and remove old scene
    public void PassthroughScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Passthrough");
        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(sceneName);
        sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
    }

    public void HapticsScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Haptics");
        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(sceneName);
        sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
    }

    public void InteractionScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Interaction");
        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(sceneName);
        sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
    }

    public void NavigationScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Navigation");
        UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(sceneName);
        sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
    }

}
