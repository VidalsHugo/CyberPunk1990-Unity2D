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
    public string playerLayerName = "Player";

    void Awake()
    {
        int index = CharacterList.Instance.SelectedCharIndex;
        Vector3 position = new Vector3(-7.5f, -1.5f, 0f);

        GameObject newPlayer = Instantiate(player[index], position, Quaternion.identity);
        newPlayer.transform.localScale = new Vector3(8f, 8f, 1f);
        PlayerHP playerHP = newPlayer.AddComponent<PlayerHP>();
        Debug.Log("Player instanciado: " + index);

        newPlayer.layer = LayerMask.NameToLayer(playerLayerName);

        string materialPath = "Material/perso";
        Material newMaterial = Resources.Load<Material>(materialPath);
        if (newMaterial != null)
        {
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

        Animator animator = newPlayer.GetComponent<Animator>();
        if (animator == null)
        {
            animator = newPlayer.AddComponent<Animator>();
        }

        if (animatorControllers.Length > index && animatorControllers[index] != null)
        {
            animator.runtimeAnimatorController = animatorControllers[index];
        }
        else
        {
            Debug.LogError("Controlador de animações não encontrado para o índice: " + index);
        }

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
            Vector3 attackCheckPosition = newPlayer.transform.position + new Vector3(7.7f, 1.5f, 0f);
            attackCheckObject.transform.position = attackCheckPosition;
            attackCheckObject.transform.SetParent(newPlayer.transform, false);

            attackCheckObject.layer = LayerMask.NameToLayer(playerLayerName);
            move2D.attackCheck = attackCheckObject.transform;
            move2D.radiusAttack = 1.55f;
            move2D.layerEnemy = LayerMask.GetMask("Enemy");
        }
        else
        {
            Debug.LogError("Objeto 'AttackCheck' não encontrado como filho do objeto 'Player'!");
        }

        CinemachineVirtualCamera virtualCamera = GameObject.Find("Main Camera/Cinemachine").GetComponent<CinemachineVirtualCamera>();
        virtualCamera.Follow = newPlayer.transform;
        virtualCamera.m_Lens.OrthographicSize = zoomValue;

        Animator playerAnimator = newPlayer.GetComponent<Animator>();
        if (playerAnimator == null)
        {
            playerAnimator = newPlayer.AddComponent<Animator>();
        }

        if (playerHP != null)
        {
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
