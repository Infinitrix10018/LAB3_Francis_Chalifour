using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionVehicule : MonoBehaviour
{
    //Les listes pour les gameObject et les MeshRenderer
    [SerializeField] private List<GameObject> _listeComposant = new List<GameObject>();
    [SerializeField] private List<MeshRenderer> _listeMeshRenderer = new List<MeshRenderer>();

    //variable pour si l'objet et toucher et son temps 
    private bool _touche;
    private float _tempsTouche;
    // creation de variable GestionJeu
    private GestionJeu _gestionJeu;


    // Start is called before the first frame update
    void Start()
    {
        //initialisation variable GestionJeu
        _gestionJeu = FindObjectOfType<GestionJeu>();
        // permettre que chaques piège soit ajouté a la liste des pièges. 
        foreach (var piege in _listeComposant)
        {
            //Ajoute tous les MeshRenderer dans la liste pour pouvoir les modifier quand cela sera neccéssaire
            _listeMeshRenderer.Add(piege.GetComponent<MeshRenderer>());
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        // si la collision est fait par un joueuer, la gestion des collision est éffectuer
        if (collision.gameObject.tag == "Player")
        {
            //si la variable n'est pas toucher
            if (!_touche)
            {
                //augmente le pointage par 1
                _gestionJeu.AugmenterPointage();
                //met le temps de retour en jeu
                _tempsTouche = Time.time;
                _tempsTouche += 4;
                //fait que l'objet est toucher
                _touche = true;

                foreach (var mesh in _listeComposant)
                {
                    //change la couleur des meshRenderer à rouge
                    mesh.GetComponent<MeshRenderer>().material.color = Color.red;
                    //GetComponent<MeshRenderer>().material.color = Color.red;
                }

            }
        }
    }

    private void FixedUpdate()
    {
        //remet l'obstacle en jeu après 4 secondes
        if (_touche)
        {
            if (_tempsTouche == Time.time)
            {
                //remet l'obstacle en jeu.
                _touche = false;
                foreach (var mesh in _listeComposant)
                {
                    //Met la couleur du MeshRenderer a jaune
                    mesh.GetComponent<MeshRenderer>().material.color = Color.yellow;
                    //GetComponent<MeshRenderer>().material.color = Color.red;
                }
            }
        }
    }
    }
