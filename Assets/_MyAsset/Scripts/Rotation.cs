using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    //vitesse de rotation de base
   [SerializeField] private float _rotation = 1f; 

    //Permet d'activer 
   public bool _active = false;

    void FixedUpdate()
    {
        //Si l'objet est activé, il va faire des rotation sur l'axe des "y".
        if(_active)
        {   
            transform.Rotate(0f, _rotation, 0f); 
        }
        
    }

}
