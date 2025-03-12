using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class XPman : MonoBehaviour
{
    [Header("exp")]
    [SerializeField] AnimationCurve experienceCurve;
    int currentLevel, totalxp;
    int previousLevelsxp, nextLevelxp;

    [Header("Interface")]
    [SerializeField] TextMeshProUGUI leveltxt;
    [SerializeField] TextMeshProUGUI xptxt;
    [SerializeField] Image experienceFill;

    [Header("Pollution Particles")]
    [SerializeField] ParticleSystem pollutionParticles; // Sistemul de particule
    [SerializeField] int maxParticleRate = 100; // Numărul maxim de particule pe secundă
    [SerializeField] Transform particleParent; // Parintele particulelor, pentru a le muta cu camera

    [Header("Game Over")]
    [SerializeField] TextMeshProUGUI gameOverText; // Text afișat când XP ajunge la -1000
    [SerializeField] GameObject gameOverPanel; // Panel-ul care apare la final

    private Camera mainCamera; // Referință la camera principală

    private void Start()
    {
        mainCamera = Camera.main; // Obține camera principală
        UpdateLevel();
        gameOverPanel.SetActive(false); // Ascunde mesajul la început
        if (pollutionParticles != null)
        {
            pollutionParticles.Stop(); // Opriți particulele la început
        }
    }

    private void Update()
    {
       

        // Urmează camera dacă particulele sunt active
        if (pollutionParticles.isPlaying)
        {
            FollowCamera();
        }
    }

    public void Addxp(int amount)
    {
        totalxp += amount;
        CheckForLevelUp();
        UpdatePollutionParticles(); // Crește particulele pe măsură ce XP-ul scade
        UpdateInterface();
        CheckGameOver(); // Verifică dacă jocul trebuie să se încheie
    }

    void CheckForLevelUp()
    {
        if (totalxp >= nextLevelxp)
        {
            currentLevel++;
            UpdateLevel();
        }
    }

    void UpdateLevel()
    {
        previousLevelsxp = (int)experienceCurve.Evaluate(currentLevel);
        nextLevelxp = (int)experienceCurve.Evaluate(currentLevel + 1);
        UpdateInterface();
    }

    private void UpdateInterface()
    {
        int start = totalxp - previousLevelsxp;
        int end = nextLevelxp - previousLevelsxp;
        leveltxt.text = currentLevel.ToString();
        xptxt.text = start + "xp / " + end + " exp";
        experienceFill.fillAmount = (float)start / (float)end;
    }

    private void UpdatePollutionParticles()
    {
        if (pollutionParticles == null) return;

        // Calculăm numărul de particule în funcție de XP
        int particleRate = Mathf.Abs(totalxp / 10); // La fiecare -10 XP, crește particulele
        particleRate = Mathf.Clamp(particleRate, 0, maxParticleRate); // Limităm numărul de particule

        var emission = pollutionParticles.emission;
        emission.rateOverTime = particleRate; // Setează rata de particule

        // Dacă XP-ul este sub -100, pornim particulele
        if (totalxp <= -100)
        {
            if (!pollutionParticles.isPlaying)
            {
                pollutionParticles.Play(); // Pornește particulele
            }
        }
        else
        {
            if (pollutionParticles.isPlaying)
            {
                pollutionParticles.Stop(); // Oprește particulele dacă XP-ul este suficient de mare
            }
        }
    }

    private void FollowCamera()
    {
        if (mainCamera != null && particleParent != null)
        {
            // Poziționăm particulele la poziția camerei pentru a le face să o urmeze
            particleParent.position = mainCamera.transform.position;
        }
    }

    private void CheckGameOver()
    {
        if (totalxp <= -1000)
        {
            gameOverPanel.SetActive(true);
            gameOverText.text = "Ai poluat prea mult... de ce?";
            Invoke("QuitGame", 5f); // Închide jocul după 5 secunde
        }
    }

    private void QuitGame()
    {
        Application.Quit(); // Închide jocul (nu funcționează în editor, doar în build)
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Oprește jocul în editor
#endif
    }
}
