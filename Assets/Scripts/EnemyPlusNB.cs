using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlusNB : MonoBehaviour
{
    public Move2D move2D; // Referência ao script Move2D do jogador
    public bool isFlipped = false;
    private SpriteRenderer spriteRenderer;

    private EnemyNightBorne enemy;

    void Start()
    {
        enemy = GetComponent<EnemyNightBorne>();
        // Encontre o jogador (Player) dentro da cena
        GameObject playerObject = GameObject.FindWithTag("Player");
        if (playerObject != null)
        {
            // Obtenha o componente Move2D do jogador
            move2D = playerObject.GetComponent<Move2D>();
        }
        else
        {
            Debug.LogError("Jogador não encontrado na cena com a tag 'Player'!");
        }

        // Obtenha o componente SpriteRenderer do inimigo
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (move2D != null)
        {
            LookAtPlayer();
        }
    }

    public void LookAtPlayer()
    {
        // Direção do inimigo em relação ao jogador
        float directionToPlayer = move2D.transform.position.x - transform.position.x;

        // Verifique se o inimigo precisa mudar a orientação
        if (directionToPlayer > 0 && isFlipped && enemy.isAlive == true || directionToPlayer < 0 && !isFlipped && enemy.isAlive == true)
        {
            // Inverte a orientação do inimigo
            FlipEnemy();
        }
    }

    private void FlipEnemy()
    {
        // Inverte a escala no eixo X para virar o sprite do inimigo
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;

        // Atualiza o estado de isFlipped para refletir a nova orientação
        isFlipped = !isFlipped;
    }
}
