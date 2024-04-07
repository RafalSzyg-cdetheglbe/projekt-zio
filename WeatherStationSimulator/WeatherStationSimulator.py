import json
import random
from datetime import datetime
import requests
import os
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


stationId =  os.environ.get('stationId','stacja1')
latitude = os.environ.get('latitude','0')
longitude =  os.environ.get('longitude','0')
serverIp = os.environ.get('serverIp','localhost')
path = os.environ.get('path','')
seed = os.environ.get('seed','0')
url = f"{serverIp}/{path}"

while True:
    weatherData = generateWeatherData(stationId, latitude, longitude, seed)
    print(weatherData)
    try:
        response = requests.post(url, json=weatherData)
    except Exception as e:
        print("Wystąpił wyjątek:", e)
    else:
        if response.status_code == 200:
            print("Dane zostały pomyślnie wysłane")
        else:
            print("Wystąpił problem podczas wysyłania danych na serwer", response.status_code)
    finally:
        time.sleep(2)

