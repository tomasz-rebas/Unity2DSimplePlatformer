using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticDoors : MonoBehaviour
{
    public Transform door;
    public float offsetY = 4.5f;
    public float openingSpeed = 15f;

    private bool isPlayerInsideTrigger;
    private Vector2 openedDoorPosition;
    private Vector2 closedDoorPosition;

    void Start ()
    {
        openedDoorPosition = new Vector2 (door.position.x, door.position.y + offsetY);
        closedDoorPosition = door.position;
    }

    void Update ()
    {
        if (isPlayerInsideTrigger && door.position.y != openedDoorPosition.y)
        {
            door.position = Vector2.MoveTowards 
                            (
                                door.position,
                                openedDoorPosition,
                                openingSpeed * Time.deltaTime
                            );
        }
        else if (!isPlayerInsideTrigger && door.position.y != closedDoorPosition.y)
        {
            door.position = Vector2.MoveTowards 
                            (
                                door.position,
                                closedDoorPosition,
                                openingSpeed * Time.deltaTime
                            );
        }
    }

    void OnTriggerEnter2D (Collider2D c)
    {
        if (c.gameObject.name == "Player")
        {
            isPlayerInsideTrigger = true;
        }
    }

    void OnTriggerExit2D (Collider2D c)
    {
        if (c.gameObject.name == "Player")
        {
            isPlayerInsideTrigger = false;
        }
    }
}
