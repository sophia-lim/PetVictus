using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class registration : MonoBehaviour {

    Firebase.Auth.FirebaseAuth auth;
    Firebase.Auth.FirebaseUser user;

    public Text emailText;
    public Text passwordText;
    public Text ownerName;
    public Text petName;

    public GameObject cow;
    public GameObject sheep;
    public GameObject bunny;
    //public GameObject pig;
    //public GameObject dog;

    private string email = "";
    private string password = "";

    const int kMaxLogSize = 16382;
    Firebase.DependencyStatus dependencyStatus = Firebase.DependencyStatus.UnavailableOther;

    // When the app starts, check to make sure that we have
    // the required dependencies to use Firebase, and if not,
    // add them if possible.
    void Start() {
        cow.SetActive(true);
        sheep.SetActive(false);
        bunny.SetActive(false);
        //pig.SetActive(false);
        //dog.SetActive(false);

        dependencyStatus = Firebase.FirebaseApp.CheckDependencies();
        if (dependencyStatus != Firebase.DependencyStatus.Available) {
            Firebase.FirebaseApp.FixDependenciesAsync().ContinueWith(task => {
                dependencyStatus = Firebase.FirebaseApp.CheckDependencies();
                if (dependencyStatus == Firebase.DependencyStatus.Available) {
                    InitializeFirebase();
                } else {
                    Debug.LogError(
                        "Could not resolve all Firebase dependencies: " + dependencyStatus);
                }
            });
        } else {
            InitializeFirebase();
        }
    }

    // Handle initialization of the necessary firebase modules:
    void InitializeFirebase() {
        Debug.Log("Setting up Firebase Auth");
        auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        auth.StateChanged += AuthStateChanged;
        AuthStateChanged(this, null);
    }

    // Track state changes of the auth object.
    void AuthStateChanged(object sender, System.EventArgs eventArgs) {
        if (auth.CurrentUser != user) {
            bool signedIn = user != auth.CurrentUser && auth.CurrentUser != null;
            if (!signedIn && user != null) {
                Debug.Log("Signed out " + user.UserId);
            }
            user = auth.CurrentUser;
            if (signedIn) {
                Debug.Log("Signed in " + user.UserId);
            }
        }
    }

    void OnDestroy() {
        auth.StateChanged -= AuthStateChanged;
        auth = null;
    }

    public void createAccount() {
        auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
            if (task.IsCanceled) {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted) {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            // Firebase user has been created.
            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
        });
    }

    void Update() {
        email = emailText.text;
        password = passwordText.text;
    }

    private void displayAnimal() {
        cow.SetActive(false);
        sheep.SetActive(false);
        bunny.SetActive(false);
        //pig.SetActive(false);
        //dog.SetActive(false);

        if (saveManager.Instance.state.petType == "cow") {
            cow.SetActive(true);
        } else if (saveManager.Instance.state.petType == "sheep") {
            sheep.SetActive(true);
        } else if (saveManager.Instance.state.petType == "bunny") {
            bunny.SetActive(true);
        } /*else if (saveManager.Instance.state.petType == "pig") {
            pig.SetActive(true);
        } else if (saveManager.Instance.state.petType == "dog") {
            dog.SetActive(true);
        }*/
    }

    public void chooseAnimal(Text animalType) {
        saveManager.Instance.state.petType = animalType.text;
        saveManager.Instance.Save();
        displayAnimal();
    }

    private void updateInternalDatabase() {
        saveManager.Instance.state.petName = petName.text;
        saveManager.Instance.state.ownerName = ownerName.text;
        saveManager.Instance.state.email = emailText.text;
    }

    public void confirmRegistration() {
        updateInternalDatabase();
        saveManager.Instance.Save();
    }

}
