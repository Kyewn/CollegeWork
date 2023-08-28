class Button {
  int x;
  int y;
  int totalWidth;
  int totalHeight;
  String text;
  color textColor;
  color backgroundColor;
  
  // Constructor
  Button(int x, int y, int w, int h, String t, color tc, color bc) {
    this.x = x;
    this.y = y;
    this.totalWidth = w;
    this.totalHeight = h;
    this.text = t;
    this.textColor = tc;
    this.backgroundColor = bc;
  }
  
  // Getter methods
  int getX() { return x; }
  int getY() { return y; }
  int getTotalWidth() { return totalWidth; }
  int getTotalHeight() { return totalHeight; }
  String getText() { return text; }
  color getTextColor() { return textColor; }
  color getBackgroundColor() { return backgroundColor; }
  
  // Setter methods
  void setX(int x) { this.x = x; }
  void setY(int y) { this.y = y; }
  void setTotalWidth(int w) { this.totalWidth = w; }
  void setTotalHeight(int h) { this.totalHeight = h; }
  void setText(String t) { this.text = t; }
  void setTextColor(color tc) { this.textColor = tc; }
  void setBackgroundColor(color bc) { this.backgroundColor = bc; }
  
  void display() {
    stroke(255);
    strokeWeight(3);
    
    // Set backgroundColor based on hover state
    if (isHovered())
      fill(backgroundColor, 170);
    else
      fill(backgroundColor, 255);
   
    rect(x, y, totalWidth, totalHeight, 4);
    fill(textColor);
    textAlign(CENTER, CENTER);
    text(text, x+totalWidth/2, y+totalHeight/2.3);
  }
  
  boolean isHovered() {
    if ((mouseX > x) && (mouseX < x+totalWidth) && (mouseY > y) && (mouseY < y+totalHeight))
      return true;
    else
      return false;
  }
}
