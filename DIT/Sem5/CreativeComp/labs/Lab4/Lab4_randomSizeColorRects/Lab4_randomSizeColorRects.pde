//Create random shapes with random color using user funcs and arrs
final int MAX = 5;
int a[];
int b[];
color col[];

void setup() {
  size(500,500);
  a = new int[MAX];
  b = new int[MAX];
  col = new color[MAX];
  initializeIntegerArray(a);
  initializeIntegerArray(b);  
  initializeColorArray();
  drawShapes();
}

void initializeIntegerArray(int arr[]) {
  for (int i=0;i<arr.length;i++) {
    arr[i] = int(random(width));
  }
}

void initializeColorArray() {
  for (int i=0;i<col.length;i++) {
    col[i] = color(int(random(255)), int(random(255)), int(random(255)));
  }
}
void drawShapes() {
  for (int i=0; i < a.length; i++) {
    fill(col[i]);
    rect(a[i], b[i],random(width/5), random(height/5));
  }
}
