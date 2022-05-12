import socket

ip = "localhost"
server_port = 8002

s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
address = (ip, server_port)
s.bind(address)
print(f"привязано к {ip} {server_port}")

s.listen(1)

con, addr = s.accept()
print("подключено")

while True:
    data = con.recv(1024)
    
    if len(data) == 0:
        print("данных не получено")
        con.close()
        break

    data_str = data.decode("utf-8")
    print(f"от {addr}: {data_str}")

print("отключение")
s.close()
