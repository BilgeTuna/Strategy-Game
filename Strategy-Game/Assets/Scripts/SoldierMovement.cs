using Cinemachine;
using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SoldierMovement : MonoBehaviour
{
    public Animator anim;
    public float rotationSpeed = 5f;
    public bool turnRight = true;

    private Seeker seeker;
    private Path path;
    private int currentWaypoint = 0;
    private bool isMoving = false;
    private bool movingRight = true;
    private GameObject selectedGameObject;

    private void Start()
    {
        seeker = GetComponent<Seeker>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            seeker.StartPath(transform.position, mousePosition, OnPathComplete);
            isMoving = true;
        }

        if (isMoving)
        {
            anim.SetBool("isWalinkg", true);

            if (path == null)
            {
                return;
            }

            if (currentWaypoint >= path.vectorPath.Count)
            {
                isMoving = false;
                return;
            }

            Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - (Vector2)transform.position).normalized;
            transform.position += (Vector3)direction * Time.deltaTime * 5f;

            // Check for left/right movement and log a message
            if (direction.x > 0 && !movingRight)
            {
                transform.GetComponent<SpriteRenderer>().flipX = false;
                movingRight = true;
            }
            else if (direction.x < 0 && movingRight)
            {
                transform.GetComponent<SpriteRenderer>().flipX = true;
                movingRight = false;
            }

            if (Vector2.Distance(transform.position, path.vectorPath[currentWaypoint]) < 0.1f)
            {
                currentWaypoint++;
            }
        }
        else if (!isMoving) anim.SetBool("isWalinkg", false);
    }

    private void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
}
