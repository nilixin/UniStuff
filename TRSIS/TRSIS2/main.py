import re


# Вариант 2. "Выдать на печать строки файла,
# в которых в пятом слове три буквы "а", 
# не обязательно подряд идущих."

def main():
    with open("sample_text.txt", "r") as file:
        text = file.read()

    # https://regex101.com/ тестирование regex
    pattern = re.compile(r"^(\w+\s){5}")  # ПАТТЕРН СЮДА
    matches = pattern.finditer(text)

    count = 1
    limit = 10
    for match in matches:
        count += 1
        if count < limit:
            print(f"{count} {match}")
        elif count == limit:  # превышение лимита
            print("... и так далее ...")

    print(f"всего {count - 1} совпадений")  # общее количество совпадений


main()
