



// Copied and Pasted from the Minim API for 
// Manual: AudioRecorder

import ddf.minim.*;
 
Minim minim;
AudioInput in;
AudioRecorder recorder;
 
void setup()
{
  size(512, 200);
 
  minim = new Minim(this);

  in = minim.getLineIn(Minim.STEREO);

  recorder = minim.createRecorder(in, "s.wav", true);
 
  textFont(createFont("Arial", 12));
  textAlign( CENTER );
  println(in.left.size());
}
 
void draw()
{
  background(0);
  stroke(255);
  for(int i = 0; i < in.left.size()-1; i++)
  {
    // Create waveforms left + right (stereo)
    line(i, 50 + in.left.get(i)*50, i+1, 50 + in.left.get(i+1)*50);
    line(i, 150 + in.right.get(i)*50, i+1, 150 + in.right.get(i+1)*50);
}
 
  if ( recorder.isRecording() )
  {
    text("Currently recording...   Press [r] to stop recording.", width/2, 15);
  }
  else
  {
    text("Not recording.   Press [r] to start recording.   Press [s] to save recording.", width/2, 15);
  }
}
 
void keyReleased()
{
  if ( key == 'r' )
  {
    if ( recorder.isRecording() )
    {
      recorder.endRecord();
      println("Recording stopped BUT not saved.");
    }
    else
    {
      recorder.beginRecord();
      println( "Recording started.");
    }
  }
  else if ( key == 's' )
  {
   
    recorder.save();
    text( "Sound file is saved.   Press [c] to continue recording session.    Press [esc] to stop program", width/2, height*.8);
    noLoop( );  
  }
  else if ( key == 'c' )
  {
     loop( ); 
  }
}
 
void stop()
{
  // always close Minim audio classes when you are done with them
  in.close();
  // always stop Minim before exiting
  minim.stop();
 
  super.stop();
}
