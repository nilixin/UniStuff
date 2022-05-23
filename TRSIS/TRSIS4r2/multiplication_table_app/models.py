from django.db import models

class Test(models.Model):
    title = models.CharField(max_length=300)
    shortcut = models.CharField(max_length=20)
    quant = models.IntegerField()
    questions_field = models.BinaryField()