using UnityEngine;
using UnityEngine.SceneManagement;

public class StartNewGame : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("Flappy Bird");
    }
}
