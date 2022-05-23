from django.http import HttpResponse
from django.shortcuts import redirect, render
from pickle import dumps, loads
import mimetypes
from .forms import FillForm, TestForm, TakeForm
from .models import Test

new_test = None
questions = list()
takeable_test = None
takeable_questions = list()
user_responses = list()
response_str = str()

def index(request):
    return render(request, 'index.html')

def compose(request):
    if request.method == 'POST':
        test_form = TestForm(request.POST)
        if test_form.is_valid():
            cd = test_form.cleaned_data
            global new_test
            new_test = Test(title=cd['title'], shortcut=cd['shortcut'], quant=cd['quant'])
            return redirect('ask', shortcut=cd['shortcut'], quant=cd['quant'], num=1)
        else:
            return HttpResponse(content='<h1>Form is not valid</h1>')
    else:
        test_form = TestForm
        return render(request, 'compose.html', {'test_form': test_form})

# Поочерёдное заполнение списка questions в объекте new_test класса Test
def fill(request, shortcut, quant, num):
    if request.method == 'POST': # метод POST
        fill = FillForm(request.POST)

        if fill.is_valid():
            cd = fill.cleaned_data
            new_questions = {
                'question': cd['question'],
                'first_answer': cd['first_answer'],
                'second_answer': cd['second_answer'],
                'third_answer': cd['third_answer'],
                'fourth_answer': cd['fourth_answer'],
                'correct': cd['correct']
            }

            questions.append(new_questions)
        else:
            return HttpResponse(content='<h1>Form is not valid</h1>')
        
        num_int = int(num)
        quant_int = int(quant)
        num_int += 1
        num_str = str(num_int)

        if num_int > quant_int: # если номер вопроса превышает заданное пользователем кол-во вопросов, то выход из метода
            return redirect('confirm', shortcut=shortcut)
        else: # если нет, то переход к вводу следующего вопроса
            return redirect('ask', shortcut=shortcut, quant=quant, num=num_str)
    else: # метод GET
        fill_form = FillForm
        return render(request, 'compose.html', {'fill_form': fill_form, 'shortcut': shortcut, 'quant': quant, 'num': num})

def confirm(request, shortcut):
    if request.method == 'POST': # метод POST, сохраняет тест в БД
        # questions_serialized = dumps(new_test.questions_field) # сериализация объекта new_test класса Test
        # addable_test = Test(title=new_test.title, shortcut=new_test.shortcut, quant=new_test.quant, questions_field=questions_serialized)
        # addable_test.save() # сохранение в бд
        # return redirect('index')
        
        questions_serialized = dumps(questions)
        addable_test = Test(title=new_test.title, shortcut=new_test.shortcut, quant=new_test.quant, questions_field=questions_serialized)
        addable_test.save()

        return redirect('index')
    else: # метод GET, отображает форму подтверждения создания теста
        return render(request, 'confirm.html', {'new_test': new_test, 'questions': questions})

def choose(request):
    # ✓ Предложить список тестов /choose 
    # Пользователь выбирает понравившийся ему тест /choose
    # Тест подгружается и отсылается в форму /choose/<shortcut>/<quant>/<num>
    user_responses.clear()
    
    tests = Test.objects.all()

    try: # пользователь подтвердил выбор теста
        shortcut = request.GET['shortcut']
        
        for test in tests:
            if test.shortcut == shortcut:
                global takeable_test
                takeable_test = test

        return redirect('take', shortcut=shortcut, quant=takeable_test.quant, num=1)
    except: # пользователю предстоит выбрать тест
        return render(request, 'choose.html', {'tests': tests})

def take(request, shortcut, quant, num):
    if request.method == 'POST':
        take_form = TakeForm(request.POST)

        if take_form.is_valid():
            cd = take_form.cleaned_data
            chosen = cd['chosen']

            # проверяет правильность ответа и заносит в user_responses
            num_int = int(num) - 1
            global takeable_questions
            takeable_question = takeable_questions[num_int]
            isCorrect = False
            if chosen == takeable_question['correct']:
                isCorrect = True
            one_response = {f'{chosen}': isCorrect}
            user_responses.append(one_response)
        else:
            return HttpResponse(content='<h1>Form is not valid</h1>')

        num_int = int(num)
        quant_int = int(quant)
        num_int += 1
        num_str = str(num_int)

        if num_int > quant_int:
            return redirect('results')
        else:
            return redirect('take', shortcut=shortcut, quant=quant, num=num_str)
    else:
        take_form = TakeForm
        global takeable_test
        takeable_questions = loads(takeable_test.questions_field)

        takeable_questions_str = str()
        num_int = int(num) - 1
        takeable_question = takeable_questions[num_int]
        for value in takeable_question:
            if value == 'correct':
                break
            takeable_questions_str += f'{value} : "{takeable_question[value]}"\r\n'

        return render(request, 'take.html', {'take_form': take_form, 'takeable_test': takeable_test, 'quant': quant, 'num': num, 'takeable_questions_str': takeable_questions_str})

def results(request):
    try:
        # num_int = int(num) - 1
        # global takeable_questions
        # takeable_question = takeable_questions[num_int]
        
        global user_responses
        global takeable_questions
        global response_str
        response_str = str()

        answered_question_num = 0
        for response in user_responses:
            question = takeable_questions[answered_question_num]
            answer_num = next(iter(response))
            answer_str = str()
            if answer_num == '1':
                answer_str = question['first_answer']
            elif answer_num == '2':
                answer_str = question['second_answer']
            elif answer_num == '3':
                answer_str = question['third_answer']
            elif answer_num == '4':
                answer_str = question['fourth_answer']

            response_str += f'{answered_question_num + 1} {question["question"]} {answer_num} {answer_str} {user_responses[answered_question_num]}'

            answered_question_num += 1

        return render(request, 'results.html', {'response_str': response_str})
    except:
        pass
    finally:
        user_responses.clear()

def download(request):
    with open('results_file.txt', 'w'):
        mime_type, _ = mimetypes.guess_type('results_file.txt')
        response = HttpResponse(content=response_str, content_type=mime_type)
        response['Content-Disposition'] = "attachment; filename=%s" % './results_file.txt'
        return response