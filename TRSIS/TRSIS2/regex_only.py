import re

# Вариант 2. "Выдать на печать строки файла,
# в которых в пятом слове три буквы "а", 
# не обязательно подряд идущих."

def main():
    with open("sample_text.txt", "r") as file:
        text = file.read()

    # https://regex101.com/ тестирование regex
    # ^(\w+\s){4}([a-z]+)
    # \n(\w+\s){4}(\w+)                                             с первого по пятое слово
    # \n([a-zA-Z']+\s){4}(\w+)([a]{3}\w+)                           с первого по пятое слово, где пятое содержит три "а" подряд
    # \n([a-zA-Z']+\s){4}(\w*[a]\w*)([a]\w*)([a]\w*)                с первого по пятое слово, где пятое содержит хотя бы три "а" в случайном порядке
    # [a-zA-Z0-9'\"\"’\s-]+[.]                                      все слова до точки
    # ([a-zA-Z']+\s){4}(\w*[a]\w*)([a]\w*){2}([ a-zA-Z']+[\W])+     задание
    # ([a-zA-Z']+\s){4}(\w*[a]\w*){3}([ a-zA-Z']+[\W])+             задание короче
    pattern = r"([a-zA-Z']+\s){4}(\w*[a]\w*){3}([ a-zA-Z']+[\W])+" # ПАТТЕРН СЮДА
    matches = re.finditer(pattern, text)

    print_everything(matches)
    

def print_everything(matches):
    count = 0
    for match in matches:
        count += 1
        print(f"{count} {match.group()}")


def print_simplified(matches):
    count = 1
    limit = 10
    for match in matches:
        count += 1
        if count < limit:
            print(f"{count} {match}")
        elif count == limit:
            print("... и так далее ...")

    print(f"всего {count - 1} совпадений")
    

main()
