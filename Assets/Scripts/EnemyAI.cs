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
    // Start is called before the first frame update
    void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (targetPlayer==true){
            setMoveDirection(new Vector3(Mathf.Clamp(player.position.x-transform.position.x,-1,1),moveDirection.y,moveDirection.z));
        }
        characterController.Move(moveDirection*Time.deltaTime*speed);
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
}
