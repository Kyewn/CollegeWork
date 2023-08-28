class Animation {
  String animationPath;
  String imagePrefix;
  String imageType;
  String filename;
  PImage[] images;
  int imageCount;
  int frame;
  
  int previousDisplayTime = 0;  // Keep track of the last time a frame of the animation was displayed
  
  Animation(String path, String prefix, String type, int count) {
    animationPath = path;
    imagePrefix = prefix;
    imageType = type;
    imageCount = count;
    
    // Load images into image sequence
    images = new PImage[imageCount];
    for (int i = 0; i < imageCount; i++) {
      // Use nf() to number format 'i' into four digits
      filename = animationPath + imagePrefix + (i+1) + "." + imageType;
      images[i] = loadImage(filename);
    }
  }
  
  void setFrame(int newFrame) {
    frame = newFrame;
  }
  
  void resetImagesArr(String newPath, String newPrefix, String newFileType, int newImageCount) {
    animationPath = newPath;
    imagePrefix = newPrefix;
    imageType = newFileType;
    imageCount = newImageCount;

    images = new PImage[imageCount];
    for (int i = 0; i < imageCount; i++) {
      // Use nf() to number format 'i' into four digits
      filename = animationPath + imagePrefix + (i+1) + "." + imageType;
      images[i] = loadImage(filename);
    }
  }
  
  //Ref: https://discourse.processing.org/t/slow-down-an-animation/10381/14
  void play(float xpos, float ypos, int w, int h, float delay, boolean loop) {
    if (millis() > previousDisplayTime + (delay*1000)) {        
      frame++;
      if (frame == imageCount && loop) {
        frame = 0;
      } else if (frame == imageCount && !loop) {
        frame = imageCount-1;
      }
      previousDisplayTime = millis();
    }
    image(images[frame], xpos, ypos, w, h);
  }
}
