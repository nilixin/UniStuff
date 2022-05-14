from django.http import HttpResponse
from django.shortcuts import redirect, render
from .forms import QuestionForm
from .forms import EnterForm
from .models import FullName

# Главная страница
def index(request):
    if request.method == "POST":
        enter_questions = request.POST.get("enter_questions", None)
        answer_questions = request.POST.get("answer_questions", None)

        if enter_questions: # если нажата кнопка "Ввести вопросы"
            enter_form = EnterForm
            # TODO НЕПРАВИЛЬНО, НУЖНО ИСПОЛЬЗОВАТЬ redirect() наверное
            return render(request, "test_app/enter_questions.html", {"form": enter_form})
        elif answer_questions: # если нажата кнопка "Ответить на вопросы"
            question_form = QuestionForm
            return render(request, "test_app/question.html", {"form": question_form})
    else:
        return render(request, "index.html")

# Страница, где пользователь вводит вопросы
def enter_questions(request):
    if request.method == "POST":
        number_of_questions = request.POST.get("number_of_questions")

        enter_form = EnterForm
        return render(request, "test_app/enter_questions.html", {"form": enter_form, "number_of_questions": number_of_questions})
    else:
        enter_form = EnterForm
        return render(request, "test_app/enter_questions.html", {"form": enter_form})

# Страница, где пользователь отвечает на вопросы
def question(request):
    if request.method == "POST":
        # name = request.POST.get("name")
        # surname = request.POST.get("surname")
        # new_name = FullName(name=f"{name}", surname=f"{surname}")
        # new_name.save()

        like = request.POST.get("like")

        return HttpResponse(f"<h1>{like}</h1>")
    else:
        question_form = QuestionForm
        return render(request, "test_app/question.html", {"form": question_form})