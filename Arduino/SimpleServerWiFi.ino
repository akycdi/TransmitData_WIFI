// #include <WiFi.h>
// #include <WiFiUdp.h>

// char ssid[] = "Arun";
// char pass[] = "12345678";

// unsigned int localPort = 5001;

// WiFiUDP Udp;

// void setup() {
//   Serial.begin(115200);
//   WiFi.begin(ssid, pass);
//   while (WiFi.status() != WL_CONNECTED) {
//     delay(1000);
//     Serial.println("Connecting to WiFi...");
//   }

//   Serial.println("WiFi connected");
// }

// void loop() {
//   char randomData[12];
//   if (Serial.available()) {
//     for (int i = 0; i < 12; i++) {
//       randomData[i] = Serial.read();
//     }
//   }
//   Udp.beginPacket(IPAddress(255, 255, 255, 255), localPort);
//   Udp.write(randomData, sizeof(randomData));
//   Udp.endPacket();
// }


#include <WiFi.h>

char ssid[] = "Arun";
char pass[] = "12345678";

unsigned int serverPort = 5001;
 
WiFiServer server(serverPort);
WiFiClient client;

void setup() {
  Serial.begin(115200);
  WiFi.begin(ssid, pass);
  while (WiFi.status() != WL_CONNECTED) {
    delay(1000);
    Serial.println("Connecting to WiFi...");
  }

  Serial.println("WiFi connected");

  server.begin(); // Start the TCP server
}

void loop() {
  if (!client.connected()) {
    client = server.available(); // Check for a new client connection
  }

  if (client.connected() && client.available()) {
    char receivedData[12];

    // Read data from the client (PC) and store it in receivedData
    int bytesRead = client.readBytes(receivedData, sizeof(receivedData));
    receivedData[bytesRead] = '\0'; // Null-terminate the string

    // Process and do something with the received data (e.g., print it)
    Serial.println("Received data: " + String(receivedData));
  }

  // Send data from Serial to the connected client
  if (Serial.available() && client.connected()) {
    char sendData[12];
    int bytesRead = Serial.readBytes(sendData, sizeof(sendData));

    // Write data to the client (PC)
    client.write(sendData, bytesRead);
  }
}


