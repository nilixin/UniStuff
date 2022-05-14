from django import forms

class EnterForm(forms.Form):
    number_of_questions = forms.IntegerField(label="Количество вопросов")

class EnterFormGenerated(forms.Form):
    pass

class QuestionForm(forms.Form):


    question = "Выбирите свой привет!"
    entry1 = "Привет1"
    entry2 = "Привет2"
    entry3 = "Привет3"
    entry4 = "Привет4"

    # name = forms.CharField(label="Имя")
    # surname = forms.CharField(label="Фамилия")

    CHOICES = [
        ("choice1", entry1),
        ("choice2", entry2),
        ("choice3", entry3),
        ("choice4", entry4)
    ]

    like = forms.ChoiceField(choices=CHOICES, widget=forms.RadioSelect, label=question)