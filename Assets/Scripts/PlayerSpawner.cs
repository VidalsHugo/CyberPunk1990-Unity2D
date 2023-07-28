using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject[] player;
    private Move2D move2D;
    public float zoomValue = 6.0f;
    public RuntimeAnimatorController[] animatorControllers;
    public string playerLayerName = "Player"; // Set this to "Player" in the Inspector

    void Awake()
    {
        int index = CharacterList.Instance.SelectedCharIndex;
        Vector3 position = new Vector3(-7.5f, -1.5f, 0f);

        GameObject newPlayer = Instantiate(player[index], position, Quaternion.identity);
        newPlayer.transform.localScale = new Vector3(8f, 8f, 1f);
        PlayerHP playerHP = newPlayer.AddComponent<PlayerHP>();
        Debug.Log("Player instanciado: " + index);

        // Set the layer of the player character
        newPlayer.layer = LayerMask.NameToLayer(playerLayerName);

        // Find the material in the "Materials" folder by its name
        string materialPath = "Material/perso";
        Material newMaterial = Resources.Load<Material>(materialPath);
        if (newMaterial != null)
        {
            // Find the SpriteRenderer component of the player and assign the new material
            SpriteRenderer spriteRenderer = newPlayer.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.material = newMaterial;
            }
            else
            {
                Debug.LogError("SpriteRenderer component not found on the player object.");
            }
        }
        else
        {
            Debug.LogError("Material 'perso' not found in the 'Material' folder.");
        }

        // Add the Animator component if it doesn't exist
        Animator animator = newPlayer.GetComponent<Animator>();
        if (animator == null)
        {
            animator = newPlayer.AddComponent<Animator>();
        }

        // Check if there is a corresponding animator controller for the current index
        if (animatorControllers.Length > index && animatorControllers[index] != null)
        {
            animator.runtimeAnimatorController = animatorControllers[index];
        }
        else
        {
            Debug.LogError("Controlador de animações não encontrado para o índice: " + index);
        }

        // Find the "DetectorDeChao" object within the "Player" object and assign it to the "detectaChao" variable
        move2D = newPlayer.GetComponent<Move2D>();
        GameObject detectorDeChaoObjeto = GameObject.Find("DetectorDeChao");
        GameObject attackCheckObject = GameObject.Find("AttackCheck");

        if (detectorDeChaoObjeto != null)
        {  
            Transform detectorDeChaoTransform = detectorDeChaoObjeto.transform;
            detectorDeChaoTransform.SetParent(newPlayer.transform, false);
            move2D.detectaChao = detectorDeChaoTransform;
            PositionBelowCharacter();
        }
        else
        {
            Debug.LogError("Objeto 'DetectorDeChao' não encontrado como filho do objeto 'Player'!");
        }

        if (attackCheckObject != null)
        {
            // Position the AttackCheck object to the center-right of the player character
            Vector3 attackCheckPosition = newPlayer.transform.position + new Vector3(7.7f, 1.5f, 0f);
            attackCheckObject.transform.position = attackCheckPosition;
            // Make the AttackCheck object a child of the player character
            attackCheckObject.transform.SetParent(newPlayer.transform, false);

            // Set the variables in the Move2D script
            attackCheckObject.layer = LayerMask.NameToLayer(playerLayerName);
            move2D.attackCheck = attackCheckObject.transform;
            move2D.radiusAttack = 1.55f;
            move2D.layerEnemy = LayerMask.GetMask("Enemy");
        }
        else
        {
            Debug.LogError("Objeto 'AttackCheck' não encontrado como filho do objeto 'Player'!");
        }

        // Get the Cinemachine virtual camera as a component directly from the "Main Camera" object
        CinemachineVirtualCamera virtualCamera = GameObject.Find("Main Camera/Cinemachine").GetComponent<CinemachineVirtualCamera>();
        virtualCamera.Follow = newPlayer.transform;
        virtualCamera.m_Lens.OrthographicSize = zoomValue;

        // Add the Animator component to the new player object, if it doesn't exist
        Animator playerAnimator = newPlayer.GetComponent<Animator>();
        if (playerAnimator == null)
        {
            playerAnimator = newPlayer.AddComponent<Animator>();
        }

        // Check if the PlayerHP script is present on the new player object
        if (playerHP != null)
        {
            // Assign the Animator of the new player object to the PlayerHP script
            playerHP.animator = playerAnimator;
        }
        else
        {
            Debug.LogError("Script 'PlayerHP' não encontrado no objeto 'Player'!");
        }
    }

    private void PositionBelowCharacter()
    {
        Vector3 positionBelowCharacter = move2D.transform.position - new Vector3(0f, 1.5f, 0f);
        move2D.detectaChao.position = positionBelowCharacter;
    }
}
