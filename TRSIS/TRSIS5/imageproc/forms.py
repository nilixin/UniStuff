from django import forms

class UploadForm(forms.Form):
    background = forms.FileField(label='Фон (не требуется)', required=False)
    image = forms.FileField(label='Изображение')