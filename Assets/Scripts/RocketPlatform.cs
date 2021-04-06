using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketPlatform : MonoBehaviour, IInteractable
{
    public MeshRenderer display;
    public Material onMaterial;
    public Material offMaterial;

    public ParticleSystem smokeParticles;
    public ScreenFade screenFade;

    [SerializeField] MeshRenderer rocketBase;
    [SerializeField] MeshRenderer rocketFuel;
    [SerializeField] MeshRenderer rocketSides;
    [SerializeField] MeshRenderer rocketFins;
    [SerializeField] MeshRenderer rocketTop;
    
    RocketFlameAnim flameAnim;
    RocketPath rocketPath;

    void Awake()
    {
        flameAnim = GetComponentInChildren<RocketFlameAnim>();
        rocketPath = GetComponentInChildren<RocketPath>();
        rocketBase.enabled = false;
        rocketFuel.enabled = false;
        rocketSides.enabled = false;
        rocketFins.enabled = false;
        rocketTop.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsRocketComplete())
        {
            display.material = onMaterial;
        }
        else
        {
            display.material = offMaterial;
        }
    }
    bool IsRocketComplete()
    {
        return (rocketBase.enabled && rocketFuel.enabled && rocketSides.enabled && rocketFins.enabled && rocketTop.enabled);
    }
    public void Interact()
    {
        if (IsRocketComplete())
        {
            LaunchRocket();
        }
    }

    private void LaunchRocket()
    {
        CameraFollow.target = rocketFuel.gameObject;
        smokeParticles.Play();
        flameAnim.Ignite();
        rocketPath.ignite = true;
        rocketBase.transform.parent = null;
        GameObject.FindGameObjectWithTag("Player").SetActive(false);
        Invoke(nameof(SlowHideHook),3f);

        Invoke(nameof(EndGame), 6f);
    }
    void SlowHideHook()
    {
        screenFade.SlowHide();
    }
    void EndGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
    [ContextMenu("Complete rocket")]
    public void CompleteRocket()
    {
        rocketBase.enabled = true;
        rocketFuel.enabled = true;
        rocketSides.enabled = true;
        rocketFins.enabled = true;
        rocketTop.enabled = true;
    }
    public void AddPart(RocketPart.Type partType)
    {
        switch (partType)
        {
            case RocketPart.Type.Base:
                rocketBase.enabled = true;
                return;
            case RocketPart.Type.Fuel:
                rocketFuel.enabled = true;
                return;
            case RocketPart.Type.Sides:
                rocketSides.enabled = true;
                return;
            case RocketPart.Type.Fins:
                rocketFins.enabled = true;
                return;
            case RocketPart.Type.Top:
                rocketTop.enabled = true;
                return;
        }
    }
}
