using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public void Click()
    {
        if (SceneManager.GetActiveScene().name == "Menu_scene")
        {
            SceneManager.LoadScene("Game_scene", LoadSceneMode.Single);
        }
        else
        {
            SceneManager.LoadScene("Menu_scene", LoadSceneMode.Single);
        }

    }
}
