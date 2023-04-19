using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectH202 : MonoBehaviour
{
    ParticleSystem _particleSystem;
    [SerializeField] LiquidSystem liquidSystem;
    [SerializeField] ParticleSystem particleSystem_smoke;
    [SerializeField] ParticleSystem particleSystem_Bubbles;
    [SerializeField] MeshRenderer _meshRenderer;
    float emissionValue_Smoke =100;
    float emissionValue_Bubbles =100;
    float H202available=0;
    public bool IsH202Detected;
    float reactionSuppressionTime = 0;
    //float ColorHue = 203;
    private void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        emissionValue_Smoke = particleSystem_smoke.emission.rateOverTime.constant;
        emissionValue_Bubbles = particleSystem_Bubbles.emission.rateOverTime.constant;

    }
    private void Update()
    {
        if (liquidSystem.available > H202available&& IsH202Detected) 
        {
            Debug.Log("pure: "+ reactionSuppressionTime);
            H202available = liquidSystem.available;
            ParticleSystem.EmissionModule emission = particleSystem_smoke.emission;
            emission.rateOverTime = new ParticleSystem.MinMaxCurve(emissionValue_Smoke + liquidSystem.available / 2);

            emission = particleSystem_Bubbles.emission;
            emission.rateOverTime = new ParticleSystem.MinMaxCurve(emissionValue_Bubbles + liquidSystem.available /2);
            reactionSuppressionTime += Time.deltaTime* 50;

        }
    }
    private void OnParticleTrigger()
    {
        
        //Get all particles that entered a box collider
        List<ParticleSystem.Particle> enteredParticles = new List<ParticleSystem.Particle>();
        int enterCount = _particleSystem.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enteredParticles);

        if (liquidSystem.available>0 && enterCount > 0)
        {
            if (!particleSystem_smoke.isPlaying)
            { 
              particleSystem_smoke.Play();
              particleSystem_Bubbles.Play();
                IsH202Detected = true;
              changeH2O2ColorToBlack();
            }
            Debug.Log("increase: " + reactionSuppressionTime);

            emissionValue_Smoke += Time.deltaTime * 10;
            emissionValue_Bubbles += Time.deltaTime * 10;
            ParticleSystem.EmissionModule emission = particleSystem_smoke.emission;
            emission.rateOverTime = new ParticleSystem.MinMaxCurve(emissionValue_Smoke + liquidSystem.available/3);

            emission = particleSystem_Bubbles.emission;
            emission.rateOverTime = new ParticleSystem.MinMaxCurve(emissionValue_Bubbles + liquidSystem.available / 3);
            reactionSuppressionTime += Time.deltaTime*20;

        }
        if (IsH202Detected && enterCount <= 0) 
        {
            if (reactionSuppressionTime - Time.deltaTime >= 0)
            {
                reactionSuppressionTime -= Time.deltaTime;
                Debug.Log("decrease: " + reactionSuppressionTime);
            }
            else
            {
                ParticleSystem.EmissionModule emission = particleSystem_smoke.emission;
                if(emissionValue_Smoke - Time.deltaTime * 10 > 0)
                    emissionValue_Smoke -= Time.deltaTime * 10;
                if (emissionValue_Bubbles - Time.deltaTime * 10 > 0)
                    emissionValue_Bubbles -= Time.deltaTime * 10;
                if(particleSystem_smoke.emission.rateOverTime.constant >0)
                    emission.rateOverTime = new ParticleSystem.MinMaxCurve(particleSystem_smoke.emission.rateOverTime.constant - Time.deltaTime * 10);

                emission = particleSystem_Bubbles.emission;
                if(particleSystem_Bubbles.emission.rateOverTime.constant > 0)
                    emission.rateOverTime = new ParticleSystem.MinMaxCurve(particleSystem_Bubbles.emission.rateOverTime.constant - Time.deltaTime * 10);
            }

        }
    }
    void changeH2O2ColorToBlack() 
    {

        //ColorHue -= Time.deltaTime * 100;
        _meshRenderer.material.SetColor("_Color", new Color(0, 0, 0, 245));

       // Debug.Log("blaaaaaaaaaaaaaack " + _meshRenderer.material.GetColor("_Color"));

    }

    //private IEnumerator _Wait(float waitTime)
    //{

    //        yield return new WaitForSeconds(waitTime);
    //        //changeH2O2ColorToBlack();
    //        //if (ColorHue > 0)
    //        //{

    //        //    changeH2O2ColorToBlack();


    //        //}
        
    //}
}
