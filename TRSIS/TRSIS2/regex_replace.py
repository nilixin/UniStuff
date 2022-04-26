import io
import re

f = io.open("sample_text_cyr.txt", mode="r", encoding="utf-8")
text = f.read() # чтение файла в кодировке UTF-8

entries = re.split(r"\b", text) # разделение текстовой переменной на список по границам слов

for i in range(1, len(entries), 4):
    entries[i] = entries[i].upper() # с шагом "4" изменение регистра элемента

new_text = "".join(str(entry) for entry in entries) # сборка списка обратно в текстовую переменную
print(new_text)