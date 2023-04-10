using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinDeJeu : MonoBehaviour
{
    //variable qui indique si c'est la fin de la partie
    public bool _fin;

    //Importation des variable pour Player et GestionJeu
    private Player _player;
    private GestionJeu _gestionJeu;



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
            if (collision.gameObject.tag == "Player" && !_fin)
            {
               
                // récupére l'index de la scene
                int noScene = SceneManager.GetActiveScene().buildIndex;
                //récupére l'idex de la dernière scène
                int noSceneFinale = SceneManager.sceneCountInBuildSettings;
          
                // si au dernier niveau
                if (noScene == (SceneManager.sceneCountInBuildSettings -1)) 
                {
                    //fait faire le compte des points et du temps
                    _gestionJeu.setPoinage(noScene);

                    // Le messagew de fin avec le temps, le pointage et le temps total pour chaque niveau et le niveau final
                    Debug.Log("Bravo! Vous avez reussi!");
                    Debug.Log("Pour finir le premier niveau vous avez pris " + _gestionJeu._tableauPoint[0,0] + " secondes et vous avez accrocher " + _gestionJeu._tableauPoint[0, 1] + " obstacle(s), pour un temps total de " + _gestionJeu._tableauPoint[0, 2] + "secondes");
                    Debug.Log("Pour finir le deuxième niveau vous avez pris " + _gestionJeu._tableauPoint[1, 0] + " secondes et vous avez accrocher " + _gestionJeu._tableauPoint[1, 1] + " obstacle(s), pour un temps total de " + _gestionJeu._tableauPoint[1, 2] + "secondes");
                    Debug.Log("Pour finir le troisième niveau vous avez pris " + _gestionJeu._tableauPoint[2, 0] + " secondes et vous avez accrocher " + _gestionJeu._tableauPoint[2, 1] + " obstacle(s), pour un temps total de " + _gestionJeu._tableauPoint[2, 2] + "secondes");
                    Debug.Log("Pour finir le jeu vous avez pris " + _gestionJeu._tableauPoint[3, 0] + " secondes et vous avez accrocher " + _gestionJeu._tableauPoint[3, 1] + " obstacle(s), pour un temps total de " + _gestionJeu._tableauPoint[3, 2] + "secondes");


                    //fini la partie
                    _fin = true; 
                    //Fait que le joueur est désactivé
                    _player.finPartieJoueur();
                }
                else
                {
                    //fait faire le calcul du pointage
                    _gestionJeu.setPoinage(noScene);
                    //Change la scene à la suivante
                    SceneManager.LoadScene(noScene + 1);
                }
            }
        }
}
