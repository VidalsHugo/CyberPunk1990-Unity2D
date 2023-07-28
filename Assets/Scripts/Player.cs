using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    // [Header("Movement Properties")]
    // public float speed = 6.7f;
    // public float jumpForce = 6.7f;



    // [Header("Ground Properties")]
    // public LayerMask groundLayer;
    // public float groundDistance;
    // public bool isGrounded;
    // public Vector3[] footOffset;

    // //Verifica se o personagem esta tocando solo ...
    // RaycastHit2D leftCheck;
    // RaycastHit2D rightCheck;

    // //Movimentacao
    // private bool isJump;
    // private Rigidbody2D rb2d;
    // private Animator animator;
    // private Vector2 movement;
    // private float xVelocity;
    // private int direction = 1;
    // private float originalXScale;
    // private bool isFire;



    // // Start is called before the first frame update
    // void Start()
    // {
    //     rb2d = GetComponent<Rigidbody2D>();
    //     animator = GetComponent<Animator>();
    //     originalXScale = transform.localScale.x;

    // }

    // // Update is called once per frame
    // void Update()
    // {

    //     PhysicsCheck();

    //     if(Input.GetAxis("Horizontal") != 0 ){
    //         //esta correndo
    //         animator.SetBool("punkRun", true);
    //     }else{
    //         //esta parado
    //         animator.SetBool("punkRun", false);

    //     }

    //     if(isFire == false){
    //         float horizontal = Input.GetAxisRaw("Horizontal");
    //         movement = new Vector2(horizontal, 0);

    //         if(xVelocity*direction < 0f){
    //         Flip();
    //     }
    // }

    //     if(Input.GetButtonDown("Jump") && isGrounded){
    //         rb2d.velocity = Vector2.zero;
    //         rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    //     }

    //     if(Input.GetButtonDown("Fire1") && isFire == false && isGrounded){
    //         movement = Vector2.zero;
    //         rb2d.velocity = Vector2.zero;
    //         animator.SetTrigger("fire");
    //     }

    // }

    // private void FixedUpdate(){
    //     if(isFire == false){
    //         xVelocity = movement.normalized.x * speed;
    //         rb2d.velocity = new Vector2(xVelocity, rb2d.velocity.y);
    //     }
        
    // }

    // private void LateUpdate(){
    //     //animator.SetTrigger("die);

    //     animator.SetFloat("xVelocity", Mathf.Abs(xVelocity));
    //     animator.SetBool("isGrounded", isGrounded);
    //     animator.SetFloat("yVelocity", rb2d.velocity.y);

    //     if(animator.GetCurrentAnimatorStateInfo(0).IsTag("fire")){
    //         isFire = true;
    //     }else{
    //         isFire = false;
    //     }
    // }

    // private void Flip(){
    //     direction *= - 1;
    //     Vector3 scale = transform.localScale;

    //     scale.x = originalXScale * direction;
    //     transform.localScale = scale;
    // }

    // private void PhysicsCheck(){
    //     isGrounded = false;
    //     leftCheck = Raycast(new Vector2(footOffset[0].x, footOffset[0].y), Vector2.down, groundDistance, groundLayer);
    //     rightCheck = Raycast(new Vector2(footOffset[1].x, footOffset[1].y), Vector2.down, groundDistance, groundLayer);

    //     if(leftCheck || rightCheck){
    //         isGrounded = true;
    //     }
    // }

    // private RaycastHit2D Raycast(Vector3 origin, Vector2 rayDirection, float length, LayerMask mask){
    //     Vector3 pos = transform.position;

    //     RaycastHit2D hit = Physics2D.Raycast(pos + origin, rayDirection, length, mask);
    //     //Se quisermos mostrar o raycast em cena

    //         Color color = hit ? Color.red : Color.green;

    //         Debug.DrawRay(pos + origin, rayDirection * length, color);
    //         //determina a cor baseado se o raycast se colidiu ou nao

    //         //retorna o resultado do hit
    //         return hit;
    // }



    

}
