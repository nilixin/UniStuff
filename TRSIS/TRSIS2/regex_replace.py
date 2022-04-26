import io
import re

f = io.open("sample_text_cyr.txt", mode="r", encoding="utf-8")
text = f.read()                                         # чтение файла в кодировке UTF-8

entries = re.split(r"\b", text)                         # разделение текстовой переменной на список по границам слов

isOdd = True
for i in range(1, len(entries), 2):                     # с шагом 2 прохождение по каждому слову
    cyr_check = re.search(r"[а-я-А-Я]+", entries[i])
    if cyr_check is not None:                           # если слово состоит из кириллических букв
        if isOdd:                                       # и оно нечётное, то изменение регистра
            entries[i] = entries[i].upper()
            isOdd = False
        else:
            isOdd = True

new_text = "".join(str(entry) for entry in entries)     # сборка списка обратно в текстовую переменную
print(new_text)