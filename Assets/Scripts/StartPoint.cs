using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class StartPoint : MonoBehaviour
{
    public string uuid;

    private PlayerController player;

    private CinemachineConfiner2D _virtualCamera;

    [SerializeField] public Vector2 facingDirection;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        if (!player.nextUuid.Equals(uuid))
        {
            return;
        }
        player.transform.position = transform.position;
        player.lastDirection = facingDirection;

        GameObject confiner = GameObject.Find("Camera Confiner");

        if (confiner != null)
        {
            FindObjectOfType<CinemachineConfiner2D>().m_BoundingShape2D
            = confiner.GetComponent<PolygonCollider2D>();
        }
    }
}
