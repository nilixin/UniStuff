from django.db import models

class Test(models.Model):
    title = models.CharField(max_length=300)
    shortcut = models.CharField(max_length=20)
    quant = models.IntegerField()
    questions_field = models.BinaryField()
    questions = list()

    def __str__(self):
        return_title = self.title
        return_shortcut = self.shortcut
        return_quant = self.quant
        return_questions = str()

        for question in self.questions:
            return_questions += str(question)

        return f'{return_title} {return_shortcut} {return_quant} {return_questions}'