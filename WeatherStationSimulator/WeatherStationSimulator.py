import random
import requests
import os
import time
import datetime
#Zmienne globalne
latitude = 0.0
longitude = 0.0
serverIp = '127.0.0.1'
port = '7013'
stationId = -1

#Tworzenie nowej stacji pogodowej 
def createNewStation(name):
    url = f'https://{serverIp}:{port}/api/MeteoStations'
    current_time = datetime.datetime.utcnow().isoformat()
    data = {
      "name": name,
      "creator": {
          "id": 1,
          "name": name,
          "login": name,
          "password": name,
          "userType": 0,
          "isActive": True
      },
      "meteoData": [
        {
          "id": 0,
          "name": "",
          "description": "",
          "unit": "",
          "auditData": {
            "id": 0,
            "createdAt": current_time,
            "updatedAt": current_time,
            "lastLoginAt": current_time
          },
          "dataType": 0,
          "value": "",
          "valueType": 0
        }
      ],
      "latitude": latitude,
      "longitude": longitude,
      "auditData": {
          "createdAt": current_time,
          "updatedAt": current_time,
          "lastLoginAt": current_time
      }
    }  

    try:
        response = requests.post(url, json=data, verify=False)
    except Exception as e:
        print("Wystąpił wyjątek:", e)
    else:
        if response.status_code == 200:
            print("Dane stacji zostaly pomyślnie wysłane")
        else:
            print("Wystąpił problem podczas wysyłania stacji na serwer", response.status_code)
    setCoor(stationId)

#Ustawianie aktualnych koordynatów
def setCoor(stationId):
    url = f'https://{serverIp}:{port}/api/MeteoStations/{stationId}/coordinates'
    coordy={
    "latitude": latitude,
    "longitude": longitude
    }

    try:
        response = requests.put(url, json=coordy, verify=False)
    except Exception as e:
        print("Wystąpił wyjątek:", e)
    else:
        if response.status_code == 200:
            print("Dane coordynaty zostaly pomyślnie wysłane")
        else:
            print("Wystąpił problem podczas wysyłania coordynatow na serwer", response.status_code)

#Pobieranie id stacji
def getStationId(name):
    url = f'https://{serverIp}:{port}/api/MeteoStations'

    try:
        response = requests.get(url, verify=False)
        if response.status_code == 200:
            stations = response.json()
            for station in stations:
                if station['name'] == name:
                    return station['id']
         

        else:
            print("Failed to retrieve users. Status code:", response.status_code)
    except Exception as e:
        print("An error occurred:", e)
    createNewStation(name)
    return -1

#Wysyłanie danych do stacji 
def sendData(dataRow, dataValue):
    url = f'https://{serverIp}:{port}/api/MeteoStations/{stationId}/data'
    print(url)
    data={

        "name": valuesDateTypeValueType[dataRow][0],
        "description": valuesDateTypeValueType[dataRow][0],
        "unit": valuesDateTypeValueType[dataRow][1],
        "auditData": {
            "id": 0,
            },
        "dataType":  valuesDateTypeValueType[dataRow][2],
        "value": str(dataValue),
        "valueType":  valuesDateTypeValueType[dataRow][3]
      }
    try:
        response = requests.post(url, json=data, headers={'Content-Type': 'application/json'}, verify=False)

        if response.status_code == 200:
            print("ok")
        else:
            print("Failed. Status code:", response.status_code)
    except Exception as e:
        print("An error occurred:", e)
    


#Generowanie danych 
def generateWeatherData(stationId,seed=None):
    if seed is not None:
        random.seed(seed)
        
    temperature =  random.uniform(-10, 50)
    humidity =   random.uniform(0, 100)
    windSpeed = random.uniform(20, 150)
    atmosphericPressure =  random.uniform(940, 1030)
    rainfall =  random.uniform(0, 100)

    random.seed()

    temperature =  round(random.uniform(-2, 2) + temperature,2)
    humidity =  round(random.uniform(0, 10) + humidity,2)
    windSpeed =  round(random.uniform(-5, 5) + windSpeed,2)
    atmosphericPressure =  round(random.uniform(-5, 5) + atmosphericPressure,2)
    rainfall = round( random.uniform(-5,5) + rainfall,2)
    
    data = {
        "temperature": temperature,
        "humidity": humidity,
        "windSpeed": windSpeed,
        "atmosphericPressure": atmosphericPressure,
        "rainfall":rainfall,
    }

    return data

stationName =  os.environ.get('stationName','Meteo Stacja 2')
latitude = os.environ.get('latitude','50.259')
longitude =  os.environ.get('longitude','19.015')
serverIp = os.environ.get('serverIp','localhost')
port = os.environ.get('port','7013')
seed = os.environ.get('seed','2')

#Nazwa Jednostka  MeteoDataType MeteoValueType
valuesDateTypeValueType =[
    ["temperature",'C',0,1],
    ["humidity",'%',1,2],
    ["wind speed",'km/h',2,1],
    ["pressure",'hPa',3,1],
    ["rainfall",'%',4,2],
    ]

while stationId==-1:
    stationId = getStationId(stationName)
    time.sleep(5)

    
while True:   
    data = generateWeatherData(stationId,seed)
    sendData(0,data["temperature"])
    sendData(1,data["humidity"])
    sendData(2,data["windSpeed"])
    sendData(3,data["atmosphericPressure"])
    sendData(4,data["rainfall"])
    time.sleep(2)