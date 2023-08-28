PFont f;

import ddf.minim.*;
Minim minim;
AudioPlayer s1,s2,s3,s4,s5;

void setup() {
  size(400,400);
  f = loadFont("f.vlw");
  textFont(f, 24);
  textAlign(CENTER,CENTER);
  
  minim = new Minim(this);
  s1 = minim.loadFile("t1.wav");
  s2 = minim.loadFile("t2.wav");
  s3 = minim.loadFile("t3.wav");
  s4 = minim.loadFile("t4.wav");
  s5 = minim.loadFile("t5.wav");
}

void draw() {
  SquareButtons();
}

void SquareButtons() {
  for (int x=0; x < width; x += width/2) {
    for (int y=0; y < height; y += height/2) {
      String text;
      color clr;
      if (x >= width/2 && y < height/2) {
        text = "Screech";
        clr = color(0,255,0);
      } else if (x < width/2 && y >= height/2) {
        text = "Boom";
        clr =color(0,0,255);
      } else if (x >= width/2 && y >= height/2) {
        text = "Thud";
        clr =color(255,255,0);
      } else {
        text = "Bang";
        clr =color(255,0,0);
      }
      textSize(24);
      fill(clr);
      rect(x,y,width/2,height/2);
      fill(0);
      text(text, x+width/4, y+height/4);
    }
  }
  fill(180,180,180);
  rect(width/2-60, height/2 - 60, 120, 120);
  fill(0);
  text("Boink", 200, 200);
}

void mousePressed() {
  if (mouseX >= width/2 - 60 && mouseX <= width/2 + 60 && mouseY <= height/2 + 60 && mouseY >= height/2 - 60) {
     s5.play();
  } else if (mouseX < width/2) {
    if (mouseY > height/2) {
      s2.play();
    } else {
      s1.play();
    }
  } else {
    if (mouseY < height/2) {
      s3.play();
    } else {
      s4.play();
    }
  }
}

void mouseReleased() {
  s1.pause();
  s1.rewind();
  s2.pause();
  s2.rewind();
  s3.pause();
  s3.rewind();
  s4.pause();
  s4.rewind();
  s5.pause();
  s5.rewind();
}
