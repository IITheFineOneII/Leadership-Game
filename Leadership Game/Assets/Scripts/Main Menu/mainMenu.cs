using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public void PlayGame () // Function
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // Current scene + 1 to get to the new scene
    }

    public void QuitGame() // Function
    {
        Debug.Log("QUIT!"); // Debug to check if it works
        Application.Quit(); // Quits the application when built
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
