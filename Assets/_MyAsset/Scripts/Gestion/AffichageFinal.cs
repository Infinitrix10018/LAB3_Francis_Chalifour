using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AffichageFinal : MonoBehaviour
{
    private GestionJeu _gestionJeu;

    [SerializeField] private TMP_Text _txtTemps = default;
    [SerializeField] private TMP_Text _txtAccrochage = default;
    [SerializeField] private TMP_Text _txtTempsFinal = default;

    // Start is called before the first frame update
    void Start()
    {
        _gestionJeu = FindObjectOfType<GestionJeu>();
        float tempsFinal;
        float temps;
        temps = Time.time - _gestionJeu.GetTempsDepart();
        
        tempsFinal = temps + _gestionJeu.GetPoint();

        _txtTemps.text = "Temps : " + temps.ToString("f2");
        _txtAccrochage.text = "Accrochage : " + _gestionJeu.GetPoint().ToString("f2");
        _txtTempsFinal.text = "Temps total : " + tempsFinal.ToString("f2");
    }

}
