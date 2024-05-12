FROM python:3.11

ENV stationName="default_station"
ENV latitude="0"
ENV longitude="0"
ENV serverIp="127.0.0.1"
ENV port = "7013"
ENV seed="0"

# Kopiowanie plików aplikacji
COPY WeatherStationSimulator.py /app/

# Ustawianie katalogu roboczego
WORKDIR /app

# Instalacja zależności
RUN pip install requests

# Uruchomienie aplikacji
CMD ["python", "WeatherStationSimulator.py"]
