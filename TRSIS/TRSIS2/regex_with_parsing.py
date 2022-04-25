import re

# Вариант 2. "Выдать на печать строки файла,
# в которых в пятом слове три буквы "а", 
# не обязательно подряд идущих."

def main():
    lines = []
    matching_lines = []

    with open("sample_text.txt", "r") as file:
        for line in file:
            current_line = line[:-1]
            lines.append(current_line)

    for line in lines:
        # ^([a-zA-Z']+\s){4}(\w*[a]\w*)([a]\w*)([a]\w*)                     первые пять слов согласно паттерну
        # ^([a-zA-Z']+\s){4}(\w*[a]\w*)([a]\w*)([a]\w*)([a-zA-Z']+[\W])+    вся строка согласно паттерну, задание
        # ^([a-zA-Z']+\s){4}(\w*[a]\w*)([a]\w*){2}([a-zA-Z']+[\W])+
        pattern = r"^([a-zA-Z']+\s){4}(\w*[a]\w*)([a]\w*){2}([ a-zA-Z']+[\W])+" # ПАТТЕРН СЮДА
        result = re.search(pattern, line)

        if result is not None:
            matching_lines.append(result)
    

    for matching_line in matching_lines:
        print(matching_line)



main()
