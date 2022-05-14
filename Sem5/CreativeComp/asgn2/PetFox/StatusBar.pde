public class StatusBar {
  int x;
  int y;
  int barWidth;
  int barHeight;
  int iconWidth;
  int iconHeight;
  float valuePercent;
  float depletionSpeed;
  PImage icon;
  int stage;
  String description;
  color barColor;
  color strokeColor;
  
  // Constructor
  StatusBar(int x, int y, int bw, int bh, int iw, int ih, float vp, float ds, PImage i, int s, String d, color bc, color sc) {
    this.x = x;
    this.y = y;
    this.barWidth = bw;
    this.barHeight = bh;
    this.iconWidth = iw;
    this.iconHeight = ih;
    this.valuePercent = vp;
    this.depletionSpeed = ds;
    this.icon = i;
    this.stage = s;
    this.description = d;
    this.barColor = bc;
    this.strokeColor = sc;
  }
  
  // Getter methods
  int getX() { return x; }
  int getY() { return y; }
  int getBarWidth() { return barWidth; }
  int getBarHeight() { return barHeight; }
  int getIconWidth() { return iconWidth; }
  int getIconHeight() { return iconHeight; }
  float getValuePercent() { return valuePercent; }
  float getDepletionSpeed() { return depletionSpeed; }
  PImage getIcon() { return icon; }
  int getStage() { return stage; }
  String getDescription() { return description; }
  color getBarColor() { return barColor; }
  color getStrokeColor() { return strokeColor; }
  
  // Setter methods
  void setX(int x) { this.x = x; }
  void setY(int y) { this.y = y; }
  void setBarWidth(int bw) { this.barWidth = bw; }
  void setBarHeight(int bh) { this.barHeight = bh; }
  void setIconWidth(int iw) { this.iconWidth = iw; }
  void setIconHeight(int ih) { this.iconHeight = ih; }
  void setValuePercent(float vp) {
    this.valuePercent = vp;
    if (this.valuePercent >= 1)
      this.valuePercent = 1;
  }
  void setDepletionSpeed(float ds) { this.depletionSpeed = ds; }
  void setIcon(PImage i) { this.icon = i; }
  void setStage(int s) { this.stage = s; }
  void setDescription(String d) { this.description = d; }
  void setBarColor(color bc) { this.barColor = bc; }
  void setStrokeColor(color sc) { this.strokeColor = sc; }
  
  void display() {
    image(icon, x, y-iconHeight/4, iconWidth, iconHeight);
    // Bar container
    fill(barColor, 100);
    stroke(strokeColor);
    strokeWeight(5);
    rect(x+iconWidth+10, y, barWidth, barHeight, 10);
    // Bar filler
    fill(barColor);
    noStroke();
    rect(x+iconWidth+12, y+3, map(valuePercent, 0, 1, 0, barWidth-3), barHeight-5, 10);
    // Design elements
    fill(255, 225);
    rect(x+iconWidth+20, y+6, 30, 5, 30);
    // Update status bar based on valuePercent
    if (valuePercent < 0)
      valuePercent = 0; // cap valuePercent to lower limit
    else if (valuePercent > 1)
      valuePercent = 1; // cap valuePercent to upper limit
    else if (valuePercent >= 0)
      valuePercent -= depletionSpeed; // deplete status bar overtime
  }
  
  boolean isFull() {
    if (valuePercent == 1)
      return true;
    else
      return false;
  }
  
  boolean isEmpty() {
    if (valuePercent == 0)
      return true;
    else
      return false;
  }
}
