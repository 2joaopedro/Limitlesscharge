using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.Rendering.Universal; // Adiciona o namespace correto para o Light2D

public class DayNightCycle2D : MonoBehaviour
{
    public Light2D globalLight;  // A luz 2D global que será manipulada
    public float dayDuration = 1200f; // Duração do dia (em segundos)
    public float nightDuration = 900f; // Duração da noite (em segundos)

    public Color dayColor = Color.white; // Cor da luz durante o dia
    public Color nightColor = Color.blue; // Cor da luz durante a noite
    public float maxDayIntensity = 1f; // Intensidade máxima durante o dia
    public float minNightIntensity = 0.2f; // Intensidade mínima durante a noite

    private float currentTime = 0f; // Tempo atual no ciclo
    private bool isDay = true; // Indica se é dia ou noite

    void Update()
    {
        // Atualiza o tempo no ciclo
        currentTime += Time.deltaTime;

        // Ciclo de dia
        if (isDay)
        {
            // Ajusta a intensidade e cor da luz ao longo do tempo, durante o dia
            float progress = currentTime / dayDuration;
            globalLight.intensity = Mathf.Lerp(minNightIntensity, maxDayIntensity, progress);
            globalLight.color = Color.Lerp(nightColor, dayColor, progress);

            // Verifica se o ciclo de dia acabou
            if (currentTime >= dayDuration)
            {
                currentTime = 0f;  // Reseta o tempo para iniciar a noite
                isDay = false;
            }
        }
        else // Ciclo de noite
        {
            // Ajusta a intensidade e cor da luz ao longo do tempo, durante a noite
            float progress = currentTime / nightDuration;
            globalLight.intensity = Mathf.Lerp(maxDayIntensity, minNightIntensity, progress);
            globalLight.color = Color.Lerp(dayColor, nightColor, progress);

            // Verifica se o ciclo de noite acabou
            if (currentTime >= nightDuration)
            {
                currentTime = 0f;  // Reseta o tempo para iniciar o dia
                isDay = true;
            }
        }
    }
}
