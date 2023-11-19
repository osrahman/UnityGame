using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    Vector3 moveDirection;
    CharacterController characterController;
    [SerializeField]
    float damage = 25;
    [SerializeField]
    [Range(1,10)]
    float speed = 1;
    public bool targetPlayer = false;
    public Transform player;
    public Transform gameManager;
    //How many lives this enemy counts for. For example, a stronger enemy death could be a lifeCount of 2. This ends the wave quicker.
    public int lifeCount = 1;
    [SerializeField]
    public float health = 50;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        characterController = gameObject.GetComponent<CharacterController>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").transform;
        //50% chance to target player
        float x = Random.Range(0,1);
        if(x>.5){
            targetPlayer=true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (targetPlayer==true){
            setMoveDirection(new Vector3(Mathf.Clamp(player.position.x-transform.position.x,-1,1),moveDirection.y,moveDirection.z));
        }
        transform.position = transform.position + moveDirection*Time.deltaTime*speed;
        if(Input.GetKeyDown(KeyCode.X)){
            Damage(25);
        }
    }

    public void setMoveDirection(Vector3 dir){
        moveDirection = dir;
    }

    void OnCollisionEnter(Collision other){
        //If the enemy collides with the player, grab their health component and deal damage.
        if (other.gameObject.tag == "Player"){
            other.gameObject.GetComponent<Health>().Damage(damage);
        }
        if(other.gameObject.tag=="Base"){
            other.gameObject.GetComponent<Health>().Damage(damage);
        }
    }

    void Damage(float damage){
        health-=damage;
        if(health<0){
            Death();
        }
    }
    void Death(){
        gameManager.GetComponent<Waves>().EnemyDied(lifeCount);
        Destroy(gameObject);
    }
}
