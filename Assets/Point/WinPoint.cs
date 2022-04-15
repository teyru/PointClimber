using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPoint : MonoBehaviour
{
    private PlayerMovement player;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    private void Update()
    {
        
        if (player.WinPointReached)
        {
            ReloadLevel();
        }
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
}
