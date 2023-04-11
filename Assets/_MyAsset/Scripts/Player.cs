using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Player : MonoBehaviour
{
    // variable qui permet de changer la vitesse dans l'�diteur
    [SerializeField] private float _vitesse = 400.0f;

    //importation du rigidBody
    private Rigidbody _rb;
    private GestionJeu _gestionJeu;

    private bool _debutTemps = false;

    // Start is called before the first frame update
    void Start()
    {
        // position initial du joueur
        transform.position = new Vector3(45f, 0.02f, 45f);

        //initialisation du rigidBody
        _rb = GetComponent<Rigidbody>();
        _gestionJeu = FindObjectOfType<GestionJeu>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //appelle fonction de mouvement du joueur
        MouvementJoueur();
    }

    private void MouvementJoueur()
    {
       

            //avoir les positions verticals et horizontal
            float positionX = Input.GetAxis("Horizontal");
            float positionZ = Input.GetAxis("Vertical");
            // faire que la direction soit celle des coordonn�es donn� ci-dessus
            Vector3 direction = new Vector3(-positionX, 0f, -positionZ); // le mouvement �tait invers�, probablement un probl�me avec probuilder.
            //mouvement du joueur
            if(!_debutTemps)
               {
                if(positionX != 0f | positionZ != 0f)
                {
                _gestionJeu.setTemps();
                _debutTemps = true;
                }
            }

            _rb.velocity = direction * Time.fixedDeltaTime * _vitesse;
            //normalisation du mouvement, potentiellement* � enlev�
            direction.Normalize();
    }
    //méthode qui permet de finir la partie (désactive le joueur)
    public void finPartieJoueur()
    {
        gameObject.SetActive(false);
    }
}
