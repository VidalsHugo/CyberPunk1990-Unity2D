using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public Transform pauseMenu;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(pauseMenu.gameObject.activeSelf){
                pauseMenu.gameObject.SetActive(false);
                Cursor.visible = false;
                Debug.Log("DesPause");
                Time.timeScale = 1;
            }else{
                pauseMenu.gameObject.SetActive(true);
                Cursor.visible = true;
                Debug.Log("Pause");
                Time.timeScale = 0;
            }
        }
    }

    public void ResumeGame(){
        pauseMenu.gameObject.SetActive(false);
        Cursor.visible = false;
        Time.timeScale = 1;
    }
    public void ReturnSelectionCharacter(){
        Cursor.visible = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    public void Exit(){
        Application.Quit();
        Debug.Log("Is EXIT");
    }
}
