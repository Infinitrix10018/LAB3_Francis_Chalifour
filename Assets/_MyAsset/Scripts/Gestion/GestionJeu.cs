using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionJeu : MonoBehaviour
{   
    // tableau qui va avoir le temps, les points et le temps total.
    public float[,] _tableauPoint = new float[4,3];
    //variable qui permet d'enregistrer le nombre de point
    private int _pointage;


    private void Awake()
    {
        //permet de garder un seul GestionJeu ouvert, le premier qui est créer
        int nbrGestionJeu = FindObjectsOfType<GestionJeu>().Length;
        if (nbrGestionJeu > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        // initialise le pointage a zero
        _pointage = 0;

        //appelle la fonction InstructionDepart()
        InstructionsDepart();
    }

    //Fonction qui permet d'augmenter les points 
    public void AugmenterPointage()
    {
        _pointage++;
    }

    //fonction qui permet d'enregistrer les point, le temps et le temps total a la fin d'un niveau
    public void setPoinage(int noScene)
    {
        // variable qui permet de savoir combien de scene il y a.
        int noDerniereScene = SceneManager.sceneCountInBuildSettings;

        //si cela n'est pas la premiere scene, prendre le temps de la scene d'avant et la soustraire au temps total du moment
       if (noScene != 0) 
        {   
            _tableauPoint[noScene, 0] = Time.time - _tableauPoint[noScene -1, 0];
            _tableauPoint[noScene, 1] = _pointage;
            _tableauPoint[noScene, 2] = _tableauPoint[noScene, 0] + _pointage;
            _pointage = 0;
        }
        else // si c'est la premier scene, enregistre le temps, les pointages et le temps total
        {
            _tableauPoint[noScene, 0] = Time.time;
            _tableauPoint[noScene, 1] = _pointage;
            _tableauPoint[noScene, 2] = _tableauPoint[noScene, 0] + _pointage;
            _pointage = 0;
        }
       // enregistrer le total des points, du temps et du temps total.
        _tableauPoint[noDerniereScene, 0] += _tableauPoint[noScene, 0];
        _tableauPoint[noDerniereScene, 1] += _tableauPoint[noScene, 1];
        _tableauPoint[noDerniereScene, 2] += _tableauPoint[noScene, 2];

    }


    //Instruction du départ.
    private static void InstructionsDepart()
    {
        Debug.Log("*** Course a obstacle ***");
        Debug.Log("Le but du jeu est d'atteindre la zone d'arrivée le plus rapidement possible");
        Debug.Log("Chaque obstacle qui sera touché donnera une pénalité au joueur");
    }

}
