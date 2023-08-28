String str;
PFont font;

void setup() {
  size(500,500);
  font = loadFont("f.vlw");
  textFont(font, 35);
  fill(140);
  str = "";
}

void draw() {
  background(255,0,140);
  fill(255);
  text("User input: "+str, 10,30);
  text("Count of chars: "+ str.length(), 10,500);
}

void keyPressed() {
  if (keyCode == DELETE || keyCode == BACKSPACE) {
    if (str.length() > 0) {
      str = str.substring(0,str.length()-1);
    }
  } else {
    str += key + "";
  }
}
