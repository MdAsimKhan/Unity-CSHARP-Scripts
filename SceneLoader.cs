using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public string scene;
    private UnityAction ev;
    void Start()
    {
        Button button = gameObject.GetComponent<Button>();
        if(string.IsNullOrEmpty(scene)) ev = ReloadScene;
        else ev = LoadScene;
        button.onClick.AddListener(ev);
    }

    void LoadScene()
    {
        SceneManager.LoadScene(scene);
    }
    void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
