using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    // Velocidad de rotaci�n
    public float rotationSpeed;
    public bool right = false;

    void Update()
    {
        //El planeta rota sobre el eje Z
        if (!right)
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
        else
        transform.Rotate(0f, 0f, -rotationSpeed * Time.deltaTime);
    }
}
