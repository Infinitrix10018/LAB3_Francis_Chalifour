using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _txtAccrochages = default;
    [SerializeField] private TMP_Text _txtTemps = default;
    [SerializeField] private GameObject _menuPause = default;
    private bool _enPause;
    private GestionJeu _gestionJeu;
    public bool _enJeu = false;


    void Start()
    {
        _gestionJeu = FindObjectOfType<GestionJeu>();
        _txtAccrochages.text = "Accrochages : " + _gestionJeu.GetPoint();
        Time.timeScale = 1;
        _enPause = false;
    }


    private void Update()
    {
        float temps = Time.time - _gestionJeu.GetTempsDepart();
        _txtTemps.text = "Temps : " + temps.ToString("f2");
        GestionPause();
    }

    public void GestionPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_enPause)
        {
            _menuPause.SetActive(true);
            Time.timeScale = 0;
            _enPause = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && _enPause)
        {
            EnleverPause();
        }
    }

    public void ChangerPointage(int p_pointage)
    {
        _txtAccrochages.text = "Accrochages : " + p_pointage.ToString();
    }

    public void EnleverPause()
    {
        _menuPause.SetActive(false);
        Time.timeScale = 1;
        _enPause = false;
    }



    public void GestionTemps()
    {
        if(_enJeu)
        {
            float temps = Time.time - _gestionJeu.getTempsDebut();
            _txtTemps.text = "Temps : " + temps.ToString("f2");

        }
        else
        {
            float temps = Time.time - _gestionJeu.getTempstotal();
            _txtTemps.text = "Temps : " + temps.ToString("f2");

        }
    }
}
