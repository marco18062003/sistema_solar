using UnityEngine;

public class OrbitaMercurio : MonoBehaviour
{
    public Transform sol; // Referencia al Sol
    public float ejeSemimayor = 0.39f; // Eje semimayor en Unidades Astronómicas (UA) (puedes ajustarlo)
    public float excentricidad = 0.2056f; // Excentricidad de Mercurio
    public float inclinacionOrbital = 7f; // Inclinación en grados
    public float velocidadMultiplicador = 10f; // Multiplicador para aumentar la velocidad de Mercurio

    private float anguloOrbital = 0f; // Ángulo de la órbita
    private float velocidadAngular; // Velocidad angular basada en la fórmula elíptica

    void Start()
    {
        // Usamos la ley de Kepler para establecer la velocidad angular
        velocidadAngular = Mathf.Sqrt(1 / ejeSemimayor); // Velocidad angular básica basada en Kepler

        // Calcular la distancia inicial en el perihelio (distancia mínima)
        float distanciaInicial = ejeSemimayor * (1 - excentricidad); 
        // Posicionar a Mercurio en el perihelio para que empiece correctamente
        float x = distanciaInicial; // En el perihelio, la distancia es la mínima
        float z = 0; // Empezamos en el plano X-Z
        float y = Mathf.Sin(inclinacionOrbital * Mathf.Deg2Rad) * distanciaInicial; // Aplicamos la inclinación

        // Colocamos Mercurio en la posición inicial (perihelio)
        transform.position = sol.position + new Vector3(x, y, z);
    }

    void Update()
    {
        // Incrementar el ángulo orbital, aumentando la velocidad usando el multiplicador
        anguloOrbital += velocidadAngular * velocidadMultiplicador * Time.deltaTime;

        // Asegúrate de que el ángulo no se desborde
        if (anguloOrbital >= 360f)
        {
            anguloOrbital -= 360f;
        }

        // Calcular la distancia desde el Sol usando la fórmula elíptica
        float r = ejeSemimayor * (1 - Mathf.Pow(excentricidad, 2)) / (1 + excentricidad * Mathf.Cos(anguloOrbital));

        // Calcula la posición orbital usando coordenadas polares
        float x = r * Mathf.Cos(anguloOrbital);
        float z = r * Mathf.Sin(anguloOrbital);

        // Aplica la inclinación a la órbita
        float y = Mathf.Sin(inclinacionOrbital * Mathf.Deg2Rad) * r;

        // Calcula la nueva posición de Mercurio alrededor del Sol
        transform.position = sol.position + new Vector3(x, y, z);

        // Asegura que Mercurio mire hacia el Sol (si es necesario)
        Vector3 direccionHaciaElSol = sol.position - transform.position;
        transform.rotation = Quaternion.LookRotation(direccionHaciaElSol);
    }
}
