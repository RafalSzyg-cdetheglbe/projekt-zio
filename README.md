# projekt-zio

During container creation, it is possible to add appropriate environment variables:

stationId - the identification name of the surface station
latitude - geographic latitude in degrees
longitude - geographic longitude in degrees
serverIp - the IP address to which data is sent
path - server path
seed - the base seed used to generate data

Creating an image based on a Dockerfile:
    docker build -t weatherstation .

Example container creation based on the image:
    docker run -e "serverIp=https://726c2716-cc3e-490f-b94d-7833bf8ecbb2.mock.pstmn.io" -e "latitude=50" -e "longitude=32" weatherstation
