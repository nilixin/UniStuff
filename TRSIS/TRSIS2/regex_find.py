import re

with open("sample_text.txt", "r") as file:
        text = file.read()

pattern = r"([a-zA-Z']+\s){4}(\w*[a]\w*){3}([ a-zA-Z']+[\W])+" # ПАТТЕРН СЮДА
matches = re.finditer(pattern, text)

count = 0
for match in matches:
    count += 1
    print(f"{count} {match.group()}")