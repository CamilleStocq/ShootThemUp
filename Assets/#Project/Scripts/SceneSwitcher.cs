using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] private string sceneName; // nom de la scene ou on veut switch

    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(SwitchScene); // quand on appuie sur le bouton, on switch de scene
    }
    
    public void SwitchScene()
    {
        SceneManager.LoadScene(sceneName); // change la scene
    }
}
