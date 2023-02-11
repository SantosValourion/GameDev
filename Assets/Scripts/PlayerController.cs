using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 0.5f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;
    Vector2 movementInput;
    Rigidbody2D rb;
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    private List<GameObject> objectsList = new List<GameObject>();
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate() 
    {
        if(movementInput != Vector2.zero)
        {
            bool success = TryMove(movementInput);

            if(!success){
                success = TryMove(new Vector2(movementInput.x, 0));

                if(!success) {
                    success = TryMove(new Vector2(0, movementInput.y));
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Door")){
            objectsList.Add(collision.gameObject);
        }
        if(collision.gameObject.CompareTag("NPC")){
            objectsList.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Door")){
            objectsList.Remove(collision.gameObject);
        }
        if(collision.gameObject.CompareTag("NPC")){
            objectsList.Remove(collision.gameObject);
        }
    }
    private bool TryMove(Vector2 direction)
    {
        int count = rb.Cast(
                movementInput,
                movementFilter,
                castCollisions,
                moveSpeed * Time.fixedDeltaTime + collisionOffset);
            if(count == 0)
            {
                rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
                return true;
            } else {
                return false;
            }
    }

    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }

    void OnInteract(){
    if(objectsList.Count != 0){
        GameObject first = objectsList[0];
        switch(first.tag){
            case "Door":
                GameEvents.current.DoorTrigger();
                break;
            case "NPC":
                GameEvents.current.DialogueTrigger();
                break;
            default:
                break;
            }
        }
    }
}
