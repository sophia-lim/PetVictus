﻿using System;
using System.Collections;
using UnityEngine;

public class saveState {

    // Account information
    public bool firstTime = true;
    public string petType = "";
    public string petName = "";
    public string ownerName = "";
    public string email = "";

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
    public ArrayList moods = new ArrayList { "Ecstatic", "Happy", "Content", "Worried", "Alerted", "Sick", "Unhappy", "Angry"};
    
    // Current mood
    public string currentMood = "Happy";

    // Post file directory
    // To be accessed in post_edit to display image
    // To be updated in post_create
    public string currentPost = "";
    
}
