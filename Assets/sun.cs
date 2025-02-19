using UnityEngine;

public class RotacionSol : MonoBehaviour
{
    // Velocidad de rotación del Sol (ajustable)
    public float velocidadRotacionSol = 10f;

    // Velocidad de movimiento del Sol alrededor del centro de la galaxia (ajustable)
    public float velocidadMovimientoSol = 0.1f;

    // El punto central alrededor del cual el Sol se moverá (puede ser el centro de la galaxia)
    public Transform centroGalaxia;

    void Update()
    {
        // Rotamos el Sol sobre su propio eje
        transform.Rotate(Vector3.up, velocidadRotacionSol * Time.deltaTime);

        // Movimiento circular alrededor del centro de la galaxia
        if (centroGalaxia != null)
        {
            // Mover al Sol alrededor del centro de la galaxia
            transform.RotateAround(centroGalaxia.position, Vector3.up, velocidadMovimientoSol * Time.deltaTime);
        }
    }
}
