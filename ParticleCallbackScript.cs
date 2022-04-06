using System;
using UnityEngine;

public class ParticleCallbackScript : MonoBehaviour {
  private ParticleSystem particle;

  public Action<ParticleCallbackScript> Callback { get; set; }

  // Start is called before the first frame update
  protected void Awake() {
    particle = GetComponent<ParticleSystem>();
    particle.Pause();
    var main = particle.main;
    main.stopAction = ParticleSystemStopAction.Callback;
  }

  public void OnParticleSystemStopped() {
    Callback(this);
  }

  public void RestartParticle() {
    particle.Simulate(0, true, true);
    particle.Play();
  }
}
