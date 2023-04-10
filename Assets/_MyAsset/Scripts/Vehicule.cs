using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicule : MonoBehaviour
{
    //Initialise la vitesse et la direction  du vehicule et permet de le modifier individuelement dans Unity directement.
    [SerializeField] private float _vitesse = 400.0f;
    [SerializeField] private float _direction_x = 4.0f;
    [SerializeField] private float _direction_y = 0f;
    [SerializeField] private float _direction_z = 0f;

    //import le RigidBody
    private Rigidbody _rb;

    //boolean qui permet de savoir si le vehicule va vers la direction dessus ou dans le contraire.
    private bool _positif;

    //boolean qui permet de savoir si le mouvement du vehicule est activé
    public bool _active = false;

    private void Start()
    {
        //initialisation du RigidBody
        _rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Si le vehicule touche un mur, le vehicule change de direction
        if (collision.gameObject.tag == "Walls")
        {
            ChangeDirection();
        }
    }

    private void FixedUpdate()
    {
        //Initialise le mouvement du vehicule
        Vector3 mouvement = new Vector3(_direction_x, _direction_y, _direction_z);

        // le mouvement des véhicules si le vehicule est activé.
        if (_active && _positif)
        {
            _rb.velocity = mouvement * Time.fixedDeltaTime * _vitesse;
        }
        else if (_active && !_positif)
        {
            _rb.velocity = mouvement * Time.fixedDeltaTime * _vitesse * -1;
        }

    }

    // methode pour les faire changer de direction de mouvement.
    public void ChangeDirection()
    {
        if (_positif)
        {
            _positif = false;
        }
        else
            _positif = true;
    }

    //methode qui permet d'active le mouvement du vehicule
    public void Active()
    {
        _active = true;
    }

}
