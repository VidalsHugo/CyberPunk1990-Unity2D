// using UnityEngine;

// public class HealthBar : MonoBehaviour
// {
//     public Transform player; // Referência ao jogador
//     public Vector3 offset;   // Deslocamento da barra em relação ao jogador
//     public float maxWidth = 5f; // Largura máxima da barra de vida
//     private float currentWidth; // Largura atual da barra de vida

//     private void Start()
//     {
//         currentWidth = maxWidth;
//     }

//     private void Update()
//     {
//         // Verifica se o jogador está vivo (você pode ajustar a condição com base no seu jogo)
//         if (player != null)
//         {
//             // Calcula a porcentagem de vida do jogador
//             float healthPercentage = player.GetComponent<PlayerController>().Health / player.GetComponent<PlayerController>().maxHealth;

//             // Atualiza a largura da barra de vida com base na porcentagem de vida do jogador
//             currentWidth = maxWidth * healthPercentage;

//             // Mantém a posição da barra de vida acima do jogador com o deslocamento definido
//             transform.position = Camera.main.WorldToScreenPoint(player.position + offset);
//         }
//         else
//         {
//             // Se o jogador não existir (por exemplo, morreu), desative a barra de vida
//             gameObject.SetActive(false);
//         }
//     }

//     private void OnGUI()
//     {
//         // Desenha a barra de vida na tela
//         GUI.Box(new Rect(transform.position.x - (maxWidth / 2), Screen.height - transform.position.y, currentWidth, 10), "");
//     }
// }
