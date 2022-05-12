import socket

ip = "localhost"
client_port = 8001
server_port = 8002

s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
client_address = (ip, client_port)
server_address = (ip, server_port)

s.bind(client_address)
print(f"привязано к {ip} {client_port}")

s.connect(server_address)
print(f"подключено к {ip} {server_port}")

while True:
    message = input("напишите сообщение: ")

    if len(message) == 0:
        print("сообщение пустое. выход из программы...")
        s.close()
        break

    b = bytes(message, "utf-8")
    s.sendto(b, server_address)