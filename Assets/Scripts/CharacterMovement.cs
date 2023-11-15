using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    CharacterController controller;
    [SerializeField]
    [Range(1,10)]
    float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        controller.Move(new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"),0)*Time.deltaTime*moveSpeed);
    }
}
