using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public int fireDmg = 20;
    public float fireRate = 0.15f;
    public float fireRange = 100f;
    [SerializeField] private float time;
    private Ray disparoRay;
    private RaycastHit disparoHit;
    private int disparableMask;
    private LineRenderer disaproLine;
    private PlayerController _player;
    
    void Awake()
    {
        disparableMask = LayerMask.GetMask("disparable");
        disaproLine = GetComponent<LineRenderer>();
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    void Start()
    {
        
    }
    void Update()
    {
        time += Time.deltaTime;
        if(Input.GetButton("Fire1") && time >= fireRate)
        {
            StartCoroutine(Disparo());
        }

        if(time >= fireRate * 0.2f)
        {
            disaproLine.enabled = false;
        }
    }
    IEnumerator Disparo()
    {
        time = 0;

        yield return new WaitForSeconds(0.2f);

        disaproLine.enabled = true;
        disaproLine.SetPosition(0, new Vector3(transform.position.x, transform.position.y, transform.position.z));
        disparoRay.origin = transform.position;
        disparoRay.direction = transform.forward;

        if(Physics.Raycast(disparoRay, out disparoHit, fireRange, disparableMask))
        {
            // Damage enemy
            VidaEnemigo vidaEnemigo = disparoHit.collider.GetComponent<VidaEnemigo>();
            if(vidaEnemigo != null)
            {
                vidaEnemigo.RecibirDmg(fireDmg, disparoHit.point);
            }
            disaproLine.SetPosition(1, disparoHit.point);
        } 
        else 
        {
            disaproLine.SetPosition(1, disparoRay.origin + disparoRay.direction * fireRange);
        }
    }
}
