from django.db import models

# Create your models here.

class FullName(models.Model):
    name = models.CharField(max_length=200)
    surname = models.CharField(max_length=200)