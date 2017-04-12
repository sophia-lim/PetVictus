using System;
using System.Collections;

public class saveState {

    // Count of food group per post
    public int postVeggieCount = 0;
    public int postMeatCount = 0;
    public int postSeafoodCount = 0;
    public int postDairyCount = 0;

    // Count of food group in total (all posts)
    public int totalVeggieCount = 0;
    public int totalMeatCount = 0;
    public int totalSeafoodCount = 0;
    public int totalDairyCount = 0;
    
    // List of moods possibilities
    // 0: Ecstatic   || 4: Alert
    // 1: Happy      || 5: Sick
    // 2: Content    || 6: Unhappy
    // 3: Worried    || 7: Angry
    ArrayList moods = new ArrayList { "Ecstatic", "Happy", "Content", "Worried", "Alerted", "Sick", "Unhappy", "Angry"};

    // Animal
    public string userPet = "";
    public string petName = "";

    // Current mood
    public string currentMood = "Content";
    public int currentMoodIndex = 2;

    // Post file directory
    // To be accessed in post_edit to display image
    // To be updated in post_create
    public string currentPost = "";
    
}
