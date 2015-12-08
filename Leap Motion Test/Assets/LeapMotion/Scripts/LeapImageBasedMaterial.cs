using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LeapImageBasedMaterial : MonoBehaviour
{
  public ImageMode imageMode = ImageMode.STEREO;

  public enum ImageMode
  {
    STEREO,
    LEFT_ONLY,
    RIGHT_ONLY
  }

  void OnEnable ()
  {
    Material imageBasedMaterial = GetComponent<Renderer> ().material;
        
    //Initialize gamma correction
    float gamma = 1f;
    if (QualitySettings.activeColorSpace != ColorSpace.Linear) {
      gamma = -Mathf.Log10 (Mathf.GammaToLinearSpace (0.1f));
      //Debug.Log ("Derived gamma = " + gamma);
    }
    imageBasedMaterial.SetFloat ("_ColorSpaceGamma", gamma);
    
    //Initialize the Time-Warp to be the identity
    imageBasedMaterial.SetMatrix ("_ViewerImageToNow", Matrix4x4.identity);
    LeapImageRetriever.registerImageBasedMaterial(this);
  }

  void Start () {
    if (FindObjectOfType<LeapImageRetriever> () == null) {
      Debug.LogWarning ("Place a LeapImageRetriever script on a camera to enable Leap image-based materials");
      enabled = false;
      return;
    }
  }

  void OnDisable ()
  {
    LeapImageRetriever.unregisterImageBasedMaterial (this);
  }
}
