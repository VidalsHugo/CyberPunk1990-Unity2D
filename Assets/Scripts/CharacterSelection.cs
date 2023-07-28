using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField] CharacterPanel characterPanelLeft;
    [SerializeField] CharacterPanel characterPanelRight;
    [SerializeField] CharacterPanel characterPanelMiddle;
    // Start is called before the first frame update
    void Start()
    {
        CharacterList.Instance.SelectedCharIndex = 0;
        UpdateCharacterPanels();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)){
            CharacterList.Instance.SelectedCharIndex--;
            Debug.Log("Left");
            UpdateCharacterPanels();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)){
            CharacterList.Instance.SelectedCharIndex++;
            Debug.Log("Right");
            UpdateCharacterPanels();
        }
        //ENTER
        if(Input.GetKeyDown(KeyCode.Return)){
            FindObjectOfType<CharacterList>().SelectedCharIndex = CharacterList.Instance.SelectedCharIndex;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log("Choice " + CharacterList.Instance.SelectedCharIndex);
        }
    }
    private void UpdateCharacterPanels(){
        characterPanelLeft.UpdateCharacterPanel(CharacterList.Instance.GetPrevious());
        characterPanelMiddle.UpdateCharacterPanel(CharacterList.Instance.currentCharacter);
        characterPanelRight.UpdateCharacterPanel(CharacterList.Instance.GetNext());
    }
}
