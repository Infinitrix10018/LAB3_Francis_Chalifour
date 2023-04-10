using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class zonePiege : MonoBehaviour
{
    //permet d'activer le piege qu'une seul fois
    private bool _activated = false;

    //l'intensité de la force des objets
    [SerializeField] private float _intensiteForce = 5;

    //liste des gameObjects, rigidBodys et les vehicules
    [SerializeField] private List<GameObject> _listePiege = new List<GameObject>();
    [SerializeField] private List<Rigidbody> _listeRigidBody = new List<Rigidbody>();
    [SerializeField] private List<Vehicule> _listeVehicule = new List<Vehicule>();

    //importation de vehicule
    private Vehicule _vehicule;

    // Start is called before the first frame update
    void Start()
    {
        //initialise le vehicule
        _vehicule = FindObjectOfType<Vehicule>();
        // permettre que chaques piège soit ajouté a la liste des pièges. 
        foreach (var piege in _listePiege)
        {
            _listeVehicule.Add(piege.GetComponent<Vehicule>());
            _listeRigidBody.Add(piege.GetComponent<Rigidbody>());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Prend le numéro de scene actuel
        int noScene = SceneManager.GetActiveScene().buildIndex;
        // permet d'activé la gratité des pièges si le joueur va dans la zone et que la zone n'est pas déja activée.
        //Si c'est dans la scene 1, alors cela va activé les vehicules
        if ( noScene != 1)
        {
            if (other.gameObject.tag == "Player" && !_activated)
            {
                Vector3 direction = new Vector3(-3f, -10f, 0f);

                foreach (var rb in _listeRigidBody)
                {
                    rb.useGravity = true;
                    rb.AddForce(direction * _intensiteForce);
                }

                _activated = true;
            }
        }
        else if( noScene== 1)
        {
            if (other.gameObject.tag == "Player" && !_activated)
            {
                foreach (var vehicule in _listeVehicule)
                {
                    vehicule.Active();
                }

                _activated = true; _vehicule.Active();
            }
           
        }

    }
}
