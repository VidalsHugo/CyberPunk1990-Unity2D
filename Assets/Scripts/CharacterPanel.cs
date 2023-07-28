using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterPanel : MonoBehaviour
{
    [SerializeField] GameObject transparentPanel;
    [SerializeField] bool showTransParentPanel = false;
    [SerializeField] Image charImage;
    [SerializeField] TMP_Text nameText;

    void Start()
    {
        transparentPanel.SetActive(showTransParentPanel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal void UpdateCharacterPanel(CharacterStats characterStats){

        if(characterStats == null){
            charImage.sprite = null;
            nameText.SetText("");
            
        }else{
            //atualizar sprite
            charImage.sprite = characterStats.face;
            //atualizar nome
            nameText.SetText(characterStats.charName);
        }

    }
}
