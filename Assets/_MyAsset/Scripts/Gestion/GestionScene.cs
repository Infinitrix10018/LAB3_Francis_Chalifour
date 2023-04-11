using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionScene : MonoBehaviour
{

    private bool _activer = false;
    [SerializeField] private GameObject _menu = default;


    public void ChangerSceneSuivante()
    {
        int noScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(noScene + 1);
    }
    public void Quitter()
    {
        Application.Quit();
    }
    public void ChargerSceneDepart()
    {
        SceneManager.LoadScene(0);
    }

    public void GestionInstructions()
    {
        if (!_activer)
        {
            _menu.SetActive(true);
            Time.timeScale = 0;
            _activer = true;
        }
        else if (_activer)
        {
            EnleverInstruction();
        }
    }

    public void EnleverInstruction()
    {
        _menu.SetActive(false);
        Time.timeScale = 1;
        _activer = false;
    }


}
