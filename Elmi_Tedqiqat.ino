#include <FreqCount.h>
float deyer,count;
void setup() {
  
  FreqCount.begin(1000);   
  Serial.begin(9600);
}

void loop() {
  if (FreqCount.available()) {                       
    float count = FreqCount.read();
      deyer= count;
      Serial.println(deyer);                       
      delay(1000);
  }
// Serial.print("deyersiz");
//delay(1000);

}
