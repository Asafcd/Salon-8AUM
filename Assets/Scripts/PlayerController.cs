using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    private Material material;
    [Header("Movement")]
    [SerializeField] private float speed;
    private Rigidbody rb;
    private float posX;
    private float posZ;
    private Vector3 movement;

    [Header("Jump")]
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask layer;
    [SerializeField] private bool isCollider;
    private Collider col;
    private float camRayDistance = 1000f;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        meshRenderer = GetComponent<MeshRenderer>();
        material = meshRenderer.material;
    }
    private void FixedUpdate() {
        
    }
    void Start()
    {
        
    }


    void Update()
    {
      Move();
      Jump();
      Turning();
      Fallen();
    }

    private void Move()
    {
      posX = Input.GetAxis("Horizontal");
      posZ = Input.GetAxis("Vertical");
      movement.Set(posX, 0, posZ);
      movement = movement.normalized * speed * Time.deltaTime;
      rb.MovePosition(transform.position + movement); 
    }

    private void Fallen(){
      if (transform.position.y < -10)
      {
        transform.position = new Vector3(0, 0, 0);
        material.color = Color.green;
        meshRenderer.material = material;
        
      }
    }

    private void Jump()
    {
      RaycastHit hit;
      isCollider = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 2f,layer);
      Debug.DrawRay(transform.position,transform.TransformDirection(Vector3.down) * hit.distance, Color.black);
      if (Input.GetKeyDown(KeyCode.Space) && isCollider)
      {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
      }
    }

    private void Turning()
    {
      Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
      RaycastHit floorhit;
      if(Physics.Raycast(camRay, out floorhit, camRayDistance, layer))
      {
        Vector3 PlayerToMouse = floorhit.point - transform.position;
        PlayerToMouse.y = 0;

        Quaternion newRotation = Quaternion.LookRotation(PlayerToMouse);
        rb.MoveRotation(newRotation);
      }

    }
}
