import json
import random
from datetime import datetime
import requests
import time

def generateWeatherData(stationId, latitude, longitude, seed=None):
    if seed is not None:
        random.seed(seed)

    timestamp =  datetime.now().isoformat()    
    temperature =  random.uniform(-10, 50)
    humidity =   random.uniform(0, 100)
    windSpeed = random.uniform(20, 150)
    atmosphericPressure =  random.uniform(900, 1050)
    rainfall =  random.uniform(0, 100)

    random.seed()

    temperature =  round(random.uniform(-2, 2) + temperature,2)
    humidity =  round(random.uniform(0, 10) + humidity,2)
    windSpeed =  round(random.uniform(-5, 5) + windSpeed,2)
    atmosphericPressure =  round(random.uniform(0, 100) + atmosphericPressure,2)
    rainfall = round( random.uniform(-5,5) + rainfall,2)
    
    data = {
        "stationId": stationId,
        "latitude": latitude,
        "longitude": longitude,
        "timestamp": timestamp,
        "temperature": temperature,
        "humidity": humidity,
        "windSpeed": windSpeed,
        "atmosphericPressure": atmosphericPressure,
        "rainfall":rainfall,
    }
    return data


stationId = "stacja1"
latitude = 50.22909423082472
longitude = 18.666159245439527
serverIp = "af1a4605-47ef-4b9b-9986-d675d7b715c1.mock.pstmn.io"
path = "back"
url = f"https://{serverIp}/{path}"
seed = 2137

while True:
    weatherData = generateWeatherData(stationId, latitude, longitude, seed)
    print(weatherData)
   
    response = requests.post(url, json=weatherData)
    if response.status_code == 200:
         print("Dane zostały pomyślnie wysłane")
    else:
         print("Wystąpił problem podczas wysyłania danych na serwer", response.status_code)
    time.sleep(2)

