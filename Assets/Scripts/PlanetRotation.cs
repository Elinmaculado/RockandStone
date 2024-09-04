using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    // Velocidad de rotación
    public float rotationSpeed;

    void Update()
    {
        //El planeta rota sobre el eje Z
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
    }
}
