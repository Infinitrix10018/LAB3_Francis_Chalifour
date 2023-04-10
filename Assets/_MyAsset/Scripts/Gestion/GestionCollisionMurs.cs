using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionCollisionMurs : MonoBehaviour
{
    // variable qui permet de savoir si la l'objet est touché ou non.
    private bool _touche;

    // variable qui garde le temps pour remettreen jeu un obstacle
    private float _tempsTouche;

    //importation de l'objet jeu
    private GestionJeu _gestionJeu;


    // Start is called before the first frame update
    void Start()
    {
        //met la variable touche a non, car rien n'a été toucher au début de la partie
        _touche = false;

        // trouve l'objet gestionJeu et l'assosie a la variable.
        _gestionJeu = FindObjectOfType<GestionJeu>(); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        // system de détection de collision avec le joueur
        if (collision.gameObject.tag == "Player")
        {
            // si cela n'est pas toucher, faire le code
            if(!_touche)
            {
                //augmente le pointage après une collision valide
                _gestionJeu.AugmenterPointage();

                // enregistre le temps de remise en jeu.
                _tempsTouche = Time.time;
                _tempsTouche += 4;
                // met l'objet comme étant hors jeu
                _touche = true;
                // change la couleur de l'objet
                GetComponent<MeshRenderer>().material.color= Color.red;


            }
        }
    }


    private void FixedUpdate()
    {
        // si l'obstacle est toucher, fait le code si dessous
        if(_touche )
        {
            //remet l'obstacle en jeu après 4 secondes
            if ( _tempsTouche == Time.time)
            {   
                _touche= false;
                //met la couleur jaune pour dire que l'objet a deja été toucher
                GetComponent<MeshRenderer>().material.color = Color.yellow;
            }
        }
    }
}
