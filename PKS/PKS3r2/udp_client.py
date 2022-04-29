import socket

ip = "localhost"
client_port = 8001
server_port = 8002

s = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
address = (ip, client_port)
s.bind(address)

while True:
    message = input("напишите сообщение: ")
    b = bytes(message, "utf-8")
    s.sendto(b, (ip, server_port))