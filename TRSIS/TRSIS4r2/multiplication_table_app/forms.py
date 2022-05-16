from django import forms

class TestForm(forms.Form):
    title = forms.CharField(label='Название теста')
    shortcut = forms.CharField(label='Ссылка')
    quant = forms.IntegerField(label='Количество вопросов')

class FillForm(forms.Form):
    question = forms.CharField(label='Вопрос')
    first_answer = forms.CharField(label='Первый вариант ответа')
    second_answer = forms.CharField(label='Второй вариант ответа')
    third_answer = forms.CharField(label='Третий вариант ответа')
    fourth_answer = forms.CharField(label='Четвёртый вариант ответа')

    CHOICES = [
        (1, 'Первый'),
        (2, 'Второй'),
        (3, 'Третий'),
        (4, 'Четвёртый')
    ]

    correct = forms.ChoiceField(choices=CHOICES, widget=forms.RadioSelect, label='Правильный ответ')

class ChooseForm(forms.Form):
    chosen = forms.CharField(disabled=True, required=False)