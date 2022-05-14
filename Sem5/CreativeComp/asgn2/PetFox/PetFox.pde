Boolean loadingComplete = false;
Boolean isInteracting = false;

// IMAGE PATHS
// Main Directories
final String nonSpritePath = "nonsprites/";
final String spritePath = "sprites/";
// 0. IDLE PATHS
final String idleSpritePath = spritePath + "0/";
final String idleStaticSpritePath = idleSpritePath + "0/";
final String idleWagtailSpritePath = idleSpritePath + "1/";
final String idlePlaySpritePath = idleSpritePath + "2/";
// 1. PLAY PATHS
final String playPath = spritePath + "1/";
// 2. BATHE PATHS
final String bathePath = spritePath + "2/";
// 3. FEED PATHS
final String feedPath = spritePath + "3/";
// 4. PAT PATHS
final String patPath = spritePath + "4/";

// UI VISUAL ELEMENT VARIABLES
Button btnPlay, btnFeed, btnPat, btnBathe; //Interactive buttons
StatusBar stbHunger, stbHygiene, stbMood, stbExp; //Status bars
PImage imgBackground, imgHungerBubble, imgHygieneBubble, imgMoodBubble; //Background and status icon bubbles
PFont fontLoading, fontGrowthLevel, fontButton;
String strGrowthLevel = "GROWTH LEVEL: ";

// DRAW() GLOBAL VARIABLES
// For StatusBar functionality
float stbHungerSpeed = 0.0004;
float stbHygieneSpeed = 0.0007;
float stbMoodSpeed = 0.0005; 
final float highLevelPoint = 1;   //Status bar's specific level differentiation point
final float midHighLevelPoint = 0.75; 
final float midLevelPoint = 0.5; //
final float lowLevelPoint = 0.2; //
// For determining animation to be played
int interactionType = 0; //Values: 0 for no interaction, 1-4 for each interaction
int moodVal = 1; //Values: 1, 2, 3 for different eyes
int hygieneVal = 1; //Values: 1, 2 for clean & dirty
int hungerVal = 1; //Values: 1, 2, 3 for hunger state, indicated by different eyes
int growthVal = 1; //Values: 1, 2, 3 from small to big
float hungerPerc, hygienePerc, moodPerc, expPerc;
final float bubblePromptMidPointOffset = 0.15;

// SPRITES AND ANIMATIONS
// ############################## 0. IDLE ##############################
int idleSpriteType = 0;
PImage[][][] idleStaticImages = new PImage[3][3][2];
/* STRUCTURE
idleStaticImages = { // 1st dimension: Growth, 2nd dimension: Mood, 3rd dimension: Hygiene
  {{111, 112}, {121, 122}, {131, 132}}, // 0th index
  {{211, 212}, {221, 222}, {231, 232}}, // 1st index
  {{311, 312}, {321, 322}, {331, 332}}  // 2nd index
}; */
Animation[][][] idleWagtailAnimations = new Animation[3][3][2];
/* STRUCTURE
idleWagtailAnimations = { // 1st dimension: Growth, 2nd dimension: Mood, 3rd dimension: Hygiene
  {{111, 112}, {121, 122}, {131, 132}}, // 0th index
  {{211, 212}, {221, 222}, {231, 232}}, // 1st index
  {{311, 312}, {321, 322}, {331, 332}}  // 2nd index
}; */
Animation[][] idlePlayAnimations = new Animation[3][2];
/* STRUCTURE
idlePlayAnimations = { // 1st dimension: Growth, 2nd dimension: Hygiene
  {11, 12}, // 0th index
  {21, 22}, // 1st index
  {31, 32}  // 2nd index
}; */
// Idle animation control variables
final float minIdleSpriteInterval = 5; //How long to wait before changing sprites, in seconds
final float maxIdleSpriteInterval = 10; // 
final float idleWagtailSpeed = 0.5; //Animation speed for idle animation 1&2 
final float idlePlaySpeed = 0.5; //
float idleSpriteInterval = random(minIdleSpriteInterval, maxIdleSpriteInterval+1); // Range: minIdleSpriteInterval - maxIdleSpriteInterval

// ############################## 1. PLAY ##############################
Animation[][] playAnimations = new Animation[3][2];
/* STRUCTURE
playAnimations = { // 1st dimension: Growth, 2nd dimension: Hygiene
  {11, 12}, // 0th index
  {21, 22}, // 1st index
  {31, 32}  // 2nd index
}; */
// Play animation control variables
final float playSpeed = 0.15;
final float playDuration = 5;

// ############################## 2. BATHE ##############################
Animation[][] batheAnimations = new Animation[3][2];
/* STRUCTURE
batheAnimations = { // 1st dimension: Growth, 2nd dimension: Hygiene
  {11, 12}, // 0th index
  {21, 22}, // 1st index
  {31, 32}  // 2nd index
}; */
// Bathe animation control variables
final float batheSpeed = 0.15;
final float batheDuration = 7;

// ############################## 3. FEED  ##############################
Animation[][] feedAnimations = new Animation[3][2];
/* STRUCTURE
feedAnimations = { // 1st dimension: Growth, 2nd dimension: Hygiene
  {11, 12}, // 0th index
  {21, 22}, // 1st index
  {31, 32}  // 2nd index
}; */
// Feed animation control variables
final float feedSpeed = 0.3;
final float feedDuration = 4;

// ############################## 4. PAT ##############################
Animation[][] patAnimations = new Animation[3][2];
/* STRUCTURE
patAnimations = { // 1st dimension: Growth, 2nd dimension: Hygiene
  {11, 12}, // 0th index
  {21, 22}, // 1st index
  {31, 32}  // 2nd index
}; */
// Play animation control variables
final float patSpeed = 0.15;
final float patDuration = 5;

float previousDisplayTime = 0; //Variable for Draw sprite - step 3: delayed randomization. Keep track of the last time a frame of the animation was displayed


void setup() {
  frameRate(60);
  size(1000, 800, P2D);
  imgBackground = loadImage(nonSpritePath + "bg.png");
  
  // SETUP FONTS
  fontLoading = createFont("Tw Cen Mt Bold", 50);
  fontGrowthLevel = createFont("Tw Cen Mt Bold", 14);
  fontButton = createFont("Tw Cen Mt Bold", 26);
  
  // DISPLAY LOADING SCREEN
  background(255,219,217);
  fill(0);
  textAlign(CENTER);
  textFont(fontLoading);
  text("LOADING...", width/2, height/2);
  
  // SETUP BUTTONS
  btnPlay  = new Button(width-340, 20, 150, 50, "PLAY", color(255,255,255), color(255,0,0));
  btnFeed  = new Button(width-170, 20, 150, 50, "FEED", color(255,255,255), color(255,215,0));
  btnPat   = new Button(width-340, 80, 150, 50, "PAT", color(255,255,255), color(255,154,162));
  btnBathe = new Button(width-170, 80, 150, 50, "BATHE", color(255,255,255), color(5,195,221));
  // SETUP STATUS BARS
  stbHunger  = new StatusBar(10, 20, 400, 25, 50, 50, 1, stbHungerSpeed, loadImage(nonSpritePath+"icon_food.png"), 1, "Hunger status of pet fox", color(255,215,0), color(255,245,189));
  stbHygiene = new StatusBar(10, 62, 400, 25, 50, 50, 1, stbHygieneSpeed, loadImage(nonSpritePath+"icon_bathe.png"), 1, "Hygiene status of pet fox", color(5,195,221), color(196,248,255));
  stbMood    = new StatusBar(10, 104, 400, 25, 50, 50, 1, stbMoodSpeed, loadImage(nonSpritePath+"icon_mood.png"), 1, "Mood status of pet fox", color(255,0,0), color(255,219,217));
  // SETUP EXP BAR
  stbExp  = new StatusBar(10, 750, 900, 20, 60, 60, 0, 0, loadImage(nonSpritePath+"icon_exp.png"), 1, "Pet fox EXP Bar", color(119,221,119), color(227,255,234));
  // SETUP SPEECH BUBBLES
  imgHungerBubble = loadImage(nonSpritePath + "food_bubble.png");
  imgHygieneBubble = loadImage(nonSpritePath + "bathe_bubble.png");
  imgMoodBubble = loadImage(nonSpritePath + "mood_bubble.png");
  
  // Load all Animations and PImage assets in a thread so the Java Runtime recognizes that the program is loading files and not frozen
  // ref: https://processing.org/reference/thread_.html
  // Otherwise: this exception is thrown and program crashes if the setup() function takes more than 5 seconds to complete
  /* java.lang.RuntimeException: Waited 5000ms for: <3a8e1afa, 3449f3db>[count 2, qsz 0, owner <main-FPSAWTAnimator#00-Timer0>]
     - <main-FPSAWTAnimator#00-Timer0-FPSAWTAnimator#00-Timer1> RuntimeException: Waited 5000ms for: <3a8e1afa, 3449f3db>[count 2, qsz 0, owner <main-FPSAWTAnimator#00-Timer0>]
     - <main-FPSAWTAnimator#00-Timer0-FPSAWTAnimator#00-Timer1> at processing.opengl.PSurfaceJOGL$2.run(PSurfaceJOGL.java:410) at java.lang.Thread.run(Thread.java:748) */
  thread("loadAssets");
}

void draw() {
  if (loadingComplete) {
    // DISPLAY UI
    // BACKGROUND
    image(imgBackground, 0, 0, 1000, 800);
    // BUTTONS
    textFont(fontButton);
    textAlign(CENTER);
    btnPlay.display();
    btnFeed.display();
    btnPat.display();
    btnBathe.display();
    // STATUS BARS
    stbHunger.display();
    stbHygiene.display();
    stbMood.display();
    // EXP BAR
    stbExp.display();
    // PET LEVEL TEXT
    textFont(fontGrowthLevel);
    textAlign(LEFT);
    if (growthVal <= 3)
      text(strGrowthLevel + " " + growthVal, 78, 788);
    if (growthVal == 3 && stbExp.getValuePercent() == 1)
      text(strGrowthLevel + " " + growthVal + " (MAX)", 78, 788);
    
    // CHANGE MOUSE CURSOR WHEN HOVERED ON BUTTONS
    if (btnPlay.isHovered() || btnFeed.isHovered() || btnPat.isHovered() || btnBathe.isHovered()) {
      cursor(HAND);
    } else {
      cursor(ARROW);
    }
  
    // DRAW SPRITES AND PLAY ANIMATIONS
    // Before that, get status info
    hungerPerc = stbHunger.getValuePercent();
    hygienePerc = stbHygiene.getValuePercent();
    moodPerc = stbMood.getValuePercent();
    expPerc = stbExp.getValuePercent();
    
    // Hunger
    if (hungerPerc < lowLevelPoint) {
      hungerVal = 3;
    } else if (hungerPerc < midLevelPoint) {
      hungerVal = 2;
    } else {
      hungerVal = 1;
    }
    
    // Hygiene
    if (hygienePerc < midLevelPoint) {
      hygieneVal = 2;
    } else {
      hygieneVal = 1;
    }
    
    // Mood
    if (hungerPerc < lowLevelPoint || moodPerc < lowLevelPoint) {
      moodVal = 3;
    } else if (hungerPerc < midLevelPoint || moodPerc < midLevelPoint) {
      moodVal = 2;
    } else {
      moodVal = 1;
    }
    
    // Growth
    if (expPerc == highLevelPoint && growthVal == 1){
      expPerc = 0;
      growthVal = 2;
      stbExp.setValuePercent(expPerc);
    } else if (expPerc == highLevelPoint && growthVal == 2){
      expPerc = 0;
      growthVal = 3;
      stbExp.setValuePercent(expPerc);
    } else if (expPerc == highLevelPoint && growthVal == 3){
      expPerc += 0;
    }
    
    // Increase expPerc when all status values are 0.75 or higher
    if (hungerPerc >= midHighLevelPoint && hygienePerc >= midHighLevelPoint && moodPerc >= midHighLevelPoint) {
      expPerc = expPerc + 0.0011; 
      stbExp.setValuePercent(expPerc);
    }
    
    // Draw sprite speech bubbles before drawing sprite for medium and big fox to avoid the bubbles blocking the sprite
    if (hungerPerc <= (midLevelPoint - bubblePromptMidPointOffset) && (growthVal == 3 || growthVal == 2)) {
      image(imgHungerBubble, 0, 0, 1000, 800);
    }
    
    // Choose idle sprite when no interaction
    if (interactionType == 0) {
      runIdleAnimation(hungerPerc, hygienePerc, moodPerc);
    } else if (interactionType == 1) {
      // Choose and draw play animation 
      // Logic for each interaction:
      // 1. load and play interaction animation
      // 2. increase the target status bar value
      // 3. change sprite type back to 0 (idle)
      runPlayAnimation(hungerPerc, hygienePerc, moodPerc);
    } else if (interactionType == 2) {
      //Choose and draw bathe animation
      runBatheAnimation(hungerPerc, hygienePerc, moodPerc);
    } else if (interactionType == 3) {
      // Choose and draw feed animation 
      runFeedAnimation(hungerPerc, hygienePerc, moodPerc);
    } else if (interactionType == 4) {
      // Choose and draw pat animation
      runPatAnimation(hungerPerc, hygienePerc, moodPerc);
    }
    
    // Draw sprite speech bubbles
    if (hungerPerc <= (midLevelPoint - bubblePromptMidPointOffset) && growthVal == 1)  {
      image(imgHungerBubble, 0, 0, 1000, 800);
    }
    if (hygienePerc <= (midLevelPoint - bubblePromptMidPointOffset)) {
      image(imgHygieneBubble, 0, 0, 1000, 800);
    }
    if (moodPerc <= (midLevelPoint - bubblePromptMidPointOffset)) {
      image(imgMoodBubble, 0, 0, 1000, 800);
    }
  }
}

void mousePressed() {
  // BUTTON onClick listeners
  // Only allow interaction to be executed if there is no ongoing interaction
  if (!isInteracting) {
    // For every interaction:
    // - change interactionType
    // - increase status value
    // - temporarily stop status depletion
    if (btnPlay.isHovered()) {
      isInteracting = true;
      interactionType = 1;
      stbMood.setValuePercent(moodPerc + 0.30);
      stbMood.setDepletionSpeed(0);
    } else if (btnBathe.isHovered()) {
      isInteracting = true;
      interactionType = 2;
      stbHygiene.setValuePercent(hygienePerc + 0.40);
      stbHygiene.setDepletionSpeed(0);
    } else if (btnFeed.isHovered()) {
      isInteracting = true;
      interactionType = 3;
      stbHunger.setValuePercent(hungerPerc + 0.35);
      stbHunger.setDepletionSpeed(0);
    } else if (btnPat.isHovered()) {
      isInteracting = true;
      interactionType = 4;
      stbMood.setValuePercent(moodPerc + 0.30);
      stbMood.setDepletionSpeed(0);
    }
  }
}

void loadAssets() {
  // LOAD SPRITES AND ANIMATIONS
  // 0. IDLE
  // 0.0    Idle Static images
  for (int i = 1; i <= idleStaticImages.length; i++) {
    for (int j = 1; j <= idleStaticImages[i-1].length; j++) {
      for (int k = 1; k <= idleStaticImages[i-1][j-1].length; k++) {
        idleStaticImages[i-1][j-1][k-1] = loadImage(idleStaticSpritePath + "pet" + i + j + k + ".png");
      }
    }
  }
  // 0.1    Idle Wagtail animations
  for (int i = 1; i <= idleWagtailAnimations.length; i++) {
    for (int j = 1; j <= idleWagtailAnimations[i-1].length; j++) {
      for (int k = 1; k <= idleWagtailAnimations[i-1][j-1].length; k++) {
        idleWagtailAnimations[i-1][j-1][k-1] = new Animation(idleWagtailSpritePath + i + j + k + "/", "pet", "png", 2);
      }
    }
  }
  // 0.2    Idle PlayWithButterfly animations
  for (int i = 1; i <= idlePlayAnimations.length; i++) {
    for (int j = 1; j <= idlePlayAnimations[i-1].length; j++) {
      idlePlayAnimations[i-1][j-1] = new Animation(idlePlaySpritePath + i + j + "/", "pet", "png", 11);
    }
  }
  
  // 1. PLAY
  for (int i = 1; i <= playAnimations.length; i++) {
    for (int j = 1; j <= playAnimations[i-1].length; j++) {
      playAnimations[i-1][j-1] = new Animation(playPath + i + j + "/", "pet", "png", 6);
    }
  }
  
  // 2. BATHE
  for (int i = 1; i <= batheAnimations.length; i++) {
    for (int j = 1; j <= batheAnimations[i-1].length; j++) {
      batheAnimations[i-1][j-1] = new Animation(bathePath + i + j + "/", "pet", "png", 6);
    }
  }
  
  // 3. FEED
  for (int i = 1; i <= feedAnimations.length; i++) {
    for (int j = 1; j <= feedAnimations[i-1].length; j++) {
      feedAnimations[i-1][j-1] = new Animation(feedPath + i + j + "/", "pet", "png", 6);
    }
  }
  
  // 4. PAT
  for (int i = 1; i <= patAnimations.length; i++) {
    for (int j = 1; j <= patAnimations[i-1].length; j++) {
      patAnimations[i-1][j-1] = new Animation(patPath + i + j + "/", "pet", "png", 6);
    }
  }
  
  // Set loadingComplete to true to hide loading screen and start application
  loadingComplete = true;
}

void runIdleAnimation(float hungerPerc, float hygienePerc, float moodPerc) { 
  // 1. Play idle animations based on:
  //    - randomly selected idleSpriteType
  //    - changing statuses
  if (idleSpriteType == 0) {
    image(idleStaticImages[growthVal-1][moodVal-1][hygieneVal-1], 0, 0, 1000, 800);
  } else if (idleSpriteType == 1) {
    idleWagtailAnimations[growthVal-1][moodVal-1][hygieneVal-1].play(0, 0, 1000, 800, idleWagtailSpeed, true);
  } else if (idleSpriteType == 2) {
    idlePlayAnimations[growthVal-1][hygieneVal-1].play(0, 0, 1000, 800, idlePlaySpeed, false);
  }

  // 2. Reset:
  //    - new idle sprite interval
  //    - new idle sprite type
  //    - selected Animation objects to first frame
  if (millis() > previousDisplayTime + (idleSpriteInterval*1000)) {
      //Randomize idle sprite type
      idleSpriteType = int(random(0,3)); // Range: 0-2
      //println(idleSpriteType);
      
      // Randomize idle sprite interval
      if (idleSpriteType == 1) {
        idleSpriteInterval = 3;  //How long idleWagtailAnimations will be on screen      
      } else if (idleSpriteType == 2) {
        idleSpriteInterval = 6;  //How long idlePlayAnimations will be on screen
      } else {
        idleSpriteInterval = random(minIdleSpriteInterval, maxIdleSpriteInterval+1); //Range: minIdleSpriteInterval - maxIdleSpriteInterval 
      }
      //println(idleSpriteInterval);
      
      // Set animation sprites to first frame before display
      idleWagtailAnimations[growthVal-1][moodVal-1][hygieneVal-1].setFrame(0);
      idlePlayAnimations[growthVal-1][hygieneVal-1].setFrame(0);
      
      // Save current time to be compared with next interval 
      previousDisplayTime = millis();
  }
}

void runPlayAnimation(float hungerPerc, float hygienePerc, float moodPerc) {
  // Run play animations until duration is up
  playAnimations[growthVal-1][hygieneVal-1].play(0, 0, 1000, 800, playSpeed, true);
  
  if (millis() > previousDisplayTime + (playDuration*1000)) {
    // Reset interactionType to idle after duration is up
    interactionType = 0;
    // Set isInteracting to false, save current time, and restart value depletion
    isInteracting = false;
    previousDisplayTime = millis();
    stbMood.setDepletionSpeed(stbMoodSpeed);
    // Reset animation frame
    playAnimations[growthVal-1][hygieneVal-1].setFrame(0);
  }
}

void runBatheAnimation(float hungerPerc, float hygienePerc, float moodPerc) {
  // Run bathe animations until duration is up
  batheAnimations[growthVal-1][hygieneVal-1].play(0, 0, 1000, 800, batheSpeed, true);
  
  if (millis() > previousDisplayTime + (batheDuration*1000)) {
    // Reset interactionType to idle after duration is up
    interactionType = 0;
    // Set isInteracting to false, save current time, and restart value depletion
    isInteracting = false;
    previousDisplayTime = millis();
    stbHygiene.setDepletionSpeed(stbHygieneSpeed);
    // Reset animation frame
    batheAnimations[growthVal-1][hygieneVal-1].setFrame(0);
  }
}

void runFeedAnimation(float hungerPerc, float hygienePerc, float moodPerc) {
    // Run feed animations until duration is up
  feedAnimations[growthVal-1][hygieneVal-1].play(0, 0, 1000, 800, feedSpeed, true);
  
  if (millis() > previousDisplayTime + (feedDuration*1000)) {
    // Reset interactionType to idle after duration is up
    interactionType = 0;
    // Set isInteracting to false, save current time, and restart value depletion
    isInteracting = false;
    previousDisplayTime = millis();
    stbHunger.setDepletionSpeed(stbHungerSpeed);
    // Reset animation frame
    feedAnimations[growthVal-1][hygieneVal-1].setFrame(0);
  }
}

void runPatAnimation(float hungerPerc, float hygienePerc, float moodPerc) {
  // Run pat animations until duration is up
  patAnimations[growthVal-1][hygieneVal-1].play(0, 0, 1000, 800, patSpeed, true);
  
  if (millis() > previousDisplayTime + (patDuration*1000)) {
    // Reset interactionType to idle after duration is up
    interactionType = 0;
    // Set isInteracting to false, save current time, and restart value depletion
    isInteracting = false;
    previousDisplayTime = millis();
    stbMood.setDepletionSpeed(stbMoodSpeed);
    // Reset animation frame
    patAnimations[growthVal-1][hygieneVal-1].setFrame(0);
  }
}
