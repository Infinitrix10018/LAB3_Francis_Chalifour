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

        _txtTemps.text = "Temps : " + _gestionJeu._tableauTemps[3].ToString("f2");
        _txtAccrochage.text = "Accrochage : " + _gestionJeu.GetPoint().ToString("f2");
        _txtTempsFinal.text = "Temps total : " + _gestionJeu._tableauTemps[4].ToString("f2");
    }

}
