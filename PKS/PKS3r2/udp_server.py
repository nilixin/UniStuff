import socket

ip = "localhost"
server_port = 8002

s = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
address = (ip, server_port)
s.bind(address)

with s:
    while True:
        data, addr = s.recvfrom(1024)
        data_str = data.decode("utf-8")
        print(f"от {addr}: {data_str}")