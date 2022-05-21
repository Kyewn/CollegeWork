// Week 4b

// Bouncing ball class

// Two ball variables
Ball ball1;
Ball ball2;

void setup() {
  size(640,360);
  
  // Initialize balls
  ball1 = new Ball(64);
  ball2 = new Ball(32);
}

void draw() {
  background(255);
  
  // Move and display balls
  ball1.move();
  ball2.move();
  ball1.display(ball2);
  ball2.display(ball1);
}
