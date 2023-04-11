using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionJeu : MonoBehaviour
{   
    // tableau qui va avoir le temps, les points et le temps total.
    public float[] _tableauTemps = new float[5];
    //variable qui permet d'enregistrer le nombre de point
    private int _pointage;
    private float _tempsDebutJeu;
    private UIManager _UIManager;
    private int _noNiveau;
    private float _tempsDebut;
    private float _tempsReel;


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
        _UIManager = FindObjectOfType<UIManager>();
        // initialise le pointage a zero
        _pointage = 0;
        _tempsDebutJeu = Time.time;

        //appelle la fonction InstructionDepart()
        //InstructionsDepart();
    }

    //Fonction qui permet d'augmenter les points 
    public void AugmenterPointage()
    {
        _pointage++;
        _UIManager.ChangerPointage(_pointage);
    }

    public void setTempsDebut()
    {
        _tempsDebut = Time.time;
    }
    public void setTempstotal()
    {
        _tempsReel += Time.time - _tempsDebut;
    }
    public float getTempsDebut()
    {
        return _tempsDebut;
    }
    public float getTempstotal()
    {
        return _tempsReel;
    }



    //fonction qui permet d'enregistrer les point, le temps et le temps total a la fin d'un niveau
    public void setTemps()
    {
        _tableauTemps[_noNiveau] = Time.time;
        setTempsFinal();
        _noNiveau++;
    }
    public void setTempsFinal()
    {
        _tableauTemps[3] += Time.time - _tableauTemps[_noNiveau];
    }

 /*   public void setTempsTotal()
    {
        _tableauTemps[4] = _tableauTemps[3] + _pointage;
    }
 */
    public int GetPoint()
    {
        return _pointage;
    }

    public float GetTempsDepart()
    {
        return _tempsDebutJeu;
    }

/*
    //Instruction du départ.
    private static void InstructionsDepart()
    {
        Debug.Log("*** Course a obstacle ***");
        Debug.Log("Le but du jeu est d'atteindre la zone d'arrivée le plus rapidement possible");
        Debug.Log("Chaque obstacle qui sera touché donnera une pénalité au joueur");
    }
*/
}
