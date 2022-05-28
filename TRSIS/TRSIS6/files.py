import os, sys, time, re
import shutil as sh
from colorama import Fore, Style

def walk_thru_files(root):
    for dirpath, dirnames, filenames in os.walk(root):
        for filename in filenames:
            yield os.path.join(dirpath, filename)

def read_file(filepath):
    try:
        afile = open(filepath, 'r')
        try:
            return afile.read()
        except Exception as ex:
            return ex
        finally:
            afile.close()
    except Exception as ex:
        return ex

# Проверка файла либо по указанному текстовому соответствию (pattern) если файл содержит указанную строку,
# либо по функции отбора (selector), которой передаётся содержимое файла (content)
# и которая возвращает True, если условие внутри этой функции отбора пройдено
def select_file(filepath, pattern=None, selector=None):
    try:
        afile = open(filepath, 'r')
        try:
            content = afile.read()
            if pattern:                                             # проверка по текстовому соответствию
                if pattern in content:
                    return filepath
                else:
                    return None
            else:                                                   # проверка по функции отбора
                if selector(filepath=filepath, content=content):
                    return filepath
                else:
                    return None
        except:
            return None
        finally:
            afile.close()
    except:
        return None

def print_info(i, filepath):
    size = os.path.getsize(filepath)                                # размер файла
    ctime = time.ctime(os.path.getctime(filepath))                  # время создания файла
    mtime = time.ctime(os.path.getmtime(filepath))                  # время изменения файла
    content = read_file(filepath)
    print(f'{i} | {filepath} |size {size} |ctime {ctime} |mtime {mtime}')
    if content and content.strip():                                 # вывод содержимого
        print(Fore.GREEN, f'\tcontent:\n{content}')
        print(Style.RESET_ALL)

# Функция отбора, одобряющая все вхождения
def selector_altruist(**args):
    return True

# Функция отбора, одобряющая только те вхождения, где content содержит две и более заглавные буквы
def selector_uppercase(**args):
    # True если слово состоит из двух и более заглавных букв
    return re.search(r'[A-Z]{2,}', args.get('content'))

# Функция отбора, одобряющая только те вхождения, где content содержит две и более заглавные буквы
# и две точки в названии файла
def selector_uppercase_and_dot(**args):
    contains_uppercase = re.search(r'[A-Z]{2,}', args.get('content'))
    has_dots_in_filepath = re.search(r'[a-zA-Z0-9]*(\.\.)+[a-zA-Z0-9]*[.][a-zA-Z]*', args.get('filepath'))
    return contains_uppercase and has_dots_in_filepath
    


root = sys.argv[1]
# root = 'C:\\Users\\knexit\\Dumcode\\Etc\\files_root\\'

filepaths = [filename for filename in walk_thru_files(root)]        # создание генератора путей к файлам
were_selected = 0
for i, filepath in enumerate(filepaths):
    # if select_file(filepath, pattern='lorem'):
    if select_file(filepath, selector=selector_uppercase_and_dot):          # < здесь можно передавать разные функции отбора (селекторы)
        print_info(i, filepath)
        were_selected += 1
print(were_selected)