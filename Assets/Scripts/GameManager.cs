using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Y00 {

  public class GameManager : MonoBehaviour {

    [HideInInspector]
    public InputManager inputManager;

    private static GameManager instance;
    public static GameManager Instance {
      get {
        if (instance == null) {
          throw new System.NullReferenceException("No GameManager yet");
        }
        return instance;
      }
    }

    public delegate void OnAction(Action action);
    public event OnAction InputAction;

    void Awake() {
      if (instance == null) {
        instance = this;
      } else {
        Debug.LogWarning("Attempting to build more than one GameManager");
        Destroy(gameObject);
      }
    }

    // Use this for initialization
    void Start() {
      DontDestroyOnLoad(gameObject);
      inputManager = InputManager.Instance;
    }

    // Update is called once per frame
    void Update() {
      // Temp
      if (Input.GetKeyDown("m")) {
        SceneManager.LoadScene("DebugScene");
      }
    }

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate() {
      Action action = inputManager.GetInput();
      if (InputAction != null)
        InputAction(action);
    }
  }

} // namespace Y00