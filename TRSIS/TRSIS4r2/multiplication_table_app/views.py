from django.http import HttpResponse
from django.shortcuts import redirect, render
from pickle import dumps, loads
from .forms import ChooseForm, FillForm, TestForm
from .models import Test

new_test = None

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

            global new_test
            new_test.questions.append(new_questions)
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
    if request.method == 'POST':
        questions_serialized = dumps(new_test) # сериализация объекта new_test класса Test
        addable_test = Test(title=new_test.title, shortcut=new_test.shortcut, quant=new_test.quant, questions_field=questions_serialized)
        addable_test.save() # сохранение в бд
        return redirect('index')
    else:
        return render(request, 'confirm.html', {'new_test': new_test})

def choose(request):
    # ✓ Предложить список тестов /choose 
    # Пользователь выбирает понравившийся ему тест /choose
    # Тест подгружается и отсылается в форму /choose/<shortcut>/<quant>/<num>

    if request.method == 'POST':
        choose_form = ChooseForm(request.POST)

        if choose_form.is_valid():
            cd = choose_form.cleaned_data
            chosen = cd['chosen']
            return HttpResponse(content=f'<h1>{chosen}</h1>')
            # TODO переделать обработку выбранного теста
            # нихрена не перемещает, потому что этому полю ничего не присваивается
            # я присваиваю значение input'у, который не входит в форму, а посему не возвращается
            # вместо того, чтобы использовать модель (как дебил), 
            # я должен понять как возвращать значения input'ов из templat'ов в views
        else:
            return HttpResponse(content='<h1>Form is not valid</h1>')
    else:
        tests = Test.objects.all()

        for test in tests:
            test.questions = loads(test.questions_field)

        choose_form = ChooseForm
        return render(request, 'choose.html', {'choose_form': choose_form, 'tests': tests})

#def take(request):