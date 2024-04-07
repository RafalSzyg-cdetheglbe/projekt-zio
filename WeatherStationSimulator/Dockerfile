FROM python:3.11

ENV stationId="default_station"
ENV latitude="0"
ENV longitude="0"
ENV serverIp="localhost"
ENV path=""
ENV seed="0"

# Kopiowanie plików aplikacji
COPY WeatherStationSimulator.py /app/

# Ustawianie katalogu roboczego
WORKDIR /app

# Instalacja zależności
RUN pip install requests

# Uruchomienie aplikacji
CMD ["python", "WeatherStationSimulator.py"]
