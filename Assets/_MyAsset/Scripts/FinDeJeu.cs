using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinDeJeu : MonoBehaviour
{
    //variable qui indique si c'est la fin de la partie
    //public bool _fin;

    //Importation des variable pour Player et GestionJeu
    private Player _player;
    private GestionJeu _gestionJeu;

    //[SerializeField] private TMP_Text _txtTemps = default;
    //[SerializeField] private TMP_Text _txtAccrochage = default;
    //[SerializeField] private TMP_Text _txtTempsFinal = default;



    // Start is called before the first frame update
    void Start()
    {
        //initiallisation des variable pour Player et GestionJeu
        _gestionJeu = FindObjectOfType<GestionJeu>(); 
        _player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        //permet de quiter le jeu avec la touche escape
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

        private void OnCollisionEnter(Collision collision)
        {
        
        //Gestion de la fin du jeu
            if (collision.gameObject.tag == "Player")
            {Debug.Log("toucher");
               
                // récupére l'index de la scene
                int noScene = SceneManager.GetActiveScene().buildIndex;
                //récupére l'idex de la dernière scène
                int noSceneFinale = SceneManager.sceneCountInBuildSettings;
          
                // si au dernier niveau
                if (noScene == (SceneManager.sceneCountInBuildSettings -2)) 
                {
                    //fait faire le compte des points et du temps

                    //_gestionJeu.setPoinage(noScene);

                    //fini la partie
                    //_fin = true; 
                    //Fait que le joueur est désactivé
                    _player.finPartieJoueur();
                    //aller à la dernière scene
                    SceneManager.LoadScene(noScene + 1);
                }
                else
                {
                    //fait faire le calcul du pointage

                    //_gestionJeu.setPoinage(noScene);

                    //Change la scene à la suivante
                    SceneManager.LoadScene(noScene + 1);
                }
            }
        }
}
