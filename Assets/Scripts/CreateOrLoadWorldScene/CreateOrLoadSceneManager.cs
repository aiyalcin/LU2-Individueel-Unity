using UnityEngine;
using UnityEngine.SceneManagement;
public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnCreateButtonPressed()
    {
        
    }

    public void OnLoadButtonPressed()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnLogOutButtonPressed()
    {

    }
}
